using System;

namespace QuantFC
{
    public class LambdaImplementedNodeImpl : ImplementedNode
    {
        public LambdaImplementedNodeImpl(INode innerNode, Func<int> implementation) : base(innerNode)
        {
            Implementation = implementation;
        }

        public override int Run() => Implementation();

        private Func<int> Implementation { get; }
    }
}