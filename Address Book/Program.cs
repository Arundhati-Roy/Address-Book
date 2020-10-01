using System;
using System.Runtime.Versioning;

namespace Address_Book
{
    class Contacts
    {
        String FName { get; set; }
        String LName { get; set; }
        String Address { get; set; }
        String city { get; set; }
        String state { get; set; }
        int zipcode { get; set; }
        int phno { get; set; }

        public string ContactsDet()
        {
            return string.Format("Contact details", FName,LName,Address,city,state,zipcode,phno);
        }

        public void DispDet(String FName,String LName, String Address, String city, String state,int zipcode,int phno)
        {
            Console.WriteLine("First Name: "+FName);
            Console.WriteLine("Last Name: " + LName);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("City: " + city);
            Console.WriteLine("State: " + state);
            Console.WriteLine("Zip code: " + zipcode);
            Console.WriteLine("Phone no.: " + phno);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Address Book Program in AddressBookMain class on Master Branch");
            //int n = Console.WriteLine("How many contacts do you want");
            Contacts con = new Contacts();
            con.DispDet("A", "R", "hd,hd,uhd", "Pune", "MH", 5678, 3456789);
        }
    }
}
