using System.Collections.Generic;
using TextMining.DataLoading;
using TextMining.Model;

namespace TextMining
{
    class Program
    {

        static void Main()
        {

            List<News> news = DataStore.Instance.GetAllNews();

            //fetcher.SaveNewsFromFile(news, "newsy.bin");


            //Console.WriteLine("polaczenie ok");

            // preprocessing
            // var fetcher = new DataStore(conn);
            // WordsStats stats = new WordsStats(Words.ComputeWords(fetcher.GetAllNews()));
            // stats.Compute();

            // Console.WriteLine("Words Stats - computed");
            // GroupFactory factory = new GroupFactory(conn);


            //var expr = new FinalExperiment(conn);
            //expr.Run();





            /*
            var exp = new MetricsStatistics(conn);
            exp.Run();
            */
            /*
            var topics = new List<string>();
            //topics.Add(@"http://topics.edition.cnn.com/topics/astronomy");
            //topics.Add(@"http://topics.edition.cnn.com/topics/armed_forces");
            //topics.Add(@"http://topics.edition.cnn.com/topics/genetics");
            topics.Add(@"http://topics.edition.cnn.com/topics/religion");

            Group initialGroup = factory.CreateGroupWithNewsFromTopics(topics);
            CosinusMetricComparator comp = new CosinusMetricComparator();


            var metis = new Metis(stats, comp, conn);

            List<Group> groups = metis.Compute(initialGroup, 4);
            ExperimentStats.PrintDetailsString(groups);
                

                
                
            //Hierarchical algorithm = new Hierarchical(comp, stats, 4000);

            //Dbscan scan = new Dbscan(comp, stats, 1000)p;

            //List<Group> groups = algorithm.Compute(start, 10);

            //ExperimentStats.PrintDetailsString(groups);


            //var assigment = new TopicOriginalAssigment(conn);
            //assigment.Load();

            //DataStore fetcher = new DataStore(conn);
            //List<News> news =  fetcher.GetAllNews();

            //foreach (var info in news)
            //{
                //Console.WriteLine(info.url);
                //Console.WriteLine(assigment.GetTopicsForNews(info.url).Count);
            //}
            //Console.WriteLine("Dost�pne: " + news.Count + " news�w");

            //List<string> topics = fetcher.GetTopicsFromDatabase();

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

