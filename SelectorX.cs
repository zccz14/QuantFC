using System;

namespace QuantFC
{
	public static class SelectorX
	{
		public static int Create<T>(this Graph<T> graph, string title, Func<T, bool> predicate) => new Selector<T>(title, predicate).Inject(graph);
	}
}