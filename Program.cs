using Bank_SyStem.Registration;
Login member = new Login();
Registration userOne = new Registration();
//Choose options either login or register
Dictionary<int,string> options = new Dictionary<int,string>();
options.Add(1, "Register");
options.Add(2, "Login");
options.Add(00, "Cancel");

//Allow user to choose options

foreach (KeyValuePair <int,string> option in options)
{
    Console.WriteLine($"{option.Key} : {option.Value}");
}
int optionSelected = int.Parse(Console.ReadLine());
if(optionSelected == 1)
{
   await userOne.enterRegistration();
}else if (optionSelected == 2)
{
  await member.loginUser();
}else if(optionSelected == 3)
{
    Console.WriteLine("Operation Canceled being redirected to Home Page");
}
else
{
    Console.WriteLine("Operation Ended being redirected to Home Page");
}
