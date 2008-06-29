using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TextMining.Clastering;
using TextMining.Evaluation;
using TextMining.TextTools;
using DataFetcher=TextMining.DataLoading.DataFetcher;

namespace TextMining
{
    class Program
    {
        private const string connectionString =
         @"Data Source=NEVERLAND\SQLEXPRESS;Initial Catalog=TextMiningNew;user=marek;password=marek";

        static void Main()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // preprocessing
                var fetcher = new DataFetcher(conn);
                WordsStats stats = new WordsStats(Words.ComputeWords(fetcher.GetAllNews()));
                stats.Compute();

                Console.WriteLine("Words Stats - computed");
                GroupFactory factory = new GroupFactory(conn);

                var topics = new List<string>();
                topics.Add(@"http://topics.edition.cnn.com/topics/weather");
                topics.Add(@"http://topics.edition.cnn.com/topics/terrorism");
                //topics.Add(@"http://topics.edition.cnn.com/topics/genetics");
                //topics.Add(@"http://topics.edition.cnn.com/topics/religion");

                Group start = factory.CreateGroupWithNewsFromTopics(topics);

                Console.WriteLine("Przed usuni�ciem duplikat�w: " + start.Count);
                start.RemoveDuplicates();
                Console.WriteLine("Po usuni�ciu duplikat�w: " + start.Count);

                CosinusMetricComparator comp = new CosinusMetricComparator();
                //Kmeans algorithm = new Kmeans(comp, stats, 4000);
                //List<Group> groups = algorithm.Compute(start, 4, 10);

                Hierarchical h = new Hierarchical(comp, stats, 4000);

                List<Group> groups = h.Compute(start, 2);

                ExperimentStats.PrintDetailsString(groups);


                //var assigment = new TopicOriginalAssigment(conn);
                //assigment.Load();

                //DataFetcher fetcher = new DataFetcher(conn);
                //List<News> news =  fetcher.GetAllNews();

                //foreach (var info in news)
                //{
                    //Console.WriteLine(info.url);
                    //Console.WriteLine(assigment.GetTopicsForNews(info.url).Count);
                //}
                //Console.WriteLine("Dost�pne: " + news.Count + " news�w");

                //List<string> topics = fetcher.GetTopics();

                //Console.WriteLine("Liczba topik�w: " + topics.Count);
                


                //var exp1 = new Experiment1(conn);
                //exp1.Run();

                //var exp2 = new Experiment_DBSCAN(conn);
                //exp2.Run();

                /*CNNPage page = new CNNPage("http://edition.cnn.com/2003/TECH/space/07/30/sprj.colu.columbia.probe/index.html");

                Console.WriteLine(page.pureText);
                Console.WriteLine();
                foreach(Uri link in page.allLinks)
                    Console.WriteLine(link);

                */

            }
        }
    }
}
