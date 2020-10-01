using System;

namespace AddressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            ABook a = new ABook();
            Console.WriteLine("Hello, Welcome to Address Book \nAdd Contact\nHow many Contacts do you want to add?");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter the first name, last name, city, state, address and phno. of Contact " + i + " to be added sepetated by space");
                string alldata = Console.ReadLine();
                string[] sepData = alldata.Split(" ");
                Contact c1 = new Contact(sepData[0], sepData[1], sepData[2], sepData[3], sepData[4], long.Parse(sepData[5]));
                a.addContact(c1);
            }
            Console.WriteLine("Contact successfully added.");
            Console.WriteLine("Following are the details");
            a.displayAll();
        }
    }
}