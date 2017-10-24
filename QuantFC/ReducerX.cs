using System;

namespace QuantFC {
	public static class ReducerX
	{
		public static int Create<T>(this Graph<T> graph, string title, Func<T, T> transformer)
		{
			graph.Elements.Add(new Graph<T>.GraphElement(new Reducer<T>(title, transformer), 1));
			return graph.Count - 1;
		}
	}
}
