using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace RestHost
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(RentalService.RentalServiceTest),
                new Uri("http://localhost:8080"));

            ServiceEndpoint endpoint = host.AddServiceEndpoint(
                typeof(RentalService.IRestService), new WebHttpBinding(), "http://localhost:8080");

            host.Description.Endpoints[0].Behaviors.Add(
                new WebHttpBehavior { HelpEnabled = true });

            ServiceDebugBehavior debug = host.Description.Behaviors.Find<ServiceDebugBehavior>();

            debug.IncludeExceptionDetailInFaults = true;

            host.Open();
            Console.WriteLine("Service is running: " + DateTime.Now);
            Console.ReadLine();
            host.Close();
        }
    }
}
