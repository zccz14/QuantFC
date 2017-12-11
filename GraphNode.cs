namespace QuantFC
{
    internal class GraphNode : IGraphNode
    {
        public GraphNode(INode innerNode, params IGraphNode[] nextNodes)
        {
            InnerNode = innerNode;
            NextNodes = nextNodes;
        }

        public GraphNode(INode innerNode)
        {
            InnerNode = innerNode;
            NextNodes = new IGraphNode[innerNode.Count];
        }

        public string Title => InnerNode.Title;
        public int Count => InnerNode.Count;
        public string GetLabel(int index) => InnerNode.GetLabel(index);

        public IGraphNode GetNext(int index) => NextNodes[index];
        public bool IsImplemented => InnerNode.IsImplemented;

        private INode InnerNode { get; }
        public IGraphNode[] NextNodes { get; }
    }
}