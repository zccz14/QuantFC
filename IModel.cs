using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantFC
{
	/// <summary>
	/// Model
	/// </summary>
	public interface IModel<T>
	{
		/// <summary>
		/// 获取所有的流程图
		/// </summary>
		/// <returns></returns>
		IEnumerable<Graph<T>> Graphs { get; }
	}
}
