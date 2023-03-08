using System;

using R5T.T0132;


namespace R5T.F0106.Construction
{
    [FunctionalityMarker]
    public partial interface IOperations : IFunctionalityMarker
    {
        public void GetArgumentTypeNames_FromFullMethodName()
        {
            /// Inputs.
            var fullMethodName =
                // Has no arguments.
                //Instances.RawFullMethodNames.For_Method_0001
                // Has arguments.
                //Instances.RawFullMethodNames.For_Method_0003
                // Argument has multiple type parameters.
                Instances.RawFullMethodNames.For_Method_0004
                ;


            /// Run.
            var argumentTypeNames = Instances.MethodNameOperator.Get_ArgumentTypeNames(fullMethodName);

            F0000.ConsoleOperator.Instance.WriteLines(
                argumentTypeNames,
                x => x.ToString());
        }

        public void GetArgumentNames_FromFullMethodName()
        {
            /// Inputs.
            var fullMethodName =
                // Has no arguments.
                //Instances.RawFullMethodNames.For_Method_0001
                // Has arguments.
                Instances.RawFullMethodNames.For_Method_0003
                // Argument has multiple type parameters.
                //Instances.RawFullMethodNames.For_Method_0004
                ;


            /// Run.
            var argumentNames = Instances.MethodNameOperator.Get_ArgumentNames(fullMethodName);

            F0000.ConsoleOperator.Instance.WriteLines(
                argumentNames,
                x => x.ToString());
        }

        public void GetGenericTypeArguments_FromFullMethodName()
        {
            /// Inputs.
            var fullMethodName = Instances.RawFullMethodNames.For_Method_0003;


            /// Run.
            var typeNamedMethodName = Instances.MethodNameOperator.Get_TypeNamedMethodName(fullMethodName);

            var methodName = Instances.MethodNameOperator.Get_MethodName(typeNamedMethodName);

            var genericTypeArgumentNames = Instances.MethodNameOperator.Get_GenericTypeArgumentNames(methodName);

            F0000.ConsoleOperator.Instance.WriteLines(
                genericTypeArgumentNames,
                x => x.ToString());
        }

        public void GetMethodName_FromFullMethodName()
        {
            /// Inputs.
            var fullMethodName = Instances.RawFullMethodNames.For_Method_0001;


            /// Run.
            var typeNamedMethodName = Instances.MethodNameOperator.Get_TypeNamedMethodName(fullMethodName);

            var methodName = Instances.MethodNameOperator.Get_MethodName(typeNamedMethodName);

            Console.WriteLine(methodName);
        }

        public void GetContainingTypeName_FromFullMethodName()
        {
            /// Inputs.
            var fullMethodName = Instances.RawFullMethodNames.For_Method_0001;


            /// Run.
            var typeNamedMethodName = Instances.MethodNameOperator.Get_TypeNamedMethodName(fullMethodName);

            var containingTypeName = Instances.MethodNameOperator.Get_ContainingTypeName(typeNamedMethodName);

            Console.WriteLine(containingTypeName);
        }

        public void GetTypeNamedMethodName_FromFullMethodName()
        {
            /// Inputs.
            var fullMethodName = Instances.RawFullMethodNames.For_Method_0001;


            /// Run.
            var typeNamedMethodName = Instances.MethodNameOperator.Get_TypeNamedMethodName(fullMethodName);

            Console.WriteLine(typeNamedMethodName);
        }

        public void GetReturnType_FromFullMethodName()
        {
            /// Inputs.
            var fullMethodName = Instances.RawFullMethodNames.For_Method_0001;


            /// Run.
            var returnTypeName = Instances.MethodNameOperator.Get_ReturnTypeName(fullMethodName);

            Console.WriteLine(returnTypeName);
        }

        public void GetFullMethodName_FromKindMarkedFullMemberName()
        {
            /// Inputs.
            var kindMarkedFullMemberName = Instances.RawKindMarkedFullMemberNames.Method_0001;


            /// Run.
            var fullMethodName = Instances.MethodNameOperator.Get_FullMethodName(kindMarkedFullMemberName);

            Console.WriteLine(fullMethodName);
        }
    }
}
