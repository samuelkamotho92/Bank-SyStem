using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Registration
{
    public class Login
    {
        public void loginUser()
        {
            //enter username
            Console.WriteLine("Login by User Name and Password");
            Console.WriteLine("Enter User Name");
            string userName = Console.ReadLine().ToLower();
            //Check user in the system if does exist 
            string path = "C:\\BankRegistration";
            string pathFile = $@"{path}\userRegistration.txt";
            //read file
            string[] members = File.ReadAllLines(pathFile);
            foreach (string member in members)
            {
                string name = member.Split(':')[0].ToLower();
                string password = member.Split(":")[1].ToLower();
                //Comapre with the value we are entering
                if (name.Equals(userName))
                {
                    //Allow user to enter password
                    Console.WriteLine("Enter User Passowrd");
                    string userPassword = Console.ReadLine().ToLower();
                if(userPassword.Equals(password))
                    {
                        Console.WriteLine("Logged In successfully");
                        Console.WriteLine($"Welcome back user {userName}");
                    break;
                    }
                    else
                    {
                        Console.WriteLine("User password is incorrect");
                        loginUser();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Email is incorrect");
                    loginUser();
                    break;
                }
            }
            //Take him to login page with diffrent actions he can perform
        }

    }
}
