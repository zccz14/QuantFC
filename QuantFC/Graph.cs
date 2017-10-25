using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace QuantFC {
	public partial class Graph<T> : IElement
	{
		public Graph(string title)
		{
			Title = title;
		}
		public string Title { get; }
		public int NextCount { get; } = 1;
		public int Runtimes { get; set; }
		public List<GraphElement> Elements { get; } = new List<GraphElement>();
		public event EventHandler<RunningEndedEventArgs> RunningEnded;
		public event EventHandler<RunningStartEventArgs> RunningStart;
		public int DefaultStart { get; set; }

		public class RunningEndedEventArgs : EventArgs
		{
			public T InitialState { get; set; }
			public T FinalState { get; set; }
			public List<int> Path { get; set; }
		}

		public class RunningStartEventArgs : EventArgs
		{
			public T State { get; set; }
		}

		public T Run(T state)
		{
			return Run(state, DefaultStart);
		}

		public int Import(IElement<T> element)
		{
			Elements.Add(new GraphElement(element, this));
			return Count - 1;
		}

		public T Run(T state, int start)
		{
			Runtimes++;
			RunningStart?.Invoke(this, new RunningStartEventArgs() {State = state});
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
					if (0 <= ret && ret < curE.Next.Length)
					{
						curE.Next[ret].Hits++;
						nextIdx = curE.Next[ret].Index ?? Count;
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
			public GraphElement (IElement<T> element, Graph<T> graph) {
				Element = element;
				Graph = graph;
				Next = new Connection[element.NextCount];
				for (int i = 0; i < element.NextCount; i++)
				{
					Next[i] = new Connection(this);
				}
			}
			public IElement<T> Element { get; }
			public int Hits { get; set; }
			public Connection[] Next { get; }
			private Graph<T> Graph { get; }

			public class Connection
			{
				public Connection(GraphElement from)
				{
					From = from;
				}

				public int? Index { get; set; }
				public string Label { get; set; }
				public int Hits { get; set; }
				private GraphElement From { get; }
				/// <summary>
				/// 后件概率: 前件发生的情况下，后件发生的概率
				/// </summary>
				public double ConsequentProb => From.Hits == 0 ? double.NaN : (double) Hits / From.Hits;
				/// <summary>
				/// 前件概率: 后件发生的情况下，前件发生的概率
				/// </summary>
				public double AntecedentProb => Index is null ? double.NaN : (double) Hits / From.Graph.Elements[(int)Index].Hits;
			}
		}
	}
}
