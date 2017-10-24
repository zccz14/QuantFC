using System.Collections;
using System.Collections.Generic;

namespace QuantFC
{
	public partial class Graph<T>: IReadOnlyList<Graph<T>.GraphElement>
	{
		public int Count => Elements.Count;
		public IEnumerator<GraphElement> GetEnumerator() => Elements.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public GraphElement this[int index] => Elements[index];
	}
}