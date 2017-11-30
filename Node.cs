using System;
using System.Linq;

namespace QuantFC
{
	/// <inheritdoc />
	/// <summary>
	/// Semantic Node (Context Free)
	/// </summary>
	public class Node : INode
	{
		/// <inheritdoc />
		public Node(string title, params string[] labels)
		{
			Title = title;
			Labels = labels;
		}

		/// <inheritdoc />
		public string Title { get; }

		/// <inheritdoc />
		public int Count => Labels.Length;

		/// <inheritdoc />
		public string GetLabel(int i) => Labels[i];

		/// <summary>
		/// Default Storage
		/// </summary>
		private string[] Labels { get; }
	}

	/// <inheritdoc />
	public abstract class Node<T> : INode<T>
	{
		/// <inheritdoc />
		protected Node(INode innerNode)
		{
			InnerNode = innerNode;
		}

		/// <inheritdoc />
		public string Title => InnerNode.Title;

		/// <inheritdoc />
		public int Count => InnerNode.Count;

		/// <inheritdoc />
		public string GetLabel(int i) => InnerNode.GetLabel(i);

		/// <summary>
		/// Mark: prefer composite rather than inheritance
		/// </summary>
		private INode InnerNode { get; }

		/// <inheritdoc />
		public abstract int Run(T state);
	}

	/// <inheritdoc />
	public class LambdaNode<T> : Node<T>
	{
		/// <inheritdoc />
		public LambdaNode(INode innerNode, Func<T, int> nextFunc) : base(innerNode)
		{
			NextFunc = nextFunc;
		}

		/// <inheritdoc />
		public override int Run(T state) => NextFunc(state);

		private Func<T, int> NextFunc { get; }
	}

	public class ActionNode<T> : Node<T>
	{
		public ActionNode(INode innerNode, Action<T> action) : base(innerNode)
		{
			Action = action;
		}

		public override int Run(T state)
		{
			Action(state);
			return 0;
		}

		private Action<T> Action { get; }
	}
}