using System;


namespace R5T.F0106
{
    public static class Instances
    {
        public static F0000.IArrayOperator ArrayOperator => F0000.ArrayOperator.Instance;
        public static Z0000.ICharacters Characters => Z0000.Characters.Instance;
        public static IGenericTypeArgumentOperator GenericTypeArgumentOperator => F0106.GenericTypeArgumentOperator.Instance;
        public static T0162.F001.IMemberKindOperator MemberKindOperator => T0162.F001.MemberKindOperator.Instance;
        public static INamespaceNameOperator NamespaceNameOperator => F0106.NamespaceNameOperator.Instance;
        public static F0000.IStringOperator StringOperator => F0000.StringOperator.Instance;
        public static Z0000.IStrings Strings => Z0000.Strings.Instance;
        public static Z0029.ISyntax Syntax => Z0029.Syntax.Instance;
        public static ITokenSeparators TokenSeparators => F0106.TokenSeparators.Instance;
    }
}