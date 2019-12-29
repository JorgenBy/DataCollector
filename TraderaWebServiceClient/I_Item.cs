using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderaWebServiceClient
{
    class I_Item
    {
        public int id { get; set; }
        public string shortdesc { get; set; }
        public int buyItNowPrice { get; set; }
        public int sellerId { get; set; }
        public string sellerAlias { get; set; }
        public int maxBid { get; set; }
        public string thumbnailLink { get; set; }
        public double sellerDsgAverage { get; set; }
        public DateTime endDate { get; set; }
        public int nextbid { get; set; }
        public bool hasBids { get; set; }
        public bool isEnded { get; set; }
        public string itemType { get; set; }
        public int categoryId { get; set; }

        public I_Item()
        {
        }
    }
}
