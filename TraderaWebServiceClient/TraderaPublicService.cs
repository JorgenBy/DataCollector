using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Tradera.Category[] categories = this.publicService.GetCategories();

            Console.WriteLine(categories.Length);

            for(int i = 0; i < categories.Length; i++)
            {
                Tradera.Category category = categories[i];

                Console.WriteLine(category.Name);
            }
        }


    }
}
