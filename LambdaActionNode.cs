using System;

namespace QuantFC
{
    public class LambdaActionNode : ActionNode
    {
        public LambdaActionNode(INode innerNode, Action action) : base(innerNode)
        {
            Action = action;
        }

        protected override void Perform() => Action();
        private Action Action { get; } 
    }
}