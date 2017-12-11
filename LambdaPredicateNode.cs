using System;

namespace QuantFC
{
    public class LambdaPredicateNode : PredicateNode
    {
        public LambdaPredicateNode(INode innerNode, Func<bool> predicate) : base(innerNode)
        {
            Predicate = predicate;
        }

        protected override bool Test() => Predicate();

        private Func<bool> Predicate { get; }
    }
}