using Microsoft.Dnx.Compilation.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.CodeAnalysis;

using T = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree;
using F = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using K = Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;

namespace CompileInjector
{
    public class CompileInjectorModule : ICompileModule
    {
        public CompileInjectorModule()
        {
            Console.WriteLine("Starting CompileInjectorModule");
        }


        public void AfterCompile(AfterCompileContext context)
        {
            // NoOp
        }
        
        public void BeforeCompile(BeforeCompileContext context)
        {
            //Debugger.Launch();

            // Get our Greeter class.
            var syntaxMatch = context.Compilation.SyntaxTrees
                .Select(s => new
                {
                    Tree = s,
                    Root = s.GetRoot(),
                    Class = s.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().Where(cs => cs.Identifier.ValueText == "Greeter").SingleOrDefault()
                })
                .Where(a => a.Class != null)
                .Single();

            var tree = syntaxMatch.Tree;
            var root = syntaxMatch.Root;
            var classSyntax = syntaxMatch.Class;


            var method = T.ParseText(@"
public static Greeter Factory()
{
    return new Greeter(new MessageGreeter());
}
");

            var rootFactory = method.GetRoot();

            var factoryMethod = (MethodDeclarationSyntax)rootFactory.DescendantNodes().First();
            
            var newClass = classSyntax.WithMembers(classSyntax.Members.Add(factoryMethod));

            //// Get the method declaration.
            //var methodSyntax = classSyntax.Members
            //    .OfType<MethodDeclarationSyntax>()
            //    .Where(ms => ms.Identifier.ValueText == "GetMessage")
            //    .Single();

            //// Let's implement the body.
            //var returnStatement = F.ReturnStatement(
            //    F.LiteralExpression(
            //        K.StringLiteralExpression,
            //        F.Literal(@"""weeeee!""")));

            //// Get the body block
            //var bodyBlock = methodSyntax.Body;

            //// Create a new body block, with our new statement.
            //var newBodyBlock = F.Block(new StatementSyntax[] { returnStatement });

            // Get the revised root
            var newRoot = (CompilationUnitSyntax)root.ReplaceNode(classSyntax, newClass);

            // Create a new syntax tree.
            var newTree = T.Create(newRoot);

            // Replace the compilation.
            context.Compilation = context.Compilation.ReplaceSyntaxTree(tree, newTree);
        }
    }
}

