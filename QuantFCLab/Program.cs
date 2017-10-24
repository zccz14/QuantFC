using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QuantFC;

namespace QuantFCLab {
	class Program {
		static bool isPrime(int n)
		{
			if (n <= 1) return false;
			for (int i = 2; i * i <= n; i++)
			{
				if (n % i == 0) return false;
			}
			return true;
		}

		static void Main (string[] args) {
			var G = new Graph<int>("Add(x)");
			Commit1(G);
			var i1 = G.Create("is x - 2 a prime?", x => isPrime(x - 2));
			G.SetLink(3, 0, i1);
			G.SetLink(i1, 0, 2);
			for (int i = 0; i < 1000000; i++)
				G.Run(i);
			File.WriteAllText("G.svg", ToSVG(G));
			Process.Start("G.svg");
		}

		private static string ToSVG (Graph<int> G) {
			var dot = new ProcessStartInfo("dot") {
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				Arguments = "-T svg"
			};
			var process = new Process {
				StartInfo = dot
			};
			process.Start();
			process.StandardInput.WriteLine(G.ToDotString());
			process.StandardInput.Close();
			var output = process.StandardOutput.ReadToEnd();
			return output;
		}

		private static void Commit1 (Graph<int> G) {
			var i1 = G.Create("x + 2 is prime?", x => isPrime(x + 2));
			var i2 = G.Create("x := x - 1", x => x - 1);
			var i3 = G.Create("x := x + 1", x => x + 1);
			var i4 = G.Create("x is prime?", x => isPrime(x));
			var i5 = G.Create("No", x => x);
			var i6 = G.Create("Yes", x => x);
			G.SetLink(i1, 0, i2);
			G.SetLink(i1, 0, i3);
			G.SetLink(i4, 0, i5);
			G.SetLink(i4, 1, i6);
			G.DefaultStart = i4;
			G.SetLink(i4, 0, i1);
			G.SetLink(i4, 1, i1);
			G.SetLink(i4, 0, null);
		}

		private static void G_RunningEnded (object sender, Graph<int>.RunningEndedEventArgs e)
		{
			var G = sender as Graph<int>;
			Console.WriteLine($"{e.InitialState} -> {e.FinalState} {e.Path.Select(i => G.Elements[i].Element.Title).Aggregate("", (pre, cur) => pre + $"[{cur}]")}");
		}

	}
}
