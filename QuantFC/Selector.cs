using System;

namespace QuantFC {
	public class Selector<T> : IElement<T>
	{
		public Selector(string title, Func<T, bool> predicate)
		{
			Title = title;
			Predicate = predicate;
		}

		public string Title { get; }
		private Func<T, bool> Predicate { get; }
		public T Run(T state, out int ret)
		{
			ret = Predicate(state) ? 1 : 0;
			return state;
		}
	}

	public static class SelectorX
	{
		public static int Create<T>(this Graph<T> graph, string title, Func<T, bool> predicate)
		{
			var e = new Graph<T>.GraphElement(new Selector<T>(title, predicate), 2)
			{
				NextLabels =
				{
					[0] = "false",
					[1] = "true"
				}
			};
			graph.Elements.Add(e);
			return graph.Count - 1;
		}
	}
}
