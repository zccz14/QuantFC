using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantFC
{
	public class Container<T>
	{
		public event Action<string, string> Walk;
		public T Run(T input)
		{
			var cur = Node;
			while (cur != null)
			{
				var nextI = cur.Run(input);
				Walk?.Invoke(cur.Title, cur.GetLabel(nextI));
				if (cur[nextI] == null) break;
				var next = cur[nextI] as IGraphNode<T>;
				if (next == null)
				{
					Console.WriteLine(value: $"[error] type {GetType().GetGenericArguments()[0]} did not impl type {cur[nextI].GetType().GetGenericArguments()[0]} ");
					break;
				}
				cur = next;
			}
			return input;
		}

		public IGraphNode<T> Node { get; set; }
	}

	public static class X
	{
		public static void Link(this IGraphNode This, int index, IGraphNode target)
		{
			This[index] = target;
		}

		public static void Link(this IGraphNode This, params IGraphNode[] targets)
		{
			for (var i = 0; i < This.Count; i++)
			{
				This[i] = targets[i];
			}
		}

		public static INode<T> Implement<T>(this INode This, Func<T, int> implN) =>
			new LambdaNode<T>(This, implN);

		public static INode<T> Implement<T>(this INode This, Action<T> impl) => new ActionNode<T>(This, impl);

		public static IGraphNode ToGraphNode(this INode This) => new GraphNode(This);

		public static IGraphNode<T> ToGraphNode<T>(this INode<T> This) => new LambdaGraphNode<T>(new GraphNode(This), This.Run);

		public static IGraphNode<T> Implement<T>(this IGraphNode This, Func<T, T> implP, Func<T, int> implN) =>
			This.Implement(implP, implN).ToGraphNode();
	}

}
