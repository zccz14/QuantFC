using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuantFC {
	public partial class Graph<T> : IElement
	{
		public Graph(string title)
		{
			Title = title;
		}

		public string Title { get; }
		public List<GraphElement> Elements { get; } = new List<GraphElement>();
		public event EventHandler<RunningEndedEventArgs> RunningEnded;
		public int DefaultStart { get; set; }

		public class RunningEndedEventArgs : EventArgs
		{
			public T InitialState { get; set; }
			public T FinalState { get; set; }
			public List<int> Path { get; set; }
		}

		public T Run(T state)
		{
			return Run(state, DefaultStart);
		}

		public T Run(T state, int start)
		{
			var result = new RunningEndedEventArgs()
			{
				InitialState = state,
				Path = new List<int>()
			};
			int idx = start;
			while (idx < Count)
			{
				result.Path.Add(idx);
				var curE = Elements[idx];
				curE.Hits++;
				EvalStart?.Invoke(this, new EvalStartEventArgs()
				{
					Element = curE,
					Index = idx,
					State = state
				});
				var ee = curE.Element;
				try
				{
					int ret;
					var nextState = ee.Run(state, out ret);
					int nextIdx;
					if (0 <= ret && ret < curE.Nexts.Length)
					{
						curE.NextHits[ret]++;
						nextIdx = curE.Nexts[ret] ?? Count;
					} else
					{
						throw new Exception("invalid return path");
					}
					EvalEnded?.Invoke(this, new EvalEndedEventArgs() {
						Element = curE,
						Index = idx,
						State = state,
						NextIndex = nextIdx,
						NextState = nextState
					});
					result.FinalState = state = nextState;
					idx = nextIdx;
				} catch (Exception e)
				{
					EvalFailed?.Invoke(this, new EvalFailedEventArgs()
					{
						Element = curE,
						Index = idx,
						State = state,
						Reason = e.Message
					});
					idx = Count; // as a break
				}
			}
			RunningEnded?.Invoke(this, result);
			return state;
		}

		public class GraphElement {
			public GraphElement (IElement<T> element, int maxNextsLength) {
				Element = element;
				Nexts = new int?[maxNextsLength];
				NextLabels = new string[maxNextsLength];
				NextHits = new int[maxNextsLength];
			}
			public IElement<T> Element { get; }
			public int Hits { get; set; }
			public int?[] Nexts { get; }
			public string[] NextLabels { get; set; }
			public int[] NextHits { get; set; }
		}
	}
}
