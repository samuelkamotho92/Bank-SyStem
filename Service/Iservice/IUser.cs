using Bank_SyStem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Service.Iservice
{
    public interface IUser
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);

        Task<string> AddUser(AddUser user);
    }
}
