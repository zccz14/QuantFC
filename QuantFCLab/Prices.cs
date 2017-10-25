using System;
using System.Collections.Generic;

namespace QuantFCLab
{
	class Prices
	{
		public List<DateTime> DateTime { get; } = new List<DateTime>();
		public List<double> Open { get; } = new List<double>();
		public List<double> High { get; } = new List<double>();
		public List<double> Low { get; } = new List<double>();
		public List<double> Close { get; } = new List<double>();
		public List<int> Volume { get; } = new List<int>();
		public List<int> OpenInterest { get; } = new List<int>();
	}
}