using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace FeedGrabber
{
    public class FeedsDownloader
    {
        private List<Feed> _feeds;

        public FeedsDownloader(List<Feed> feeds)
        {
            _feeds = feeds;
        }

        public List<Article> Download()
        {
            var allArticles = new List<Article>();

            foreach (var feed in _feeds)
            {
                var articlesFromFeed = DownloadFromFeed(feed);
                allArticles.AddRange(articlesFromFeed);
            }

            return allArticles;
        }

        private List<Article> DownloadFromFeed(Feed feed)
        {
            var request = WebRequest.Create(feed.Url);
            var response = request.GetResponse();

            var stream = response.GetResponseStream();

            var rssDoc = new XmlDocument();
            rssDoc.Load(stream);

            var rssItems = rssDoc.SelectNodes("rss/channel/item");

            var result = new List<Article>();
            foreach (XmlNode rssItem in rssItems)
            {
                result.Add(new Article(rssItem));
            }
            return result;
        }

    }
}
