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


        public void createServices()
        {
            Console.WriteLine("Enter Sevice");
            string serviceName = Console.ReadLine();
            Console.WriteLine("Enter Description");
            string serviceDescription = Console.ReadLine();
            Services serviceOne = new Services(1,serviceName,serviceDescription);
            string path = "C:\\BankRegistration";
            string pathFile = $@"{path}\Service.txt";

            if (File.Exists(pathFile))
            {
                //Check all service declared earlier
              string [] allService =  File.ReadAllLines(pathFile);
                int idVal = allService.Length;
                idVal++;

                //create Service
                File.AppendAllText(pathFile, $"\n{idVal}:{serviceName}:{serviceDescription}");
            }
            else
            {
            
                //Create File
                File.WriteAllText(pathFile,$"1:{serviceName}:{serviceDescription}");
            }

        }

        //Select Services

        public void selectServices()
        {
            string path = "C:\\BankRegistration";
            string pathFile = $@"{path}\Service.txt";
            string[] getServices = File.ReadAllLines(pathFile);
            Console.WriteLine("Choose Service");
            foreach (var item in getServices)
            {
                string[] service = item.Split(":");
                Console.WriteLine($"{service[0]}:{service[1]}");
            }
            Console.WriteLine("00:Cancel");
        }


    }
}
