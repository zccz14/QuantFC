using System;

namespace QuantFC
{
	/// <summary>
	/// Semantic Node
	/// </summary>
	public interface INode
	{
		/// <summary>
		/// The title of the node
		/// </summary>
		string Title { get; }

		/// <summary>
		/// Exits' Count
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Get the label of Exit i
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		string GetLabel(int i);
	}

	public interface IImplementation
	{
		/// <summary>
		/// run and get exit code
		/// </summary>
		int Run();
	}

	public interface IImplementation<in T>
	{
		/// <summary>
		/// Input a state and get exit code
		/// </summary>
		/// <param name="state"></param>
		/// <returns></returns>
		int Run(T state);
	}

	/// <inheritdoc />
	/// <summary>
	/// Semantic Node with context type T
	/// </summary>
	/// <typeparam name="T">Context Type</typeparam>
	public interface INode<in T>: INode, IImplementation<T>
	{
	}

}