using System;


namespace R5T.F0106
{
    public class TokenSeparators : ITokenSeparators
    {
        #region Infrastructure

        public static ITokenSeparators Instance { get; } = new TokenSeparators();


        private TokenSeparators()
        {
        }

        #endregion
    }
}
