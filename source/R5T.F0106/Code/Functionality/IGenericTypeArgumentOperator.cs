using System;

using R5T.T0132;


namespace R5T.F0106
{
    [FunctionalityMarker]
    public partial interface IGenericTypeArgumentOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Does the member name contain a generic type argument list?
        /// </summary>
        public bool Has_GenericTypeArgumentList(string memberName)
        {
            // Check for the presence of the generic type argument list open bracket ("<", the open angle-bracket).
            var output = Instances.StringOperator.Contains(
                Instances.Syntax.GenericTypeArgumentListBracket_Open_Character,
                memberName);

            return output;
        }
    }
}
