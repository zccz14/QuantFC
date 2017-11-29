using System.Collections;
using System.Collections.Generic;

namespace QuantFC
{
	public partial class Graph<T>
	{
		public int Count => Elements.Count;
		public GraphElement this[int index] => Elements[index];
	}
}