using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QuantFC;

namespace QuantFCLab {
	class Program {
		static void Main (string[] args)
		{
			var G = new Graph<Context>("Model");
			var i0 = G.Create("Bar Type", ctx => ctx.Min1.Close.Last() > ctx.Min1.Open.Last());
			
			var i1 = G.Import(new Switch<Context>("当前 K 线类型", ctx => ctx.Min1.Close.Last() > ctx.Min1.Open.Last(),
				ctx => ctx.Min1.Close.Last() < ctx.Min1.Open.Last()));
			G.Elements[i1].Next[0].Label = "阴线";
			G.Elements[i1].Next[1].Label = "阳线";
			G.Elements[i1].Next[2].Label = "十字星";
			G.SetLink(i1, 2, i0);
			G.SetLink(i1, 0, i0);
			G.DefaultStart = i1;
			var importer = new DataImporter();
			var context = new Context();
			importer.Data += (sender, bar) =>
			{
				context.Min1.DateTime.Add(bar.DateTime);
				context.Min1.Open.Add(bar.Open);
				context.Min1.High.Add(bar.High);
				context.Min1.Low.Add(bar.Low);
				context.Min1.Close.Add(bar.Close);
				context.Min1.Volume.Add(bar.Volume);
				context.Min1.OpenInterest.Add(bar.OpenInterest);
				G.Run(context);
			};

			importer.ReadCSV(@"D:\data\rb\min_1.csv");
			Console.WriteLine(G.ToJson(true));
//			Console.WriteLine(context.ToJson());
		}
	}
}
