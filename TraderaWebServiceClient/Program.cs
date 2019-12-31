using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderaWebServiceClient
{
    class Program
    {
        static class Globals
        {
            public static string collection_name = "categories";
            public static string database_name = "TrMongoDB";
            public static string connection = "mongodb://localhost";
        }
        [STAThread]
        static void Main(string[] args) {
	        try {

                TraderaPublicService publicService = new TraderaPublicService();

                //DateTime officalTraderaTime = publicService.GetOfficalTime();

                //Console.WriteLine("The offical Tradera time is: {0}", officalTraderaTime);
                //Console.ReadLine();

                //publicService.GetCategories();

                TraderaSearchService searchService = new TraderaSearchService();
                searchService.FetchItemsByCategory(344683);
            
                
              

            } catch(Exception exception) {

		        Console.WriteLine("Error: {0}", exception.Message);
		        Console.WriteLine(exception.StackTrace);
		        Console.ReadLine();
	        }
        }

        static void printResult(List<C_CategoryItem> categoryList )
        {
            foreach (var category in categoryList)
            {
                Console.WriteLine($"{ category.categoryId }: {category.name}, toppkategori: {category.topcategory}");
                if (category.subcategories != null)
                {
                    Console.WriteLine("Subkategorier:");
                    foreach (var subcategory in category.subcategories)
                    {
                        Console.WriteLine($"{subcategory}");
                    }
                } 
            }
        }

       
    }
}
