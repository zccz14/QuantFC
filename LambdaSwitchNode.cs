using System;

namespace QuantFC
{
    public class LambdaSwitchNode : SwitchNode
    {
        public LambdaSwitchNode(INode innerNode, params Func<bool>[] predicates) : base(innerNode)
        {
            Predicates = predicates;
        }

        protected override bool Test(int i) => Predicates[i]();
        private Func<bool>[] Predicates { get; }
    }
}