using System;
using TextMining.Evaluation;
using TextMining.Evaluation.Experiments;

namespace TextMining
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 5)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("CNN TextMining v.1.0.0 - Authors: Marcin Go��biowski, Marek Chru�ciel");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Usage: TextMining.exe (<numer of topics>|<list of topics>) <kmeans iteration> <numer of releated> <metric> <onlykmeans>");
                Console.WriteLine("   <numer of topics>:  positive integer");
                Console.WriteLine("   <number of kmeans iteration>:  positive integer");
                Console.WriteLine("   <numer of releated>: positeve integer");
                Console.WriteLine("   <metric>:  0 - Euclides, 1 - Cosinus, 2 - Jaccard ");
                Console.WriteLine("   <onlykmeans>:  0,1 ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Examples: TextMining.exe 10 5 2 1 1");
                Console.WriteLine("          TextMining.exe \"http://topics.edition.cnn.com/topics/software;http://topics.edition.cnn.com/topics/vacations\" 5 2 1");
                return;
            }

            uint a, b, c;
            ushort d;
            int e;

            if (!UInt32.TryParse(args[1], out b))
            {
                Console.WriteLine("Second argument is not a positive number");
                return;
            }

            if (!UInt32.TryParse(args[2], out c))
            {
                Console.WriteLine("Third argument is not a positive number");
                return;
            }

            if (!ushort.TryParse(args[3], out d) )
            {

                Console.WriteLine("Third argument is not number");
                return;
            }
                if (!int.TryParse(args[4], out e) && e != 1 && e!= 0)
            {
                Console.WriteLine("Third argument is not 0 or 1");
                return;
            }

            IExperiment exp;
            if (!UInt32.TryParse(args[0], out a))
            {
                exp = new FinalExperiment(e == 1, args[0].Split(';'), b, c, d);
            }
            else
            {
                exp = new FinalExperiment(e == 1, a, b, c, d);
            }

            exp.Run();
        }
    }
}

