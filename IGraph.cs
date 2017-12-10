using System.Collections;
using System.Collections.Generic;

namespace QuantFC
{
    public interface IGraph : IEnumerable<IGraphNode>
    {
    }

    public class Graph : IGraph
    {
        public IEnumerator<IGraphNode> GetEnumerator() => throw new System.NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}