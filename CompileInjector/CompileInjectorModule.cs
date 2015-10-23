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
            Console.WriteLine("Done CompileInjectorModule");
        }
        
        public void BeforeCompile(BeforeCompileContext context)
        {
            //Debugger.Launch();
            
            foreach(var syntaxTree in context.Compilation.SyntaxTrees)
            {
                var newTree = ModifyTree(syntaxTree);

                // Replace the compilation.
                context.Compilation = context.Compilation.ReplaceSyntaxTree(syntaxTree, newTree);
            }
        }

        private SyntaxTree ModifyTree(SyntaxTree originalTree)
        {
            SyntaxTree newTree = originalTree;

            while (true)
            {
                var node = GetFirstClassThatNeedsAFactory(newTree);
                if(node == null)
                {
                    return newTree;
                }

                var classSyntax = node.Class;
                
                var factoryMethod = GetFactoryMethodDeclaration(classSyntax);
                
                var newClass = classSyntax.WithMembers(classSyntax.Members.Add(factoryMethod));
                
                // Get the revised root
                var newRoot = (CompilationUnitSyntax) node.Root.ReplaceNode(classSyntax, newClass);
                
                // Create a new syntax tree.
                newTree = T.Create(newRoot);
            }
        }

        private Node GetFirstClassThatNeedsAFactory(SyntaxTree syntaxTree)
        {
            var root = syntaxTree.GetRoot();
            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>()
                .Where(node => HasAttribute(node));
                
            foreach(var classDeclaration in classDeclarations)
            {
                var methods = classDeclaration.DescendantNodes().OfType<MethodDeclarationSyntax>().ToList();
                if (!methods.Where(d => d.Identifier.Text == "Factory").Any())
                {
                    return new Node
                    {
                        Tree = syntaxTree,
                        Root = root,
                        Class = classDeclaration,
                    };
                }
            }

            return null;
        }

        private bool HasAttribute(ClassDeclarationSyntax node)
        {
            foreach(var attribute in node.AttributeLists.SelectMany(a => a.Attributes))
            {
                if(attribute.ToString() == "RegisterService")
                {
                    return true;
                }
            }

            return false;
        }

        private class Node
        {
            public SyntaxTree Tree { get; set; }
            public SyntaxNode Root { get; set; }
            public ClassDeclarationSyntax Class { get; set; }
        }

        private static MethodDeclarationSyntax GetFactoryMethodDeclaration(ClassDeclarationSyntax @class)
        {
            return
                F.MethodDeclaration(
                    F.ParseName(@class.Identifier.Text),
                    F.Identifier(F.TriviaList(F.Space), @"Factory", F.TriviaList()))
                    .WithModifiers(F.TokenList(
                        F.Token(F.TriviaList(), K.PublicKeyword, F.TriviaList(F.Space)),
                        F.Token(F.TriviaList(), K.StaticKeyword, F.TriviaList(F.Space))))
                    .WithBody(
                        F.Block(F.SingletonList<StatementSyntax>(
                            F.ReturnStatement(CallConstuctor(@class))
                            .WithReturnKeyword(
                                F.Token(
                                    F.TriviaList(
                                        F.Whitespace(
                                            "   ")),
                                    K.ReturnKeyword,
                                    F.TriviaList(
                                        F.Space)))
                            .WithSemicolonToken(
                                F.Token(
                                    F.TriviaList(),
                                    K.SemicolonToken,
                                    F.TriviaList()
                                ))
                    )));
        }

        private static ObjectCreationExpressionSyntax CallConstuctor(ClassDeclarationSyntax @class)
        {
            var typeName = F.ParseName(@class.Identifier.Text);
            var args = F.ArgumentList();

            var ctor = @class.DescendantNodes().OfType<ConstructorDeclarationSyntax>().FirstOrDefault();

            if(ctor != null)
            {
                var parameters = ctor.ParameterList.DescendantNodes().OfType<ParameterSyntax>().ToList();

                foreach (var parameter in parameters)
                {
                    var ident = parameter.DescendantNodes().OfType<IdentifierNameSyntax>().Single();
                    var parameterType = ident.Identifier.Text;

                    var invocation = F.InvocationExpression(F.MemberAccessExpression(
                        K.SimpleMemberAccessExpression,
                        F.IdentifierName(parameterType),
                        F.IdentifierName("Factory")));

                    args = args.AddArguments(F.Argument(invocation));
                }
            }
            
            return F.ObjectCreationExpression(typeName)
                    .WithNewKeyword(F.Token(F.TriviaList(), K.NewKeyword, F.TriviaList(F.Space)))
                    .WithArgumentList(args);
        }
    }
}

