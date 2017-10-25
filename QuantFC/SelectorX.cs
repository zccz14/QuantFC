using System;

namespace QuantFC
{
	public static class SelectorX
	{
		public static int Create<T>(this Graph<T> graph, string title, Func<T, bool> predicate)
		{
			var e = new Graph<T>.GraphElement(new Selector<T>(title, predicate), graph);
			e.Next[0] = new Graph<T>.GraphElement.Connection(e) {Label = "false"};
			e.Next[1] = new Graph<T>.GraphElement.Connection(e) { Label = "true" };
			graph.Elements.Add(e);
			return graph.Count - 1;
		}
	}
}