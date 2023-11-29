using Bank_SyStem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Service.Iservice
{
    internal interface IServiceProvider
    {
        Task<List<ServiceProvided>> GetServices();

        Task<string> AddService(AddService service);

        Task<ServiceProvided> GetService(int id);
    }
}
