namespace QuantFC
{
    public class GraphNode : IGraphNode
    {
        public GraphNode(INode innerNode, params IGraphNode[] nextNodes)
        {
            InnerNode = innerNode;
            NextNodes = nextNodes;
        }

        public string Title => InnerNode.Title;
        public int Count => InnerNode.Count;
        public string GetLabel(int index) => InnerNode.GetLabel(index);

        public IGraphNode GetNext(int index) => NextNodes[index];

        private INode InnerNode { get; }
        private IGraphNode[] NextNodes { get; }
    }
}