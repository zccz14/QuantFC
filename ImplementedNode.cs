namespace QuantFC
{
    public abstract class ImplementedNode : IImplementedNode
    {
        protected ImplementedNode(INode innerNode)
        {
            InnerNode = innerNode;
        }

        public string Title => InnerNode.Title;
        public int Count => InnerNode.Count;
        public string GetLabel(int index) => InnerNode.GetLabel(index);
        public bool IsImplemented => true;

        public abstract int Run();

        private INode InnerNode { get; }
    }
}