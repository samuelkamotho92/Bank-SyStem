﻿using Bank_SyStem.Operations;
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
            Console.WriteLine("Enter User Passowrd");
            string userPassword = Console.ReadLine().ToLower();
            //Check user in the system if does exist 
            string path = "C:\\BankRegistration";
            string pathFile = $@"{path}\userRegistration.txt";
            //read file
            string[] members = File.ReadAllLines(pathFile);
            string validateUser = $"{userName}:{userPassword}";
            //check enterd user if admin or normal user
        string  registeredMember = Array.Find(members, element => element.Contains(validateUser));
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
            }
        }

    }
}
