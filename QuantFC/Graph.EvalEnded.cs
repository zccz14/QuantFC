using System;

namespace QuantFC
{
	public partial class Graph<T>
	{
		public event EventHandler<EvalEndedEventArgs> EvalEnded;

		public class EvalEndedEventArgs : EventArgs
		{
			public GraphElement Element { get; set; }
			public int Index { get; set; }
			public int NextIndex { get; set; }
			public T State { get; set; }
			public T NextState { get; set; }
		}
	}
}