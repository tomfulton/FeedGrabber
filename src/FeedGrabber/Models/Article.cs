namespace FeedGrabber.Models
{
    using System;
    using NPoco;

    [TableName("Article")]
    public class Article
    {
        [Column("ArticleGUID")]
        public Guid ArticleGUID { get; set; }

        [Column("FeedGUID")]
        public Guid FeedGUID { get; set; }

        /// <summary>
        /// 'guid' from the rss feed item
        /// </summary>
        [Column("ArticleRemoteID")]
        public string ArticleRemoteID { get; set; }

        [Column("ArticleURL")]
        public string ArticleUrl { get; set; }

        [Column("ArticleTitle")]
        public string ArticleTitle { get; set; }

        [Column("ArticleDescription")]
        public string ArticleDescription { get; set; }

        [Column("PublishedDateTime")]
        public DateTime PublishedDateTime { get; set; }
    }
}
