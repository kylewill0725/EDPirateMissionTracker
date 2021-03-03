using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration.JournalEventImplementation
{
    [Generator]
    public class EventImplementationGenerator : ISourceGenerator
    {
        private string _classFormatString;
        private string _interfaceFormatString;

        // Run once during build
        public void Initialize(GeneratorInitializationContext context)
        {
            // if (!Debugger.IsAttached) // Uncomment if debugging needed
            //     Debugger.Launch();

            // Load EventHandler template from the EmbeddedResources into the _formatString variable
            var assembly = typeof(EventImplementationGenerator).GetTypeInfo().Assembly;
            var eventsTemplate =
                assembly.GetManifestResourceStream(
                    "CodeGeneration.JournalEventImplementation.Events.template.cs");
            var iEventsTemplate =
                assembly.GetManifestResourceStream(
                    "CodeGeneration.JournalEventImplementation.IEvents.template.cs");
            if (eventsTemplate != null && iEventsTemplate != null)
            {
                using (var sr = new StreamReader(eventsTemplate))
                {
                    _classFormatString = sr.ReadToEnd();
                }
                using (var sr = new StreamReader(iEventsTemplate))
                {
                    _interfaceFormatString = sr.ReadToEnd();
                }
            }

            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        // Run during build and during editing to keep intellisense updated.
        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxReceiver is SyntaxReceiver receiver)) return;

            var classLinesToAdd = new List<string>();
            var interfaceLinesToAdd = new List<string>();
            foreach (var classDeclaration in receiver.IEventHandlerDeclarations)
            {
                var eventName = classDeclaration.Identifier.ValueText;

                // Add event handler to lines to be added to template.
                classLinesToAdd.Add($@"public event EventHandler<{eventName}> {eventName};");
                interfaceLinesToAdd.Add($@"event EventHandler<{eventName}> {eventName};");

                // Add event invoker to lines to be added to template.
                classLinesToAdd.Add(
                    $@"internal void Invoke{eventName}({eventName} arg) => {eventName}?.Invoke(this, arg);");
            }

            var classSource =
                string.Format(_classFormatString,
                    string.Join("\n", classLinesToAdd)
                );

            var interfaceSource =
                string.Format(_interfaceFormatString,
                    string.Join("\n", interfaceLinesToAdd)
                );
            context.AddSource("Events.g.cs", classSource);
            context.AddSource("IEvents.g.cs", interfaceSource);
        }
    }

    public class SyntaxReceiver : ISyntaxReceiver
    {
        private readonly List<ClassDeclarationSyntax> _iEventHandlerDeclarations = new List<ClassDeclarationSyntax>();
        public IEnumerable<ClassDeclarationSyntax> IEventHandlerDeclarations => _iEventHandlerDeclarations;

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax ids && ids.BaseList?.DescendantNodes()
                .OfType<IdentifierNameSyntax>().Any(ins => ins.Identifier.ValueText == "EventBase") == true)
            {
                _iEventHandlerDeclarations.Add(ids);
            }
        }
    }
}