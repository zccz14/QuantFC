using System;

namespace QuantFC
{
	/// <inheritdoc />
	public class GraphNode: IGraphNode
	{
		/// <inheritdoc />
		public GraphNode(INode innerNode)
		{
			InnerNode = innerNode;
			Nexts = new IGraphNode[Count];
		}

		/// <inheritdoc />
		public string Title => InnerNode.Title;
		/// <inheritdoc />
		public int Count => InnerNode.Count;
		/// <inheritdoc />
		public string GetLabel(int i) => InnerNode.GetLabel(i);

		private INode InnerNode { get; }
		private IGraphNode[] Nexts { get; }

		/// <inheritdoc />
		public IGraphNode this[int i]
		{
			get => Nexts[i];
			set => Nexts[i] = value;
		}
	}


	/// <inheritdoc />
	/// <summary>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class GraphNode<T> : IGraphNode<T>
	{
		/// <inheritdoc />
		protected GraphNode(IGraphNode innerNode)
		{
			InnerNode = innerNode;
		}

		/// <inheritdoc />
		public string Title => InnerNode.Title;

		/// <inheritdoc />
		public int Count => InnerNode.Count;

		/// <inheritdoc />
		public string GetLabel(int i) => InnerNode.GetLabel(i);

		private IGraphNode InnerNode { get; }

		/// <inheritdoc />
		public IGraphNode this[int i]
		{
			get => InnerNode[i];
			set => InnerNode[i] = value;
		}

		/// <inheritdoc />
		public abstract int Run(T state);
	}

	class LambdaGraphNode<T> : GraphNode<T>
	{
		public LambdaGraphNode(IGraphNode innerNode, Func<T, int> implN) : base(innerNode)
		{
			ImplN = implN;
		}

		public override int Run(T state) => ImplN(state);

		private Func<T, int> ImplN { get; }
	}
}