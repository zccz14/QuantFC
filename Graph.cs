using System;
using System.Collections.Generic;

namespace QuantFC {
	/// <inheritdoc />
	/// <summary>
	/// A Graph  
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public partial class Graph<T> : IElement<T>
	{
		public Graph(string title)
		{
			Title = title;
		}

		/// <inheritdoc />
		public T Run(T state, out int ret)
		{
			ret = 0;
			return Run(state, DefaultStart);
		}

		/// <inheritdoc />
		public string Title { get; }

		/// <inheritdoc />
		public int NextCount { get; } = 1;

		/// <inheritdoc />
		public string[] Labels { get; } = {""};

		/// <summary>
		/// Run Hits
		/// </summary>
		public int Hits { get; private set; }

		/// <summary>
		/// The default start position: Run(state, DefaultStart)
		/// </summary>
		public int DefaultStart { get; set; }

		public List<GraphElement> Elements { get; } = new List<GraphElement>();

		public event EventHandler<RunningEndedEventArgs> RunningEnded;

		public event EventHandler<RunningStartEventArgs> RunningStart;

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


		/// <summary>
		/// Explicitly Call this func to Run
		/// </summary>
		/// <param name="state">Initial State</param>
		/// <param name="start">Start Position</param>
		/// <returns>Next State</returns>
		public T Run(T state, int start)
		{
			Hits++;
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
					var nextState = ee.Run(state, out var ret); // inline 
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
				[Obsolete("Move to IElement<T>.Label")]
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
