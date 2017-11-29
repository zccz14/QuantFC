using System;

namespace QuantFC {
	/// <inheritdoc />
	/// <summary>
	/// Reducer: 1 (A Block)
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Reducer<T> : IElement<T>
	{
		public Reducer(string title, Func<T, T> transformer)
		{
			Title = title;
			Transformer = transformer;
		}

		/// <inheritdoc />
		public string Title { get; }

		/// <inheritdoc />
		/// <summary>
		/// Always Equals To 1
		/// </summary>
		public int NextCount { get; } = 1;

		/// <inheritdoc />
		/// Always Equals To {""}
		public string[] Labels { get; } = {""};

		private Func<T, T> Transformer { get; }

		/// <inheritdoc />
		public T Run(T state, out int ret)
		{
			ret = 0;
			return Transformer(state);
		}
	}
}
