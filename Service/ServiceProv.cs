using Bank_SyStem.Model;
using Bank_SyStem.Service.Iservice;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Service
{
    public class ServiceProv : Iservice.IServiceProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string URL = "http://localhost:3000/services";

        public ServiceProv()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> AddService(AddService service)
        {
            
            var content = JsonConvert.SerializeObject(service);
            var body = new StringContent(content,Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(URL,body);
            if (response.IsSuccessStatusCode)
            {
                return "successfully created service";
            }
            return "";
        }

        public Task<ServiceProvided> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceProvided>> GetServices()
        {
            throw new NotImplementedException();
        }
    }
}
