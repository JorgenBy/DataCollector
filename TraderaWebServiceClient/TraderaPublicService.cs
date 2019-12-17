using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TraderaWebServiceClient
{
    class TraderaPublicService
    {
        private string appId = "1886"; // Use your application Id
        private string appServiceKey = "3a850250-09f5-4bbc-8f0c-1e1316c9c493"; // Use your application service key
        private Tradera.PublicService publicService;
        public TraderaPublicService()
        {
            this.publicService = new Tradera.PublicService();
            publicService.Url += string.Format("?appId={0}&appKey={1}", this.appId, this.appServiceKey);
        }

        public Tradera.PublicService GetPublicService()
        {
            return this.publicService;
        }

        public DateTime GetOfficalTime()
        {
            return this.publicService.GetOfficalTime();
        }

        public void GetCategories()
        {
            ArrayList categoryList = new ArrayList();

            // Create arrayList with references to objects inside Arraylist categoryList
            ArrayList AddSubCategories = new ArrayList();
            Tradera.Category[] categories = this.publicService.GetCategories();
           
            //XmlReader rdr = XmlReader.Create(new System.IO.StringReader(ToXML(categories)));
            XmlReader rdr = XmlReader.Create(new System.IO.StringReader(""));
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine(rdr.LocalName);
                    if (rdr.HasAttributes)
                    {
                        // Checks if element is a start element which then have children and adds too categoryList and AddSubCategories Arraylists. 
                        if(rdr.IsStartElement){
                            int id = ToInt(rdr.GetAttribute("Id"));
                            string name = rdr.GetAttribute("Name");
                            Console.WriteLine(rdr.GetAttribute("Id"));
                            Console.WriteLine(rdr.GetAttribute("Name"));
                            C_CategoryItem newItem = new C_CategoryItem(name, id);
                            categoryList.Add(newItem);
                            AddSubCategories.Add(ref categoryList[categoryList.Count - 1]);

                            // MAKE THIS INTO A FUNCTION
                            if(AddSubCategories.Count > 0){
                                foreach (C_CategoryItem obj_Category in AddSubCategories){
                                    obj_Category.Add(id);
                                }
                            }


                        }

                        // Checks if element is single line, which should have no children (No sub categories) and adds to categoryList
                        else if(rdr.IsEmptyElement){
                            int id = ToInt(rdr.GetAttribute("Id"));
                            string name = rdr.GetAttribute("Name");
                            C_CategoryItem newItem = new C_CategoryItem(name, id);
                            categoryList.Add(newItem);

                            // MAKE THIS INTO A FUNCTION ALSO USED IN THE IF RDR.IsStartElement Above
                            if (AddSubCategories.Count > 0)
                            {
                                foreach (C_CategoryItem obj_Category in AddSubCategories)
                                {
                                    obj_Category.Add(id);
                                }
                            }
                        }

                    }
                    
                    // Checks if the element is the end of an element and then removes it from the reference list array AddSubCategories

                    else if (rdr.IsEndElement)
                    {
                        AddSubCategories.RemoveAt(AddSubCategories.Count - 1);
                    }
                }
            }
        }

        public string ToXML(object convertItem)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(convertItem.GetType());
                serializer.Serialize(stringwriter, convertItem);
                return stringwriter.ToString();
            }
        }


        public int ToInt(string intString)
        {
            int number = 0;
            try
            {
                 number = Convert.ToInt32(intString);
            }
            catch (FormatException)
            {
                // the FormatException is thrown when the string text does 
                // not represent a valid integer.
            }
            catch (OverflowException)
            {
                // the OverflowException is thrown when the string is a valid integer, 
                // but is too large for a 32 bit integer.  Use Convert.ToInt64 in
                // this case.
            }

            return number;
        }

    }
}
