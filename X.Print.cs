using System;

namespace QuantFC
{
    public static partial class X
    {
        public static void Print(this IGraph graph)
        {
            foreach (var graphNode in graph)
            {
                graphNode.Print();
            }
        }

        public static void Print(this IGraphNode node)
        {
            node.AsNode().Print();
        }

        public static void Print(this INode node)
        {
            Console.WriteLine(node.Title);
            for (var i = 0; i < node.Count; i++)
            {
                Console.Write($"[{i}: {node.GetLabel(i)}]");
            }
            Console.WriteLine();
        }

        public static INode AsNode(this INode node) => node;
    }
}
