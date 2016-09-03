namespace FeedGrabber.Models
{
    using System;

    public class Article
    {
        public Guid ArticleGUID { get; set; }

        public Guid FeedGUID { get; set; }

        public string ArticleUrl { get; set; }

        public string ArticleTitle { get; set; }

        public string ArticleDescription { get; set; }

        public DateTime PublishedDateTime { get; set; }
    }
}
