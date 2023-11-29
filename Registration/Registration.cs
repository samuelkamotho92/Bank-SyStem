using Bank_SyStem.Model;
using Bank_SyStem.Service;
using Bank_SyStem.Service.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Registration
{
    public class Registration
    {        
        //check user if does exist in the system
        public void checkUser(string val)
        {
            //check enterd value matches our existing data
            //Read All Lines
            string path = "C:\\BankRegistration";
            string pathFile = $@"{path}\userRegistration.txt";
            if (File.Exists(pathFile))
            {
            string[] members = File.ReadAllLines(pathFile);
            foreach(string member in members)
            {
                string name = member.Split(':')[0].ToLower();
                //Comapre with the value we are entering
                if (name.Equals(val.ToLower()))
                {
                    Console.WriteLine($"{val} already exist in our systems enter another user name");
                    enterRegistration();
                    break;
                }
            }
            }
        }
        public async Task  enterRegistration()
        {
            Console.WriteLine("Enter UserName");
            string userName = Console.ReadLine().ToLower();
            //Call our check to have a look at email entered
          
            if (userName.Length >= 1)
            {
                Console.WriteLine($"You entered {userName}");
             /*   checkUser(userName);*/
                //Check Password
                Console.WriteLine("Enter Password");
                string userPassword = Console.ReadLine().ToLower();

                //Call the Model pass value
                AddUser user = new AddUser();
                user.userName = userName;
                user.userPassword = userPassword;

                //Call the service and pass the value
             UserService userCreate = new UserService();
                await userCreate.AddUser(user);


              /*  if (userPassword.Length >= 8)
                {
                    Console.WriteLine($"You entered {userName} {userPassword}");
                    string path = "C:\\BankRegistration";
                    //Create Directory
                    Directory.CreateDirectory(path);
                    //create a file
                    string pathFile = $@"{path}\userRegistration.txt";
                    if (File.Exists(pathFile))
                    {
                   //Append user to existing users
                        string role = "user";
                        string[] users = File.ReadAllLines(pathFile);
                        int members = users.Length;
                        members++;
                        File.AppendAllText(pathFile, $"\n{members}:{userName}:{userPassword}:{role}");
                        //After registering user to system  Login
                        Login userOne = new Login();
                        userOne.loginUser();
                    }
                    else
                    {
                        //Enter admin
*//*                        string adminName = "admin";
                        string password = "admin1234";
                        string role = "admin";
                        string id = "1";*//*
                        //Create file
*//*                        File.WriteAllText(pathFile, $"{id}:{adminName}:{password}:{role}");*/
                 /*       string[] users = File.ReadAllLines(pathFile);
                        int members = users.Length;
                        members++;*/
                       /* File.AppendAllText(pathFile, $"\n:{userName}:{userPassword}:user");*//*
                    }
                }
                else
                {
                    Console.WriteLine("Password Should be eight characters or more");
                    enterRegistration();
                }*/
            }
            else
            {
                enterRegistration();
            }
        }
    }
}
