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
        public void enterRegistration()
        {
            Console.WriteLine("Enter UserName");
            string userName = Console.ReadLine().ToLower();
            //Call our check to have a look at email entered
            checkUser(userName);
            if (userName.Length >= 1)
            {
                Console.WriteLine($"You entered {userName}");
                //Check Password
                Console.WriteLine("Enter Password");
                string userPassword = Console.ReadLine().ToLower();
                if (userPassword.Length >= 8)
                {
                    Console.WriteLine($"You entered {userName} {userPassword}");
                    string path = "C:\\BankRegistration";
                    //Create Directory
                    Directory.CreateDirectory(path);
                    //create a file
                    string pathFile = $@"{path}\userRegistration.txt";
                    if (File.Exists(pathFile))
                    {
                        //Append Values
                        File.AppendAllText(pathFile, $"\n{userName}:{userPassword}");
                    }
                    else
                    {
                        //Create file
                        File.WriteAllText(pathFile, $"{userName}:{userPassword}");
                    }
                }
                else
                {
                    Console.WriteLine("Password Should be eight characters or more");
                    enterRegistration();
                }
            }
            else
            {
                enterRegistration();
            }
        }
    }
}
