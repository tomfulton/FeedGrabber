using System;
using System.Xml;

namespace FeedGrabber
{
    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public DateTime PublicationDate { get; set; }

        public string SourceName { get; set; }

        public Article(XmlNode node, string sourceName)
        {
            SourceName = sourceName;

            var titleNode = node.SelectSingleNode("title");
            if (titleNode != null)
                Title = titleNode.InnerText;

            var linkNode = node.SelectSingleNode("link");
            if (linkNode != null)
                Url = linkNode.InnerText;

            var descriptionNode = node.SelectSingleNode("description");
            if (descriptionNode != null)
                Description = descriptionNode.InnerText;

            var pubDate = node.SelectSingleNode("pubDate");
            if (pubDate != null)
                PublicationDate = DateTime.Parse(pubDate.InnerText);
        }
    }
}
