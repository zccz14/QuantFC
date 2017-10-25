using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
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

		public static string ToJson(this object obj, bool pretty = false)
		{
			return JsonConvert.SerializeObject(obj, pretty? Formatting.Indented : Formatting.None);
		}
	}
}
