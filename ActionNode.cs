namespace QuantFC
{
    public abstract class ActionNode : ImplementedNode
    {
        protected ActionNode(INode innerNode) : base(innerNode)
        {
        }

        public override int Run()
        {
            Perform();
            return 0;
        }

        protected abstract void Perform();
    }
}