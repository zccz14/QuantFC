using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuantFC
{
    public class Graph : IGraph
    {
        public Graph(IReadOnlyList<IGraphNode> nodes)
        {
            Nodes = nodes;
            IsImplemented = nodes.Count(x => x.IsImplemented) == nodes.Count;
        }

        public IEnumerator<IGraphNode> GetEnumerator() => Nodes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => Nodes.Count;

        private IReadOnlyList<IGraphNode> Nodes { get; }

        public IGraphNode this[int index] => Nodes[index];
        public bool IsImplemented { get; }
    }
}