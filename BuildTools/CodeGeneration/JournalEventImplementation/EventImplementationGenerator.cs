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
        private string _formatString;
        
        // Run once during build
        public void Initialize(GeneratorInitializationContext context)
        {
            // if (!Debugger.IsAttached) // Uncomment if debugging needed
            //     Debugger.Launch();
            
            // Load EventHandler template from the EmbeddedResources into the _formatString variable
            var assembly = typeof(EventImplementationGenerator).GetTypeInfo().Assembly;
            var eventHandlerTemplate = assembly.GetManifestResourceStream("CodeGeneration.JournalEventImplementation.EventHandler.template.cs");
            if (eventHandlerTemplate != null)
            {
                using (var sr = new StreamReader(eventHandlerTemplate))
                {
                    _formatString = sr.ReadToEnd();
                }
            }
            
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        // Run during build and during editing to keep intellisense updated.
        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxReceiver is SyntaxReceiver receiver)) return;

            var linesToAdd = new List<string>();
            foreach (var interfaceDeclarationSyntax in receiver.IEventHandlerDeclarations)
            {
                foreach (var member in interfaceDeclarationSyntax.Members.OfType<EventFieldDeclarationSyntax>())
                {
                    // Set to T in public event EventHandler<T> NAME
                    var typeString = "";
                    var type = member.Declaration.Type;
                    if (type is GenericNameSyntax genericType) // All events are of type EventHandler<T> so this should always be true.
                    {
                        typeString =
                            string.Join(",",
                                genericType.TypeArgumentList.Arguments
                                        .OfType<IdentifierNameSyntax>()
                                        .Select(t => t.Identifier.Text)
                                );
                    }
                    
                    // Set to NAME in public event EventHandler<T> NAME;
                    var variableNameString = member.Declaration.Variables.Select(v => v.Identifier.Text).First();
                    
                    // Add event handler to lines to be added to template.
                    linesToAdd.Add($@"public event EventHandler<{typeString}> {variableNameString};");
                    
                    // Add event invoker to lines to be added to template.
                    linesToAdd.Add($@"internal void Invoke{variableNameString}({typeString} arg) => {variableNameString}?.Invoke(this, arg);");
                }
            }

            var source =
                string.Format(_formatString,
                    string.Join("\n", linesToAdd)
                );
            context.AddSource("EventHandler.g.cs", source);
        }
    }

    public class SyntaxReceiver : ISyntaxReceiver
    {
        private readonly List<InterfaceDeclarationSyntax> _iEventHandlerDeclarations = new List<InterfaceDeclarationSyntax>();
        public IEnumerable<InterfaceDeclarationSyntax> IEventHandlerDeclarations => _iEventHandlerDeclarations;

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is InterfaceDeclarationSyntax ids && ids.Identifier.Text == "IEventHandler")
            {
                _iEventHandlerDeclarations.Add(ids);
            }
        }
    }
}