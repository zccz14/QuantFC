using System.Collections;
using System.Collections.Generic;

namespace QuantFC
{
    public interface IGraph : IReadOnlyList<IGraphNode>
    {
        
    }

    public class Graph : IGraph
    {
        public Graph(IReadOnlyList<IGraphNode> nodes)
        {
            Nodes = nodes;
        }

        public IEnumerator<IGraphNode> GetEnumerator() => Nodes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => Nodes.Count;

        private IReadOnlyList<IGraphNode> Nodes { get; }

        public IGraphNode this[int index] => Nodes[index];
    }
}