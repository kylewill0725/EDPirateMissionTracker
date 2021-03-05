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
        private string _eventBaseFormatString;

        // Run once during build
        public void Initialize(GeneratorInitializationContext context)
        {
            // if (!Debugger.IsAttached) // Uncomment if debugging needed
            //  c   Debugger.Launch();

            // Load EventHandler template from the EmbeddedResources into the _formatString variable
            var assembly = typeof(EventImplementationGenerator).GetTypeInfo().Assembly;
            var eventsTemplate =
                assembly.GetManifestResourceStream(
                    "CodeGeneration.JournalEventImplementation.Events.template.cs");
            var iEventsTemplate =
                assembly.GetManifestResourceStream(
                    "CodeGeneration.JournalEventImplementation.IEvents.template.cs");
            var eventBaseTemplate =
                assembly.GetManifestResourceStream(
                    "CodeGeneration.JournalEventImplementation.EventBase.template.cs");
            if (eventsTemplate != null && iEventsTemplate != null && eventBaseTemplate != null)
            {
                using (var sr = new StreamReader(eventsTemplate))
                {
                    _classFormatString = sr.ReadToEnd();
                }
                using (var sr = new StreamReader(iEventsTemplate))
                {
                    _interfaceFormatString = sr.ReadToEnd();
                }
                using (var sr = new StreamReader(eventBaseTemplate))
                {
                    _eventBaseFormatString = sr.ReadToEnd();
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
            var invokeExpressionLines = new List<string>();
            var fromJsonLines = new List<string>();
            foreach (var classDeclaration in receiver.IEventHandlerDeclarations)
            {
                var eventName = classDeclaration.Identifier.ValueText;

                // Add event handler to lines to be added to template.
                classLinesToAdd.Add($@"public event EventHandler<{eventName}>? {eventName};");
                interfaceLinesToAdd.Add($@"event EventHandler<{eventName}>? {eventName};");

                // Add event invoker to lines to be added to template.
                classLinesToAdd.Add(
                    $@"internal void Invoke{eventName}({eventName} arg) => {eventName}?.Invoke(this, arg);");
                
                // Add event invokers to a generic invoke function so reflection isn't needed
                invokeExpressionLines.Add($@"case {eventName} e: Invoke{eventName}(e); break;");
                
                // Add FromJson method to EventBase
                fromJsonLines.Add($@"""{eventName}"" => JsonSerializer.Deserialize<{eventName}>(json),");
            }

            var classSource =
                string.Format(_classFormatString,
                    string.Join("\n        ", classLinesToAdd),
                    string.Join("\n                ", invokeExpressionLines)
                );

            var interfaceSource =
                string.Format(_interfaceFormatString,
                    string.Join("\n        ", interfaceLinesToAdd)
                );
            var eventBaseSource =
                string.Format(_eventBaseFormatString,
                    string.Join("\n                ", fromJsonLines)
                );
            context.AddSource("Events.g.cs", classSource);
            context.AddSource("IEvents.g.cs", interfaceSource);
            context.AddSource("EventBase.g.cs", eventBaseSource);
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