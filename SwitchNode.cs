namespace QuantFC
{
    public abstract class SwitchNode : ImplementedNode
    {
        protected SwitchNode(INode innerNode) : base(innerNode)
        {
        }

        public override int Run()
        {
            for (var i = 0; i + 1 < Count; i++)
            {
                if (Test(i))
                {
                    return i;
                }
            }
            return Count;
        }

        protected abstract bool Test(int i);
    }
}