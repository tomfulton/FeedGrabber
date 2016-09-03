using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            var feeds = GetFeedUrls();

            var downloader = new FeedsDownloader(feeds);

            var articles = downloader.Download();

            
        }

        private static List<Feed> GetFeedUrls()
        {
            throw new NotImplementedException();
        }
    }
}
