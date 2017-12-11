using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantFC
{
    public partial class X
    {
        public static IEnumerable<INode> ImplementedNodes(this IGraph graph) => graph.Where(node => node.IsImplemented);

        public static double ImplementedRate(this IGraph graph) => (double) graph.ImplementedNodes().Count() / graph.Count;

        public static void Run(this IGraph graph)
        {
            var node = graph[0];
            while (node != null)
            {
                if (node.IsImplemented)
                {
                    node = node.GetNext(((IImplementedNode) node).Run());
                }
                else
                {
                    break;
                }
            }
        }
    }
}
