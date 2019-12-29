using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderaWebServiceClient
{
    class TraderaSearchService
    {
        private string appId = "1886"; // Use your application Id
        private string appServiceKey = "3a850250-09f5-4bbc-8f0c-1e1316c9c493"; // Use your application service key
        private readonly TraderaSearch.SearchService searchService;
        private SearchParams searchParams;

        public TraderaSearchService()
        {
            searchService = new TraderaSearch.SearchService();
            searchService.Url += string.Format("?appId={0}&appKey={1}", appId, appServiceKey);
        }

        /* The API is limited to respond with a maximum of 10000 items.Therefore the respond is chosen to be
         * sorted by descending endtime so that the most recent item and the following 9999 is returned.Furthermore is
         * only ended items chosen to limit the response size.
        */
        public List<I_Item> FetchItemsByCategory(int categoryId)
        {
            List<I_Item> itemList = new List<I_Item>();
            //TODO how will the category id be delivered? 
            searchParams = new SearchParams(categoryId);

            /*Not possible to page forward to more then 10000 items so more then
            20 calls is unnecessary (Every page contains 500 items)*/
            int page = 1, maxcalls = 20;

            searchParams.setPagenumber(page);

            while (page < maxcalls)
            {
                try
                {
                    TraderaSearch.SearchResult searchResults = searchService.SearchAdvanced(searchParams.getSearchAdvancedRequest());
                    int numOfPagesFound = searchResults.TotalNumberOfPages;

                    //fetch every item from the returned result
                    foreach (var resultItem in searchResults.Items)
                    {
                        I_Item item = new I_Item();
                        CopyItemFroResult(item, resultItem);
                        //add the new item to the list 
                        itemList.Add(item);
                    }

                    page++;
                    if (page > numOfPagesFound)
                    {
                        break;
                    }
                    else
                    {
                        searchParams.setPagenumber(page);
                    }
                } catch (Exception e)
                {
                    //TODO handle error better
                    Console.WriteLine(e.Message);
                }
                
                
            }
            return itemList;
        }
        
        private void CopyItemFroResult(I_Item item, TraderaSearch.SearchItem resultItem)
        {
            item.id = resultItem.Id;
            item.shortdesc = resultItem.ShortDescription;
            if (resultItem.BuyItNowPrice != null)
            {
                item.buyItNowPrice = (int)resultItem.BuyItNowPrice;
            }
            item.sellerId = resultItem.SellerId;
            item.sellerAlias = resultItem.SellerAlias;
            if (resultItem.MaxBid != null)
            {
                item.maxBid = (int)resultItem.MaxBid;
            }
            item.thumbnailLink = resultItem.ThumbnailLink;
            item.sellerDsgAverage = resultItem.SellerDsrAverage;
            item.endDate = resultItem.EndDate;
            if (resultItem.NextBid != null)
            {
                item.nextbid = (int)resultItem.NextBid;
            }
            item.hasBids = resultItem.HasBids;
            item.isEnded = resultItem.IsEnded;
            item.itemType = resultItem.ItemType;
            item.categoryId = resultItem.CategoryId;
        }

    }
}
