using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderaWebServiceClient
{
    class Program
    {
            [STAThread]
        static void Main(string[] args) {

	        try {

                TraderaPublicService publicService = new TraderaPublicService();

                //DateTime officalTraderaTime = publicService.GetOfficalTime();
		 
 		        //Console.WriteLine("The offical Tradera time is: {0}", officalTraderaTime);
 		        //Console.ReadLine();

                publicService.GetCategories();

	        } catch(Exception exception) {

		        Console.WriteLine("Error: {0}", exception.Message);
		        Console.WriteLine(exception.StackTrace);
		        Console.ReadLine();
	        }
        }
    }
}
