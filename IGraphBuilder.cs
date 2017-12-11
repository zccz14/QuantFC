namespace QuantFC
{
    public interface IGraphBuilder
    {
        int ImportNode(INode node);
        void SetLink(int nodeU, int edge, int nodeV);
        IGraph ExtractGraph();
        void SubstituteNode(int index, INode node);
        INode GetNode(int index);
    }
}