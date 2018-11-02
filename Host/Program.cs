using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ReadListApp;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ReadListService)))
            {
                host.Open();

                Console.WriteLine("Для завершення нажмiть <Any Key>.");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
