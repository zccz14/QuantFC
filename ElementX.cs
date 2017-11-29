namespace QuantFC
{
	/// <summary>
	/// Element Extension
	/// </summary>
	public static class ElementX
	{
		/// <summary>
		/// Inject the element into the graph
		/// </summary>
		/// <typeparam name="T">Context Type</typeparam>
		/// <param name="element">The element to be injected</param>
		/// <param name="graph">The graph to inject</param>
		/// <returns>The handle of graph element in the graph</returns>
		public static int Inject<T>(this IElement<T> element, Graph<T> graph) => graph.Import(element);
	}
}