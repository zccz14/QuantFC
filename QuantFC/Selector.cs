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
		public int NextCount { get; } = 2;
		private Func<T, bool> Predicate { get; }
		public T Run(T state, out int ret)
		{
			ret = Predicate(state) ? 1 : 0;
			return state;
		}
	}
}
