using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraderaWebServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraderaWebServiceClient.Tests
{
    static class Globals
    {
        public static string collection_name = "categories";
        public static string database_name = "TrMongoDB_Testing";
        public static string connection = "mongodb://localhost";
    }
    [TestClass()]
    public class DatabaseHandlerTests
    {
        /* 
         * These methods can be used to set up the test environment if needed 
         */
        //[AssemblyInitialize()]
        //public static void AssemblyInit(TestContext context)
        //{
        //    MessageBox.Show("AssemblyInit " + context.TestName);
        //}

        //[ClassInitialize()]
        //public static void ClassInit(TestContext context)
        //{
        //    MessageBox.Show("ClassInit " + context.TestName);
        //}

        //[TestInitialize()]
        //public void Initialize()
        //{
        //    MessageBox.Show("TestMethodInit");
        //}

        //[TestMethod()]
        //public void DivideMethodTest()
        //{
        //    MessageBox.Show("TestMethod");
        //}

        [TestMethod()]
        public void CreateDatabasehandlerTest()
        {
            DatabaseHandler databaseHandler = null;
            databaseHandler = new DatabaseHandler(Globals.database_name, Globals.connection);
            Assert.IsNotNull(databaseHandler);
        }

        [TestMethod()]
        public void InsertCategoryTest()
        {
            DatabaseHandler dbhandler = new DatabaseHandler(Globals.database_name, Globals.connection);

            bool returnVal = insertTestCategories(dbhandler);

            Assert.IsTrue(returnVal);

            /*if (insertTestCategories(dbhandler))
            {
                Console.WriteLine("söker ut allt från databasen");
                var categoryList = dbhandler.FindAllDocuments(Globals.collection_name);
                printResult(categoryList);

                Console.WriteLine("söker specifik kategori");
                categoryList = dbhandler.FindCategoryById(Globals.collection_name, 1);
                printResult(categoryList);
            }*/


        }

        /**
         * For testing purposes
        **/
        static bool insertTestCategories(DatabaseHandler dbhandler)
        {
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

            return dbhandler.InsertCategoryList(list, Globals.collection_name);
        }


        /*
         * These methods can be used to clean up after testing (clean the database etc) 
         */
        //[TestCleanup()]
        //public void Cleanup()
        //{
        //    MessageBox.Show("TestMethodCleanup");
        //}


        /*
         * Removes inserted items from the test database
         */
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //MessageBox.Show("ClassCleanup");
            DatabaseHandler databaseHandler = null;
            databaseHandler = new DatabaseHandler(Globals.database_name, Globals.connection);

            databaseHandler.CleanDatabase(Globals.collection_name);
        }

        //[AssemblyCleanup()]
        //public static void AssemblyCleanup()
        //{
        //    MessageBox.Show("AssemblyCleanup");
        //}
    }
}