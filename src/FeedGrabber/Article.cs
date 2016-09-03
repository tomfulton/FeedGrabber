using System.Xml;

namespace FeedGrabber
{
    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }

        public string SourceName { get; set; }

        public Article(XmlNode node)
        {
            var titleNode = node.SelectSingleNode("title");
            if (titleNode != null)
                Title = titleNode.Value;

            var linkNode = node.SelectSingleNode("link");
            if (linkNode != null)
                Url = linkNode.Value;

            var descriptionNode = node.SelectSingleNode("description");
            if (descriptionNode != null)
                Description = descriptionNode.Value;
        }
    }
}
