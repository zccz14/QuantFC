using System;
using QuantTC;

namespace QuantFC {
	public static class ReducerX
	{
		public static int Create<T>(this Graph<T> graph, string title, Func<T, T> transformer) => new Reducer<T>(title, transformer).Inject(graph);
		public static int Create<T>(this Graph<T> graph, string title, Action<T> action) => new Reducer<T>(title, action.ToFunc()).Inject(graph);
	}
}
