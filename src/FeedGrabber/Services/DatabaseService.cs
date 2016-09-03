namespace FeedGrabber.Services
{
    using Models;
    using NPoco;
    using System;
    using System.Linq;

    internal static class DatabaseService
    {
        /// <summary>
        /// TODO: mark feed as disabled if it's no longer in the source
        /// </summary>
        /// <param name="feedUrls">collection of urls that should be in the database</param>
        internal static void InsertFeeds(string[] feedUrls)
        {

            if (feedUrls.Any())
            {
                Feed[] knownfeeds = DatabaseService.GetFeeds();

                string[] unknownFeedUrls = feedUrls.Where(x => !knownfeeds.Any(y => y.FeedUrl == x)).ToArray();

                // TODO: transaction

                foreach (string unknownUrl in unknownFeedUrls)
                {
                    DatabaseService.GetDatabase().Insert<Feed>(new Feed()
                    {
                        FeedGuid = Guid.NewGuid(),
                        FeedUrl = unknownUrl,
                        FeedTitle = "unknown",
                        FeedDescription = "unknown",

                    });

                }
            }
        }

        /// <summary>
        /// Gets a collection of known feeds from the database (that haven't yet been queried today)
        /// </summary>
        /// <returns></returns>
        internal static Feed[] GetFeeds()
        {
            // TODO: filter out

            return DatabaseService.GetDatabase().Fetch<Feed>().ToArray();
        }

        internal static Article[] GetArticles(Feed feed)
        {
            return DatabaseService.GetDatabase().Fetch<Article>().ToArray();
        }

        /// <summary>
        /// Inserts new articles into the database, and update the last query datetime in feed table
        /// </summary>
        /// <param name="articles">collection of articles for a feed - some (or all) of which may already be in the database</param>
        internal static void InsertArticles(Article[] articles)
        {
            if (articles.Any())
            {
                DatabaseService.GetDatabase().InsertBulk(articles);
            }
        }

        /// <summary>
        /// Get a NPoco reference to the database
        /// </summary>
        /// <returns></returns>
        private static Database GetDatabase()
        {
            return new Database("DatabaseConnectionString");
        }
    }
}
