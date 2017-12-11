using System.Collections.Generic;
using System.Linq;

namespace QuantFC
{
    public class GraphBuilder: IGraphBuilder
    {
        private List<INode> Nodes { get; } = new List<INode>();
        private List<int?[]> Nexts { get; } = new List<int?[]>();

        public int ImportNode(INode node)
        {
            Nodes.Add(node);
            Nexts.Add(new int?[node.Count]);
            return Nodes.Count - 1;
        }

        public void SetLink(int nodeU, int edge, int nodeV)
        {
            if (0 <= edge && edge < Nodes[nodeU].Count)
            {
                Nexts[nodeU][edge] = nodeV;
            }
        }

        public IGraph ExtractGraph()
        {
            var nodes = Nodes.Select(node => new GraphNode(node)).ToArray();
            for (var i = 0; i < Nexts.Count; i++)
            {
                for (var j = 0; j < nodes[i].NextNodes.Length; j++)
                {
                    if (Nexts[i][j].HasValue)
                    {
                        nodes[i].NextNodes[j] = nodes[Nexts[i][j].Value];
                    }
                }
            }
            return new Graph(nodes);
        }

        public void SubstituteNode(int index, INode node) => Nodes[index] = node;

        public INode GetNode(int index) => Nodes[index];
    }
}
