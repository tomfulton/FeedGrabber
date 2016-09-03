namespace FeedGrabber.Services
{
    using Models;
    using System.Linq;
    using System;

    internal static class DatabaseService
    {
        /// <summary>
        /// Gets a collection of known feeds from the database (that haven't yet been queried today)
        /// </summary>
        /// <returns></returns>
        internal static Feed[] GetFeeds()
        {
            Feed[] feeds = new Feed[] {
                new Feed() { FeedGuid = new Guid("48315D63-B6A6-40CB-BDAE-7696BC9B1AC0"), FeedTitle = "Skrift", FeedUrl = "http://skrift.io/articles/rss"  },
                new Feed() { FeedGuid = new Guid("21102F3C-DDAE-4E05-8242-04063D9A4EFD"), FeedTitle = "Lee", FeedUrl = "https://leekelleher.com/feed" }
            };

            return feeds;
        }

        internal static Article[] GetArticles(Feed feed)
        {
            return new Article[] { };
        }

        /// <summary>
        /// Inserts new articles into the database, and update the last query datetime in feed table
        /// </summary>
        /// <param name="articles">collection of articles for a feed - some (or all) of which may already be in the database</param>
        internal static void InsertArticles(Article[] articles)
        {
            if (articles.Any())
            {

                // TODO: insert

            }
        }

    }
}
