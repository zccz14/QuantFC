using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using QuantTC;
using static QuantTC.Functions;
using Formatting = Newtonsoft.Json.Formatting;

namespace QuantFC {
	public static partial class GraphX
	{
		public static void SetLink<T>(this Graph<T> graph, int from, int order, int? to)
		{
			graph.Elements[from].Next[order].Index = to;
		}

		public static void SetLink<T>(this Graph<T>.GraphElement e, int order, int? to)
		{
			e.Next[order].Index = to;
		}

		/// <summary>
		/// Import an element and allocate Graph Element ID for it
		/// </summary>
		/// <typeparam name="T">Context Type</typeparam>
		/// <param name="graph">Graph (container)</param>
		/// <param name="element">Element to import</param>
		/// <returns>Graph Element ID</returns>
		public static int Import<T>(this Graph<T> graph, IElement<T> element)
		{
			graph.Elements.Add(new Graph<T>.GraphElement(element, graph));
			return graph.Count - 1;
		}

		/// <summary>
		/// Paste Nexts' Index to a graph element by order
		/// </summary>
		/// <typeparam name="T">Context Type</typeparam>
		/// <param name="e">Graph Element as 'from' node</param>
		/// <param name="nexts">indices (null for no link)</param>
		public static void Paste<T>(this Graph<T>.GraphElement e, params int?[] nexts)
		{
			Range(0, nexts.Length).ForEach(i => e.Next[i].Index = nexts[i]);
		}

		/// <summary>
		/// JSON Serialization
		/// </summary>
		/// <param name="obj">An object to serialize</param>
		/// <param name="pretty">Need pretty printed? </param>
		/// <returns>JSON String</returns>
		public static string ToJson(this object obj, bool pretty = false)
		{
			return JsonConvert.SerializeObject(obj, pretty? Formatting.Indented : Formatting.None);
		}

		public static void Save<T>(this Graph<T> graph, Func<Graph<T>, string> filenameFunc)
		{
			graph.Save(filenameFunc(graph));
		}

		public static void Save<T>(this Graph<T> graph, string filename)
		{
			File.WriteAllText(filename, graph.ToDotString());
		}

		public static void Save<T>(this Graph<T> graph)
		{
			graph.Save($"{graph.Title}.dot");
		}
	}
}
