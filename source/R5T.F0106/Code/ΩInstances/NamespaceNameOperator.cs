using System;


namespace R5T.F0106
{
    public class NamespaceNameOperator : INamespaceNameOperator
    {
        #region Infrastructure

        public static INamespaceNameOperator Instance { get; } = new NamespaceNameOperator();


        private NamespaceNameOperator()
        {
        }

        #endregion
    }
}
