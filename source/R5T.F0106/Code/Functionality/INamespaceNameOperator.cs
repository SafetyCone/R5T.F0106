using System;

using R5T.T0132;
using R5T.T0161;


namespace R5T.F0106
{
    [FunctionalityMarker]
    public partial interface INamespaceNameOperator : IFunctionalityMarker
    {
        public int Get_LastIndexOfNamespaceTokenSeparator(string memberName)
        {
            var lastIndexOfNamespaceTokenSeparator = Instances.StringOperator.LastIndexOf_OrNotFound(
                Instances.Syntax.NamespaceTokenSeparator_Character,
                memberName);

            return lastIndexOfNamespaceTokenSeparator;
        }
    }
}
