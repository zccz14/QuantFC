using System.Text;

namespace QuantFC
{
	public static partial class GraphX
	{
		public static string ToDotString<T>(this Graph<T> graph)
		{
			var sb = new StringBuilder();
			sb.Append("digraph G {\nedge [fontname=\"Consolas\"];\nnode [fontname=\"Simhei\"];\n");
			sb.Append($"\tS [label=\"{graph.Title}\"];\n");
			sb.Append($"\tS -> {graph.DefaultStart};\n");
			for (int i = 0; i < graph.Count; i++)
			{
				var e = graph.Elements[i];
				sb.Append(
					$"\t{i} [label=\"{e.Element.Title} ({e.Hits})\", shape={(e.Nexts.Length <= 1 ? "box" : "diamond")}];\n");
				for (int ii = 0; ii < e.Nexts.Length; ii++)
				{
					sb.Append(
						$"\t{i} -> {e.Nexts[ii] ?? graph.Count} [label=\"{e.NextLabels[ii]} ({e.NextHits[ii]})\"];\n");
				}
			}
			sb.Append($"\t{graph.Count} [label=\"End of {graph.Title}\"];\n");
			sb.Append("}\n");
			return sb.ToString();
		}
	}
}