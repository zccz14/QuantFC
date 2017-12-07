using System;
using System.Collections.Generic;

namespace QuantFC
{
    /// <summary>
    /// Semantic Only Node
    /// </summary>
    public interface INode
    {
        string Title { get; }
        int Count { get; }
        string GetLabel(int index);
    }

    public interface IGraphNode: INode
    {
        IGraphNode this[int index] { get; set; }
    }

    public interface IImplementation
    {
        int Run();
    }

    public interface IImplementation<in T>
    {
        int Run(T input);
    }
}
