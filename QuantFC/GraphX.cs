using System.Text;

namespace QuantFC {
	public static partial class GraphX
	{
		public static void SetLink<T>(this Graph<T> graph, int from, int order, int? to)
		{
			graph.Elements[from].Nexts[order] = to;
		}

		public static void SetLink<T>(this Graph<T>.GraphElement e, int order, int? to)
		{
			e.Nexts[order] = to;
		}
	}
}
