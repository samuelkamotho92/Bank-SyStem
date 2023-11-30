using Bank_SyStem.Model;
using Bank_SyStem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Operations
{
    public class Services
    {
        //Create Services
        private int serviceId {  get; set; }
        private string serviceName { get; set; }

        private string serviceDescription { get; set; }


        public Services()
        {

        }
        public Services(int serviceId , string serviceName, string serviceDescription)
        {
            this.serviceId = serviceId;
            this.serviceName = serviceName;
            this.serviceDescription = serviceDescription;
        }


        public async Task createServices()
        {
            Console.WriteLine("Enter Sevice");
            string serviceName = Console.ReadLine();
            Console.WriteLine("Enter Description");
            string serviceDescription = Console.ReadLine();

            AddService service = new AddService();
            service.serviceName = serviceName;
            service.serviceDescription = serviceDescription;

            //pass them to service class
           ServiceProv service1 = new ServiceProv();
           await service1.AddService(service);
        }

        //Select Services

        public async Task selectServices()
        {
            Console.WriteLine("Choose Service");
            ServiceProv service1 = new ServiceProv();
          List <ServiceProvided> services  = await service1.GetServices();
            foreach (var service in services)
            {
                Console.WriteLine($"{service.id} : {service.serviceName}");
            }
            /* foreach (var item in getServices)
             {
                 string[] service = item.Split(":");
                 Console.WriteLine($"{service[0]}:{service[1]}");
             }
             Console.WriteLine("00:Cancel");*/
        }


    }
}
