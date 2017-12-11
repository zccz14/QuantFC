namespace QuantFC
{
    public class Node : INode
    {
        public Node(string title, params string[] labels)
        {
            Title = title;
            Labels = labels;
            Count = Labels.Length;
        }

        public string Title { get; }
        public int Count { get; }
        public string GetLabel(int index) => Labels[index];
        public bool IsImplemented => false;

        private string[] Labels { get; }
    }
}