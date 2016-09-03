namespace FeedGrabber.Models
{
    using System;
    using NPoco;

    [TableName("Feed")]
    public class Feed
    {
        [Column("FeedGUID")]
        public Guid FeedGuid { get; set; }

        [Column("FeedUrl")]
        public string FeedUrl { get; set; }

        [Column("FeedTitle")]
        public string FeedTitle { get; set; }

        [Column("FeedDescription")]
        public string FeedDescription { get; set; }

        [Column("QueryCount")]
        /// <summary>
        /// Number of times this feed has been queried
        /// </summary>
        public int QueryCount { get; set; }

        /// <summary>
        /// The date time of this feed was last queried
        /// </summary>
        [Column("LastQueryDateTime")]
        public DateTime LastQueryDateTime { get; set; }
    }
}
