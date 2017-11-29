namespace QuantFC {
	/// <summary>
	/// Element: With a title, and several exits (with label here)
	/// </summary>
	public interface IElement
	{
		/// <summary>
		/// Describe what the element does
		/// </summary>
		string Title { get; }
		/// <summary>
		/// How many exits does the element have?
		/// </summary>
		int NextCount { get; }
		/// <summary>
		/// Describe each exits' meaning
		/// </summary>
		string[] Labels { get; }
	}
	/// <inheritdoc />
	/// <summary>
	/// Runnable element: must point out its context type
	/// </summary>
	/// <typeparam name="T">Context Type</typeparam>
	public interface IElement<T>: IElement
	{
		/// <summary>
		/// Run the element with state, and get exit return code and a new state.
		/// </summary>
		/// <param name="state">initial state</param>
		/// <param name="ret">exit return code</param>
		/// <returns>Next State</returns>
		T Run(T state, out int ret);
	}
}
