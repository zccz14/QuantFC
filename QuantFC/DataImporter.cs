using System;
using System.IO;
using System.Linq;

namespace QuantFCLab
{
	public class DataImporter
	{
		public event EventHandler<Bar> Data;

		public void ReadCSV(string filename, bool hasTitle = true)
		{

			foreach (var line in File.ReadAllLines(filename).Skip(hasTitle? 1: 0))
			{
				var data = line.Split(',');
				Data?.Invoke(this, new Bar()
				{
					DateTime = DateTime.Parse(data[0]),
					Open = double.Parse(data[1]),
					High = double.Parse(data[2]),
					Low = double.Parse(data[3]),
					Close = double.Parse(data[4]),
					Volume = int.Parse(data[5]),
					OpenInterest = int.Parse(data[6])
				});
			}
		}
	}
}