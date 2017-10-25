using System.Linq;

namespace QuantFCLab
{
	class Context
	{
		public Prices Min1 { get; } = new Prices();
		public double Close => Min1.Close.Last();
	}
}