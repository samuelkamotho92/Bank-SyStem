using Bank_SyStem.Model;
using Bank_SyStem.Service.Iservice;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUser = Bank_SyStem.Service.Iservice.IUser;

namespace Bank_SyStem.Service
{
    public class UserService : IUser
    {
        private readonly HttpClient _httpClient;
        private readonly string URL = "http://localhost:3000/users";

        public UserService()
        {
            _httpClient = new HttpClient();
        }


     public async  Task<string> AddUser(AddUser user) 
        {
            Console.WriteLine("Creating User");

            var content = JsonConvert.SerializeObject(user);
            var body = new StringContent(content, Encoding.UTF8, "application/json");
            var resp = await _httpClient.PostAsync(URL, body);
            if (resp.IsSuccessStatusCode)
            {
                return "User registerd successfully";
            }
            return "Not created yet";
        }

        public  async Task<User> GetUser(int id)
        {
            var resp = await _httpClient.GetAsync(URL + "/" + id);
            var content = await resp.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);
            if (resp.IsSuccessStatusCode && user != null)
            {
                return user;
            }
            return user;
        }
        public async Task<List<User>> GetUsers()
        {
           
                //Check out all registered users
                var resp = await _httpClient.GetAsync(URL);
                var content = await resp.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(content);
                if (resp.IsSuccessStatusCode && users != null)
                {
                    return users;
                }
                else
                {
                    Console.WriteLine("something went very wrong");
                }
                return users;
            }
    }
}
