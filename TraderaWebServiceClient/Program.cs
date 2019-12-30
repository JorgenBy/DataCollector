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
            
                DatabaseHandler dbhandler = new DatabaseHandler(Globals.database_name);
                //dbhandler.insertCategory(new C_CategoryItem("testKategori 2", 101));

                if (insertTestCategories(dbhandler))
                {
                    Console.WriteLine("söker ut allt från databasen");
                    var categoryList = dbhandler.findAllDocuments(Globals.collection_name);
                    printResult(categoryList);

                    Console.WriteLine("söker specifik kategori");
                    categoryList = dbhandler.findCategoryById<C_CategoryItem>(Globals.collection_name, 1);
                    printResult(categoryList);
                }

              

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

        /**
         * For testing purposes
         **/
        static bool insertTestCategories(DatabaseHandler dbhandler)
        {
            bool returnVal = false;

            List<C_CategoryItem> list = new List<C_CategoryItem>();

            C_CategoryItem item1 = new C_CategoryItem("Första toppkategorin", 1);
            item1.topcategory = true;
            item1.AddSubCategory(3);
            item1.AddSubCategory(5);

            list.Add(item1);

            C_CategoryItem item2 = new C_CategoryItem("Andra toppkategorin", 2);
            item2.topcategory = true;
            item2.AddSubCategory(6);

            list.Add(item2);

            C_CategoryItem item3 = new C_CategoryItem("under kategori till första toppkategorin", 3);
            item3.AddSubCategory(4);

            list.Add(item3);

            C_CategoryItem item4 = new C_CategoryItem("under kategori till första underkategorin till första toppkategorin", 4);

            list.Add(item4);

            C_CategoryItem item5 = new C_CategoryItem("under kategori till första toppkategorin", 5);

            list.Add(item5);

            C_CategoryItem item6 = new C_CategoryItem("under kategori till första toppkategorin", 6);

            list.Add(item6);

            return dbhandler.insertCategoryList(list, Globals.collection_name);
        }
    }
}
