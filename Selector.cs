using System;

namespace QuantFC {
	/// <summary>
	/// Selector: NextCount = 2 (T / F)
	/// </summary>
	/// <typeparam name="T">Context Type</typeparam>
	public class Selector<T> : IElement<T>
	{
		public Selector(string title, Func<T, bool> predicate)
		{
			Title = title;
			Predicate = predicate;
		}

		/// <inheritdoc />
		public string Title { get; }

		/// <inheritdoc />
		public int NextCount { get; } = 2;

		/// <inheritdoc />
		/// <summary>
		/// 0 - False; 1 - True.
		/// </summary>
		public string[] Labels { get; } = {"F", "T"};

		private Func<T, bool> Predicate { get; }

		/// <inheritdoc />
		public T Run(T state, out int ret)
		{
			ret = Predicate(state) ? 1 : 0;
			return state;
		}
	}
}
