using System;

namespace QuantFC {
	public partial class Graph<T> {
		public event EventHandler<EvalFailedEventArgs> EvalFailed;

		public class EvalFailedEventArgs : EventArgs
		{
			public GraphElement Element { get; set; }
			public int Index { get; set; }
			public T State { get; set; }
			public string Reason { get; set; }
		}
	}
}
