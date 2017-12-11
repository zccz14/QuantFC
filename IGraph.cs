using System.Collections.Generic;

namespace QuantFC
{
    public interface IGraph : IReadOnlyList<IGraphNode>
    {
        bool IsImplemented { get; }
    }
}