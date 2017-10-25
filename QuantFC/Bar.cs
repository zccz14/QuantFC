using System;

namespace QuantFCLab {
	public class Bar
	{
		public DateTime DateTime { get; set; }
		public double Open { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public double Close { get; set; }
		public int Volume { get; set; }
		public int OpenInterest { get; set; }
	}
}
