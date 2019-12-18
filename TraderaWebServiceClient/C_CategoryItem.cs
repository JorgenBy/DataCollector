using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderaWebServiceClient
{
    class C_CategoryItem
    {
        private string name { get; set; }
        private int id { get; set; }
        private ArrayList subcategories;

        public C_CategoryItem(string name, int id)
        {
            this.name = name;
            this.id = id;
            subcategories = null;
        }

        public void AddSubCategory(int subId)
        {
            if(subcategories == null)
            {
                subcategories = new ArrayList();
            }
            subcategories.Add(subId);
        }

        public ArrayList GetSubcategories()
        {
            if(subcategories != null)
            {
                return subcategories;
            }

            return null;
        }
    }
}
