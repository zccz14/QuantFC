using System;

namespace QuantFC {
	public partial class Graph<T> {
		public event EventHandler<EvalStartEventArgs> EvalStart;

		public class EvalStartEventArgs : EventArgs
		{
			public int Index { get; set; }
			public GraphElement Element { get; set; }
			public T State { get; set; }
		}
	}
}
