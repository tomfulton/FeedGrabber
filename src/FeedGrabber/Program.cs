namespace FeedGrabber
{
    using Models;
    using Services;
    using System;
    using System.Linq;

    public class Program
    {
        // TODO: Use config
        private static string _feedSourceUrl = "https://raw.githubusercontent.com/Hendy/OurUmbraco/960919ffa17ed6bcfebe6758d6697cf92b94023a/OurUmbraco.Site/config/CommunityBlogs.config";

        public static void Main(string[] args)
        {
            // get feeds that should be queried for new articles
            foreach(Feed feed in DatabaseService.GetFeeds())
            {
                Console.WriteLine("checking feed: " + feed.FeedUrl);

                // ensure all configured feeds are in the DB
                DatabaseService.InsertOrUpdateFeeds(DownloadService.GetFeedSources(_feedSourceUrl));

                // TODO: parallel query
                Article[] fetchedArticles = DownloadService.GetArticles(feed);

                Console.WriteLine("fetched " + fetchedArticles.Count() + " articles");

                Article[] knownArticles = DatabaseService.GetArticles(feed);

                Console.WriteLine("found " + knownArticles.Count() + " known articles");

                // throw away fetched articles that are already known
                Article[] newArticles = fetchedArticles.Where(x => !knownArticles.Any(y => y.ArticleUrl == x.ArticleUrl)).ToArray();

                Console.WriteLine("inserting " + newArticles.Count() + " new articles");

                DatabaseService.InsertArticles(newArticles);          
            }

            Console.ReadKey(true);
        }
    }
}
