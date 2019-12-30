using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderaWebServiceClient
{
    class C_CategoryItem
    {
        private string name;
        private int id;
        private int[] subcategories;

        public C_CategoryItem(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public void AddSubCategory(int subId)
        {
            this.subcategories.Append(subId);
        }

        public void writeToHost()
        {
            Console.Write("Category: " + name + " ID: " + id + " SubCategories: ");
            Console.WriteLine(string.Join("\n", subcategories));
        }
    }
}
