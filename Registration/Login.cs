using Bank_SyStem.Model;
using Bank_SyStem.Operations;
using Bank_SyStem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Registration
{
    public class Login
    {
   
        public async Task loginUser()
        {
            //enter username
            Console.WriteLine("Login by User Name and Password");
            Console.WriteLine("Enter User Name");
            string userName = Console.ReadLine().ToLower();
            Console.WriteLine("Enter User Passowrd");
            string userPassword = Console.ReadLine().ToLower();
            //Check user in the system if does exist 
            /* string path = "C:\\BankRegistration";
             string pathFile = $@"{path}\userRegistration.txt";*/
            //read file
            /*    string[] members = File.ReadAllLines(pathFile);*/

            //Get the returned array users
            UserService userVal = new UserService();
            List<User> members =  await userVal.GetUsers();
         /*   Console.WriteLine(members);*/
       
            //   string validateUser = $"{userName}:{userPassword}";
         User user = members.Find(x => x.userName == userName && x.userPassword == userPassword);
            Services services = new Services();
            if (user.role == "admin")
            {
                Dictionary<int, string> options = new Dictionary<int, string>();
                options.Add(1, "Check registered Users");
                options.Add(2, "Get One User");
                options.Add(3, "Create Sevice");
                options.Add(00, "Cancel");
                Console.WriteLine("Choose Options");

                foreach (KeyValuePair<int, string> option in options)
                {
                    Console.WriteLine($"{option.Key} : {option.Value}");
                }
               int optionSelc = int.Parse(Console.ReadLine());
                if(optionSelc == 1)
                {
                    //1)Check all users in the application
                    UserService userService = new UserService();
                  List<User> users =  await userService.GetUsers();
                    foreach (var oneUser in users)
                    {
                        Console.WriteLine($"{oneUser.id} : {oneUser.userName} : {oneUser.role}");
                    }

                }
                else if(optionSelc == 2)
                {
                    //2)Get Indivual user



                }else if( optionSelc == 3)
                {
                    //show current services
                    Console.WriteLine("Current Services");
                    ServiceProv allserv = new ServiceProv();
                  List<ServiceProvided> mySevices =  await allserv.GetServices();
                    foreach (var service in mySevices)
                    {
                        Console.WriteLine($"{service.id} : {service.serviceName}");
                    }

                    //Call create service part
                    await services.createServices();

                }                     
            }
            else
            {
                //Check services
                await services.selectServices();
              
            }
/*            if (members.Find(x => x.userName == userName && x.userPassword == userPassword) != null)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Value does not exists");
            }*/
        
            
            //check enterd user if admin or normal user
      /*  string  registeredMember = Array.Find(members, element => element.Contains(validateUser));
            Services serviceOne = new Services();
            if (registeredMember != null)
            //Check role if user is admin or use
            {
                Console.WriteLine(registeredMember);
                string role = registeredMember.Split(':')[3];
                if (role.Equals("admin"))
                {
                    //Allow him to enter various services offerd              
                    serviceOne.createServices();
                }
                else
                {
                    //User to check on services offered
                    serviceOne.selectServices();

                }
            }*/
        }

    }
}
