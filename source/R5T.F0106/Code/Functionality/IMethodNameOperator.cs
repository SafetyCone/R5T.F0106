using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;


namespace R5T.F0106
{
    [FunctionalityMarker]
    public partial interface IMethodNameOperator : IFunctionalityMarker
    {
        private static Internal.IMethodNameOperator Internal => F0106.Internal.MethodNameOperator.Instance;


        public ArgumentName[] Get_ArgumentNames(FullMethodName fullMethodName)
        {
            var argumentsList = Internal.Get_ArgumentsList(fullMethodName);

            var output = Internal.SplitArgumentsListAccountingForTypeArgumentsList(argumentsList)
                .Trim()
                .Select(typeNameArgumentNamePair =>
                {
                    // Need to use last index of space, since argument types might contain multiple generic type parameters.
                    var indexOfLastSpace = Instances.StringOperator.Get_LastIndexOf(
                        Instances.Syntax.Space_Character,
                        typeNameArgumentNamePair);

                    var argumentNameToken = Instances.StringOperator.FromIndex_Exclusive(
                        indexOfLastSpace,
                        typeNameArgumentNamePair)
                        .Trim();

                    return argumentNameToken.ToArgumentName();
                })
                .Now();

            return output;
        }

        public TypeName[] Get_ArgumentTypeNames(FullMethodName fullMethodName)
        {
            var argumentsList = Internal.Get_ArgumentsList(fullMethodName);

            var output = Internal.SplitArgumentsListAccountingForTypeArgumentsList(argumentsList)
                .Trim()
                .Select(typeNameArgumentNamePair =>
                {
                    // Need to use last index of space, since argument types might contain multiple generic type parameters.
                    var indexOfLastSpace = Instances.StringOperator.Get_LastIndexOf(
                        Instances.Syntax.Space_Character,
                        typeNameArgumentNamePair);

                    var argumentTypeNameToken = Instances.StringOperator.ToIndex_Exclusive(
                        indexOfLastSpace,
                        typeNameArgumentNamePair)
                        .Trim();

                    return argumentTypeNameToken.ToTypeName();
                })
                .Now();

            return output;
        }

        public TypeName Get_ContainingTypeName(TypeNamedMethodName typeNamedMethodName)
        {
            var lastIndexOfNamespaceTokenSeparator = Instances.NamespaceNameOperator.Get_LastIndexOfNamespaceTokenSeparator(typeNamedMethodName.Value);

            var typeName = Instances.StringOperator.Get_FirstNCharacters_ByExclusiveIndex(
                typeNamedMethodName.Value,
                lastIndexOfNamespaceTokenSeparator);

            var output = typeName.ToTypeName();
            return output;
        }

        public FullMethodName Get_FullMethodName(KindMarkedFullMethodName kindMarkedFullMethodName)
        {
            var removedMethodKindMarker = Instances.MemberKindOperator.RemoveKindMark(kindMarkedFullMethodName.Value);

            var output = removedMethodKindMarker.ToFullMethodName();
            return output;
        }

        public FullMethodName Get_FullMethodName(KindMarkedFullMemberName kindMarkedFullMemberName)
        {
            var kindMarkedFullMethodName = this.Get_KindMarkedFullMethodName(kindMarkedFullMemberName);

            var output = this.Get_FullMethodName(kindMarkedFullMethodName);
            return output;
        }

        public GenericTypeArgumentName[] Get_GenericTypeArgumentNames(MethodName methodName)
        {
            var isGeneric = this.Is_Generic(methodName);
            if (!isGeneric)
            {
                return Instances.ArrayOperator.Get_NewEmpty<GenericTypeArgumentName>();
            }

            var genericTypeArgumentsList = Internal.Get_GenericTypeArgumentsList(methodName);

            var output = Instances.StringOperator.Split(
                Instances.Syntax.ArgumentsListTokenSeparator_Character,
                genericTypeArgumentsList)
                .Trim()
                .Select(value => value.ToGenericTypeArgumentName())
                .Now();

            return output;
        }

        public GenericTypeArgumentName[] Get_GenericTypeArgumentNames(TypeNamedMethodName typeNamedMethodName)
        {
            var methodName = this.Get_MethodName(typeNamedMethodName);

            var output = this.Get_GenericTypeArgumentNames(methodName);
            return output;
        }

        public KindMarkedFullMethodName Get_KindMarkedFullMethodName(KindMarkedFullMemberName kindMarkedFullMemberName)
        {
            var isMethodKindMarked = Instances.MemberKindOperator.Is_MethodKindMarked(kindMarkedFullMemberName.Value);
            if(!isMethodKindMarked)
            {
                throw new ArgumentException("Member name was not method kind marked.");
            }

            var output = kindMarkedFullMemberName.Value.ToKindMarkedFullMethodName();
            return output;
        }

        public MethodName Get_MethodName(TypeNamedMethodName typeNamedMethodName)
        {
            var lastIndexOfNamespaceTokenSeparator = Instances.NamespaceNameOperator.Get_LastIndexOfNamespaceTokenSeparator(typeNamedMethodName.Value);

            var typeName = Instances.StringOperator.FromIndex_Exclusive(
                lastIndexOfNamespaceTokenSeparator,
                typeNamedMethodName.Value);

            var output = typeName.ToMethodName();
            return output;
        }

        public TypeName Get_ReturnTypeName(FullMethodName fullMethodName)
        {
            var tokens = Instances.StringOperator.Split(
                Instances.TokenSeparators.MethodReturnTypeTokenSeparator_Character,
                fullMethodName.Value);

            var returnTypeToken = tokens.Second();

            var output = returnTypeToken.ToTypeName();
            return output;
        }

        public TypeNamedMethodName Get_TypeNamedMethodName(FullMethodName fullMethodName)
        {
            var indexOfFirstOpenParenthesis = Instances.StringOperator.IndexOf_OrNotFound(
                Instances.Characters.OpenParenthesis,
                fullMethodName.Value);

            // Everything up to the index of the first open parenthesis (including the generic type arguments for the method) is part of the type-named method name.
            var typeNamedMethodName = Instances.StringOperator.Get_FirstNCharacters_ByExclusiveIndex(
                fullMethodName,
                indexOfFirstOpenParenthesis);

            var output = typeNamedMethodName.ToTypeNamedMethodName();
            return output;
        }

        /// <summary>
        /// Determines if the method name is a full method name, which has:
        /// <list type="number">
        /// <item><inheritdoc cref="Internal.IMethodNameOperator.Is_FullMethodName_HasOpenAndCloseParentheses(string)" path="/summary"/></item>
        /// <item><inheritdoc cref="Internal.IMethodNameOperator.Is_FullMethodName_HasSingleSemicolon(string)" path="/summary"/></item>
        /// </list>
        /// </summary>
        public bool Is_FullMethodName(string methodName)
        {
            var hasOpenAndCloseParenthesis = Internal.Is_FullMethodName_HasOpenAndCloseParentheses(methodName);
            var hasSingleSemicolon = Internal.Is_FullMethodName_HasSingleSemicolon(methodName);

            var output = true
                && hasOpenAndCloseParenthesis
                && hasSingleSemicolon
                ;

            return output;
        }

        public bool Is_Generic(MethodName methodName)
        {
            var output = Instances.GenericTypeArgumentOperator.Has_GenericTypeArgumentList(methodName.Value);
            return output;
        }

        public bool Is_KindMarkedFullMethodName(string methodName)
        {
            var isMethodKindMarked = Instances.MemberKindOperator.Is_MethodKindMarked(methodName);
            if(!isMethodKindMarked)
            {
                return false;
            }

            var nonKindMarkedMethodName = Instances.MemberKindOperator.RemoveKindMark(methodName);

            var isFullMethodName = this.Is_FullMethodName(nonKindMarkedMethodName);
            return isFullMethodName;
        }
    }
}
