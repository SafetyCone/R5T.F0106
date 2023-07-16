using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0161;


namespace R5T.F0106.Internal
{
    [FunctionalityMarker]
    public partial interface IMethodNameOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Splits an arguments list (containing type name-argument name pairs) accounting for the fact that type names might contain type parameter argument lists.
        /// This means that a simple split on comma will fail.
        /// </summary>
        public IEnumerable<string> SplitArgumentsListAccountingForTypeArgumentsList(string argumentsList)
        {
            if (Instances.StringOperator.IsEmpty(argumentsList))
            {
                yield break;
            }

            // Could do this with a Regex, but that regex pattern would be complicated.

            int currentStartIndex = 0;

            bool currentlyInTypeArgumentsList = false;

            var currentCount = 0;

            foreach (var character in argumentsList)
            {
                if (character == Instances.Syntax.GenericTypeArgumentListBracket_Open_Character)
                {
                    currentlyInTypeArgumentsList = true;
                }

                if (character == Instances.Syntax.GenericTypeArgumentListBracket_Close_Character)
                {
                    currentlyInTypeArgumentsList = false;
                }

                if (character == Instances.Syntax.ArgumentsListTokenSeparator_Character)
                {
                    if (!currentlyInTypeArgumentsList)
                    {
                        var output = Instances.StringOperator.Get_Substring_Exclusive_Exclusive(
                            currentStartIndex,
                            currentCount,
                            argumentsList);

                        currentStartIndex = currentCount;

                        yield return output;
                    }
                }

                currentCount++;
            }

            yield return Instances.StringOperator.Get_Substring_Exclusive(
                currentStartIndex,
                argumentsList);
        }

        public string Get_ArgumentsList(IFullMethodName fullMethodName)
        {
            var indexOfOpen = Instances.StringOperator.IndexOf(
                Instances.Syntax.ArgumentsListParenthesis_Open_Character,
                fullMethodName.Value);

            var indexOfClose = Instances.StringOperator.IndexOf(
                Instances.Syntax.ArgumentsListParenthesis_Close_Character,
                fullMethodName.Value);

            if (!indexOfOpen.Exists || !indexOfClose.Exists)
            {
                throw new Exception("No arguments list found. (Must contain \"<...>\".)");
            }

            var output = Instances.StringOperator.Get_Substring_Exclusive_Exclusive(
                indexOfOpen.Result,
                indexOfClose.Result,
                fullMethodName.Value);

            return output;
        }

        public string Get_GenericTypeArgumentsList(IMethodName methodName)
        {
            var indexOfOpen = Instances.StringOperator.IndexOf(
                Instances.Syntax.GenericTypeArgumentListBracket_Open_Character,
                methodName.Value);

            var indexOfClose = Instances.StringOperator.IndexOf(
                Instances.Syntax.GenericTypeArgumentListBracket_Close_Character,
                methodName.Value);

            if(!indexOfOpen.Exists || !indexOfClose.Exists)
            {
                throw new Exception("No generic type arguments list found. (Must contain \"<...>\".)");
            }

            var output = Instances.StringOperator.Get_Substring_Exclusive_Exclusive(
                indexOfOpen.Result,
                indexOfClose.Result,
                methodName.Value);

            return output;
        }

        /// <summary>
        /// Does the method name have open and close parentheses?
        /// </summary>
        public bool Is_FullMethodName_HasOpenAndCloseParentheses(string methodName)
        {
            var hasOpenParenthesis = false;
            var hasCloseParenthesis = false;

            foreach (var character in methodName)
            {
                if(character == Instances.Characters.OpenParenthesis)
                {
                    hasOpenParenthesis = true;
                }

                if(character == Instances.Characters.CloseParenthesis)
                {
                    hasCloseParenthesis = true;
                }
            }

            var output = hasOpenParenthesis && hasCloseParenthesis;
            return output;
        }

        /// <summary>
        /// Does the method name have a single semi-colon?
        /// </summary>
        public bool Is_FullMethodName_HasSingleSemicolon(string methodName)
        {
            var semicolonCount = Instances.StringOperator.Get_CountOf(
                Instances.TokenSeparators.MethodReturnTypeTokenSeparator_Character,
                methodName);

            var output = semicolonCount == 1;
            return output;
        }
    }
}
