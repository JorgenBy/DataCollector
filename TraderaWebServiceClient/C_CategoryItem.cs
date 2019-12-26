using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        public string name { get; set; }

        [BsonId]
        public int categoryId { get; set; }
        public ArrayList subcategories;
        public bool topcategory { get; set; } 

        public C_CategoryItem(string name, int id)
        {
            this.name = name;
            this.categoryId = id;
            subcategories = null;
            topcategory = false;
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
