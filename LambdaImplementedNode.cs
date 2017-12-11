using System;

namespace QuantFC
{
    public class LambdaImplementedNode : ImplementedNode
    {
        public LambdaImplementedNode(INode innerNode, Func<int> implementation) : base(innerNode)
        {
            Implementation = implementation;
        }

        public override int Run() => Implementation();

        private Func<int> Implementation { get; }
    }
}