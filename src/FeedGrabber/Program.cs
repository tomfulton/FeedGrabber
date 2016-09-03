namespace FeedGrabber
{
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            // ensure all configured feeds are in the DB
            DatabaseService.InsertFeeds(DownloadService.GetFeedSources(ConfigurationManager.AppSettings["FeedSourceUrl"]));

            List<Article> newArticles = new List<Article>();


            // get feeds that should be queried for new articles
            foreach (Feed feed in DatabaseService.GetFeeds())
            {
                Console.WriteLine("checking feed: " + feed.FeedUrl);

                // TODO: parallel query
                Article[] fetchedArticles = DownloadService.GetArticles(feed);

                Console.WriteLine("fetched " + fetchedArticles.Count() + " articles");

                Article[] knownArticles = DatabaseService.GetArticles(feed);

                Console.WriteLine("found " + knownArticles.Count() + " known articles");

                // throw away fetched articles that are already known
                newArticles.AddRange(fetchedArticles.Where(x => !knownArticles.Any(y => y.ArticleUrl == x.ArticleUrl)));

            }

            Console.WriteLine("inserting " + newArticles.Count() + " new articles");

            DatabaseService.InsertArticles(newArticles.ToArray());

            Console.ReadKey(true);
        }
    }
}
