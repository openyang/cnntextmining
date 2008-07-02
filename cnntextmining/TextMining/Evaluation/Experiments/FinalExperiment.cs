﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TextMining.DataLoading;
using TextMining.TextTools;
using TextMining.Model;
using TextMining.Clustering;
using TextMining.Evaluation.ClusteringMeasures;

namespace TextMining.Evaluation.Experiments
{
    class FinalExperiment : IExperiment
    {
        public void Run()
        {
            //int newsToExperiment = 1000;
            int randomTopicsCounter = 8;
            int maxLen = 2000;
            int kMeansIt = 3;

            WordsStats stats = new WordsStats(Words.ComputeWords(DataStore.Instance.GetAllNews()));
            stats.Compute();

            Console.WriteLine("Words Stats - computed");
            List<string> randomTopics = getRandomTopics(randomTopicsCounter);


            foreach (string s in randomTopics)
                Console.WriteLine(s);



            Group initialGroup = GroupFactory.CreateGroupWithNewsFromTopics(randomTopics);

            Console.WriteLine("Rozmiar grupy: " + initialGroup.Count);
            CosinusMetricComparator cos = new CosinusMetricComparator();
            EuclidesMetricComparator eu = new EuclidesMetricComparator();
            JaccardMetricCompartator ja = new JaccardMetricCompartator();

            Dbscan db = new Dbscan(cos, stats, maxLen);
            Hierarchical hr = new Hierarchical(cos, stats, maxLen);
            Kmeans km = new Kmeans(cos, stats, maxLen);

            //List<Group> dbscanResult = db.Compute(initialGroup, 0.25, 3);
            List<Group> hierarchicalResult = hr.Compute(initialGroup,randomTopicsCounter, Hierarchical.Distance.AVG);
            List<Group> kMeansResult = km.Compute(initialGroup, randomTopicsCounter, kMeansIt);


            IGroupEvaluator groupEvaluator = new MedianCoverageForDominanceTopic();

            Console.WriteLine("kmeans srednia dominacja = " + groupEvaluator.Eval(kMeansResult));
            Console.WriteLine("hierarchical srednia dominacja = " + groupEvaluator.Eval(hierarchicalResult));

            HighRelatedTopics htopics = new HighRelatedTopics(hierarchicalResult);
            List<string[]> related = htopics.getHighRelatedTopics(8);

            foreach(string[] pair in related)
            {
                Console.WriteLine(pair[0] + "\n" + pair[1] + "\n");
            }


            //ExperimentStats.PrintDetailsString(dbscanResult);
            //ExperimentStats.PrintDetailsString(hierarchicalResult);
            //ExperimentStats.PrintDetailsString(kMeansResult);


        }

        private List<string> getRandomTopics(int size)
        {
            List<News> news = DataStore.Instance.GetAllNews();

            var result = new List<string>();
            var rand = new Random();


            while (result.Count < size)
            {
                int x = rand.Next(news.Count);
                string topic = news[x].topicUrl;
                if (!result.Contains(topic))
                {
                    result.Add(topic);
                }
            }
            return result;
        }


    }
}
