using System;
using System.Linq;
using QuantTC;
using static QuantTC.Functions;

namespace QuantFC
{
	public class Switch<T> : IElement<T>
	{
		public Switch(string title, params Func<T, bool>[] predicates)
		{
			Title = title;
			Predicates = predicates;
			NextCount = Predicates.Length + 1;
			Labels = new string[NextCount];
		}

		public Switch<T> PasteLabels(params string[] labels)
		{
			Range(0, Math.Min(NextCount, labels.Length)).ForEach(i => Labels[i] = labels[i]);
			return this;
		}

		public T Run(T state, out int ret)
		{
			for(var i = 0; i < Predicates.Length; i++)
			{
				if (Predicates[i](state))
				{
					ret = i;
					return state;
				}
			}
			ret = NextCount - 1; // default branch
			return state;
		}

		public string Title { get; }
		public int NextCount { get; }
		public string[] Labels { get; }
		private Func<T, bool>[] Predicates { get; }
	}

	public static class SwitchX
	{
		public static int Create<T>(this Graph<T> graph, string title, Func<T, bool>[] predicates)
		{
			var count = predicates.Length;
			var graphElement = new Graph<T>.GraphElement(new Switch<T>(title, predicates), graph);
			graph.Elements.Add(graphElement);
			return graph.Count - 1;
		}
	}
}