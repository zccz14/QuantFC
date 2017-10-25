using System;

namespace QuantFC {
	public class Reducer<T> : IElement<T>
	{
		public Reducer(string title, Func<T, T> transformer)
		{
			Title = title;
			Transformer = transformer;
		}

		public string Title { get; }
		public int NextCount { get; } = 1;
		public Func<T, T> Transformer { get; }
		public T Run(T state, out int ret)
		{
			ret = 0;
			return Transformer(state);
		}
	}
}
