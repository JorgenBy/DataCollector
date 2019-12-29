using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderaWebServiceClient
{
    class SearchParams
    {
        private TraderaSearch.SearchAdvancedRequest searchAdvancedRequest;

        /**
        * Create all needed parameters for the API call
        **/
        public SearchParams(int categoryId)
        {
            searchAdvancedRequest = new TraderaSearch.SearchAdvancedRequest();
            if (searchAdvancedRequest != null)
            {
                searchAdvancedRequest.CategoryId = categoryId; /*  The Id of the category to search in (0 for all categories). See the method GetCategories for a list.*/
                searchAdvancedRequest.PageNumber = 0; /*  The page to return, starting with 1 for the first page.*/


                searchAdvancedRequest.SearchInDescription = false; /*  If the search should include the Item description as well as the title.*/
                searchAdvancedRequest.SearchWords = "**"; /* The keywords to search for. */
                searchAdvancedRequest.Mode = null;  /* Whether to require hits on all specified words, or just any of them.
                                                    Possible values:
                                                    "Or" - must match one of the search words.
                                                    "Exact" - must match search words exactly.
                                                    "And" - must include all search words (default).*/
                searchAdvancedRequest.PriceMinimum = null; /*  The lower boundary of the price range to search in. Set to NULL or 0 for no lower boundary.*/
                searchAdvancedRequest.PriceMaximum = null;/*  The upper boundary of the price range to search in. Set to NULL or 0 for no upper boundary.*/
                searchAdvancedRequest.BidsMinimum = null;/*  The lowest number of bids that an Item can have and still be included in the search result. Set to NULL or 0 for no lower limit.*/
                searchAdvancedRequest.BidsMaximum = null;/*  The highest number of bids that an Item can have and still be included in the search result. Set to NULL or 0 for no upper limit.*/
                searchAdvancedRequest.ZipCode = null;/*  Search for items within zip codes starting with this string (maximum 5 characters). Mutually exclusive with CountyId.*/
                searchAdvancedRequest.CountyId = 0;/*  Search for items within this county. Mutually exclusive with ZipCode. See the method GetCounties for a list.*/
                searchAdvancedRequest.Alias = null; /*  Only include items from the user with this alias. Set to NULL for all users.*/
                searchAdvancedRequest.OrderBy = "StartDateDescending"; /*  How the search results should be sorted.
                                                                        Possible values:
                                                                        "Relevance" - order by relevance (default).
                                                                        "BidsAscending" - order by bid amount ascending.
                                                                        "BidsDescending" - order by bid amount descending.
                                                                        "PriceAscending" - order by price ascending.
                                                                        "PriceDescending" - order by price descending.
                                                                        "EndDateAscending" - order by end date ascending.
                                                                        "EndDateDescending" - order by end date descending.
                                                                        "StartDateDescending" - order by start date descending. -- Choose this one for long term usage
                                                                        "DsrAverage" - order by sellers dsr-average.*/
                searchAdvancedRequest.ItemStatus = "Ended"; /*  The status of the items to include.
                                                            Possible values:
                                                            "Ended" - item is ended.
                                                            "Active" - item is in progress (default).*/
                searchAdvancedRequest.ItemType = "All"; /*  The type of item to return.
                                                        Possible values:
                                                        "All" - all items (default).
                                                        "Auction" - auction item.
                                                        "BuyItNow" - fixed price item. */
                searchAdvancedRequest.OnlyAuctionsWithBuyNow = false; /*  If only auctions with a Buy Now price should be returned. */
                searchAdvancedRequest.OnlyItemsWithThumbnail = false; /*  If only items with a thumbnail picture should be returned. */
                searchAdvancedRequest.ItemsPerPage = 500; /*  The number of items to return per page. Maximum value is 500 and values > 500 will be regarded as 500.*/
                /*searchAdvancedRequest.ItemCondition = "All"; /*  Define the condition requirements (new/used)
                                                                Possible values:
                                                                "All" - must match one of the search words (default).
                                                                "OnlySecondHand" - must match search words exactly.
                                                                "OnlyNew" - must include all search words.
                searchAdvancedRequest.SellerType = "All"; /* Define the seller requirements (private/business)
                                                            Possible values:
                                                            "All" - includes both private and company sellers (default).
                                                            "Private" - only private sellers.
                                                            "Company" - only company sellers.*/
                searchAdvancedRequest.Brands = null; /*  Filter by brands
                                                     Possible values are a predefined set of brand names formatted as 'brand_odd_molly', for example. */
            }
        }

        public TraderaSearch.SearchAdvancedRequest getSearchAdvancedRequest()
        {
            return this.searchAdvancedRequest;
        }

        public void setPagenumber(int page)
        {
            searchAdvancedRequest.PageNumber = page;
        }

        public void setCategoryId(int categoryId)
        {
            searchAdvancedRequest.CategoryId = categoryId;
        }

    }
}
