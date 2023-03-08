using System;


namespace R5T.F0106
{
    public class GenericTypeArgumentOperator : IGenericTypeArgumentOperator
    {
        #region Infrastructure

        public static IGenericTypeArgumentOperator Instance { get; } = new GenericTypeArgumentOperator();


        private GenericTypeArgumentOperator()
        {
        }

        #endregion
    }
}
