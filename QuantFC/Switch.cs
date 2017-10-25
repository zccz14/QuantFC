using System;
using System.Linq;

namespace QuantFC
{
	public class Switch<T> : IElement<T>
	{
		public Switch(string title, params Func<T, bool>[] predicates)
		{
			Title = title;
			Predicates = predicates;
			NextCount = Predicates.Length + 1;
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
		private Func<T, bool>[] Predicates { get; }
	}
}