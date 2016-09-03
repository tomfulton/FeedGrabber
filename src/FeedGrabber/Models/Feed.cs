namespace FeedGrabber.Models
{
    using System;

    public class Feed
    {
        public Guid FeedGuid { get; set; }

        public string FeedUrl { get; set; }

        public string FeedTitle { get; set; }

        public string FeedDescription { get; set; }

        /// <summary>
        /// Number of times this feed has been queried
        /// </summary>
        public int QueryCount { get; set; }

        /// <summary>
        /// The date time of this feed was last queried
        /// </summary>
        public DateTime LastQueryDateTime { get; set; }
    }
}
