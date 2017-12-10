namespace QuantFC
{
    public interface IGraphNode: INode
    {
        IGraphNode GetNext(int index);
    }
}