namespace FeedGrabber.Services
{
    using System;
    using Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml;

    internal static class DownloadService
    {
        /// <summary>
        /// Queries the feed, and downloads all articles found
        /// </summary>
        /// <param name="feed"></param>
        /// <returns></returns>
        internal static Article[] GetArticles(Feed feed)
        {
            List<Article> articles = new List<Article>();

            WebRequest webRequest = WebRequest.Create(feed.FeedUrl);

            // TODO: flag if feed url not working


            WebResponse webResponse = webRequest.GetResponse();

            Stream stream = webResponse.GetResponseStream();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(stream);

            // TODO: flag if xml document invalid

            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("rss/channel/item");

            foreach(XmlNode xmlNode in xmlNodeList)
            {
                articles.Add(new Article()
                {
                    ArticleGUID =  Guid.NewGuid(),
                    FeedGUID = feed.FeedGuid,
                    ArticleRemoteID = SelectSingleNodeValue<string>(xmlNode, "guid"),
                    ArticleUrl = SelectSingleNodeValue<string>(xmlNode, "link"),
                    ArticleTitle = SelectSingleNodeValue<string>(xmlNode, "title"),
                    ArticleDescription = SelectSingleNodeValue<string>(xmlNode, "description"),
                    PublishedDateTime = SelectSingleNodeValue<DateTime>(xmlNode, "pubDate"),
                });
            }


            return articles.ToArray();
        }

        /// <summary>
        /// Gets the configured feed sources from the public list
        /// </summary>
        /// <param name="listUrl">The url of the XML file containing the feed sources</param>
        /// <returns></returns>
        internal static string[] GetFeedSources(string listUrl)
        {
            WebRequest webRequest = WebRequest.Create(listUrl);

            WebResponse webResponse = webRequest.GetResponse();

            Stream stream = webResponse.GetResponseStream();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(stream);

            XmlNodeList rssNodes = xmlDocument.SelectNodes("//Rss");

            var urls = new List<string>();
            foreach (XmlNode node in rssNodes)
            {
                urls.Add(node.Attributes["url"].Value);
            }

            return urls.ToArray();
        }

        private static T SelectSingleNodeValue<T>(XmlNode xmlNode, string xpath)
        {
            XmlNode selectedNode = xmlNode.SelectSingleNode(xpath);
            string selectedNodeValue = selectedNode?.InnerText;

            if (typeof(T) == typeof(DateTime))
            {
                DateTime dateTime;

                if (DateTime.TryParse(selectedNodeValue, out dateTime))
                {
                    return (T)(object)dateTime;
                }

                return (T)(object)DateTime.MinValue;
            }

            return (T)(object)selectedNodeValue;
        }
    }
}
