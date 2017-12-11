namespace QuantFC
{
    public abstract class PredicateNode : ImplementedNode
    {
        protected PredicateNode(INode innerNode) : base(innerNode)
        {
        }

        public override int Run() => Test() ? 1 : 0;

        protected abstract bool Test();
    }
}