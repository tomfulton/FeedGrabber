using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            var feeds = GetFeedUrls();

            var downloader = new FeedsDownloader(feeds);

            var articles = downloader.Download();

            foreach (var article in articles)
            {
                Console.WriteLine(article.SourceName + " - " + article.PublicationDate + " - " + article.Title);
            }

            Console.ReadKey(true);

        }

        private static List<Feed> GetFeedUrls()
        {
            return new List<Feed>()
            {
                new Feed() { Name = "Skrift", Url = "http://skrift.io/articles/rss" },
                new Feed() { Name = "Lee", Url = "https://leekelleher.com/feed" }
            };
        }
    }
}
