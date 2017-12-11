namespace QuantFC
{
    public interface INode
    {
        string Title { get; }
        int Count { get; }
        string GetLabel(int index);
        bool IsImplemented { get; }
    }
}
