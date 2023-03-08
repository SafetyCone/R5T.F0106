using System;


namespace R5T.F0106.Construction
{
    public static class Instances
    {
        public static Z0031.Raw.IFullMethodNames RawFullMethodNames => Z0031.Raw.FullMethodNames.Instance;
        public static Z0031.Raw.IKindMarkedFullMemberNames RawKindMarkedFullMemberNames => Z0031.Raw.KindMarkedFullMemberNames.Instance;
        public static IMethodNameOperator MethodNameOperator => F0106.MethodNameOperator.Instance;
    }
}