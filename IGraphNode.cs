namespace QuantFC
{
	/// <inheritdoc />
	/// <summary>
	/// Node with graph context
	/// </summary>
	public interface IGraphNode : INode
	{
		/// <summary>
		/// Get and Set the i-th next node
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		IGraphNode this[int i] { get; set; }
	}

	/// <inheritdoc cref="IGraphNode" />
	/// <inheritdoc cref="INode{T}" />
	public interface IGraphNode<in T> : IGraphNode, INode<T>
	{

	}
}