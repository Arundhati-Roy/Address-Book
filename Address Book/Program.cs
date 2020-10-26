using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Serialization;

namespace AddressBook
{
    class Program
    {

        static void Main(string[] args)
        {
            int choice = 0;
            AddressBook ab = new AddressBook();
            do
            {
                Console.WriteLine("Enter your choice :");
                Console.WriteLine("1. Add Contact.");
                Console.WriteLine("2. View all Contacts.");
                Console.WriteLine("3.Edit existing contacts.");
                Console.WriteLine("4.Remove a contact.");
                Console.WriteLine("5.View AddressBook for a key name.");
                Console.WriteLine("6.Search person by city/state name.");
                Console.WriteLine("7.View persons by city.");
                Console.WriteLine("8.View persons by state");
                Console.WriteLine("9.Exit.");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {

                    Console.WriteLine("Enter your Name : ");
                    String name = Console.ReadLine();
                    Regex reg4 = new Regex(@"(^[a-z A-Z]*$)");
                    while (!reg4.IsMatch(name))
                    {
                        Console.WriteLine("Enter a valid name : ");
                        name = Console.ReadLine();
                    }
                    while (ab.UC7_CheckForDuplicateEntry(name))
                    {
                        Console.WriteLine("This name already exists in the address book.");
                        Console.WriteLine("Please enter a new name : ");
                        name = Console.ReadLine();
                        while (!reg4.IsMatch(name))
                        {
                            Console.WriteLine("Enter a valid name : ");
                            name = Console.ReadLine();
                        }
                    }
                    Console.WriteLine("Enter your address : ");
                    String address = Console.ReadLine();
                    Regex reg5 = new Regex(@"(^[a-z A-Z]*$)");
                    while (!reg5.IsMatch(address))
                    {
                        Console.WriteLine("Enter a valid address : ");
                        address = Console.ReadLine();
                    }
                    Console.WriteLine("Enter your city : ");
                    String city = Console.ReadLine();
                    Regex reg6 = new Regex(@"(^[a-z A-Z]*$)");
                    while (!reg6.IsMatch(city))
                    {
                        Console.WriteLine("Enter a valid city name : ");
                        city = Console.ReadLine();
                    }
                    Console.WriteLine("Enter your state : ");
                    String state = Console.ReadLine();
                    Regex reg7 = new Regex(@"(^[a-z A-Z]*$)");
                    while (!reg7.IsMatch(state))
                    {
                        Console.WriteLine("Enter a valid state name : ");
                        state = Console.ReadLine();
                    }
                    Console.WriteLine("Enter your zip : ");
                    String zip = Console.ReadLine();
                    Regex reg = new Regex(@"(^[0-9]{6}$)");
                    while (!reg.IsMatch(zip))
                    {
                        Console.WriteLine("Enter a valid zip code : ");
                        zip = Console.ReadLine();
                    }
                    Console.WriteLine("Enter your contact no. : ");
                    String contactNo = Console.ReadLine();
                    Regex reg1 = new Regex(@"(^[7-9]{1}[0-9]{9}$)");
                    while (!reg1.IsMatch(contactNo))
                    {
                        Console.WriteLine("Enter a a valid mobile number : ");
                        contactNo = Console.ReadLine();
                    }
                    Console.WriteLine("Enter your email : ");
                    String mailID = Console.ReadLine();
                    Regex reg2 = new Regex("^[\\w-\\+]+(\\.[\\w]+)*@[\\w-]+(\\.[\\w]+)*(\\.[a-z]{2,})$");
                    while (!reg2.IsMatch(mailID))
                    {
                        Console.WriteLine("Enter a a valid emailID : ");
                        mailID = Console.ReadLine();
                    }
                    Console.WriteLine("Enter the key name to be saved in the address book : ");
                    String keyname = Console.ReadLine();
                    Regex reg3 = new Regex("^[A-Z a-z]*$");
                    while (!reg3.IsMatch(keyname))
                    {
                        Console.WriteLine("Enter a valid name : ");
                        keyname = Console.ReadLine();
                    }
                    Class1 c = new Class1(name, address, city.ToUpper(), state.ToUpper(), zip, contactNo, mailID);

                    ab.AddAddress(keyname, c);

                }
                else if (choice == 2)
                {
                    List<Class1> li = ab.ViewAddressBook();
                    if (li.Count == 0)
                    {
                        Console.WriteLine("The address book is empty.");
                    }
                    else
                    {
                        foreach (Class1 cl in li)
                        {
                            Console.WriteLine("Name : " + cl.GetName());
                            Console.WriteLine("Address : " + cl.GetAddress());
                            Console.WriteLine("City : " + cl.GetCity());
                            Console.WriteLine("State : " + cl.GetState());
                            Console.WriteLine("zip : " + cl.GetZip());
                            Console.WriteLine("Contact No. : " + cl.GetPhoneNo());
                            Console.WriteLine("Email ID : " + cl.GetEmail());
                        }
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the name :");
                    String ename = Console.ReadLine();
                    Console.WriteLine("Enter the new number for " + ename);
                    String newnumber = Console.ReadLine();
                    ab.EditNumber(ename, newnumber);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter the name :");
                    String rname = Console.ReadLine();
                    ab.RemoveContact(rname);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Enter the key name : ");
                    String kname = Console.ReadLine();
                    Class1 cc = ab.ViewByKeyName(kname);
                    if (cc == null)
                    {
                        Console.WriteLine("No such key name found!!!");
                    }
                    else
                    {
                        Console.WriteLine("Name : " + cc.GetName());
                        Console.WriteLine("Address : " + cc.GetAddress());
                        Console.WriteLine("City : " + cc.GetCity());
                        Console.WriteLine("State : " + cc.GetState());
                        Console.WriteLine("zip : " + cc.GetZip());
                        Console.WriteLine("Contact No. : " + cc.GetPhoneNo());
                        Console.WriteLine("Email ID : " + cc.GetEmail());
                    }
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Enter the name of the city/state : ");
                    string location = Console.ReadLine();
                    List<Class1> li = ab.UC8_SearchPeopleByCityOrState(location);
                    if (li.Count != 0)
                    {
                        Console.WriteLine("There are " + li.Count + " contacts with location " + location);
                        foreach (Class1 cc in li)
                        {
                            Console.WriteLine("Name : " + cc.GetName() + "  Address : " + cc.GetAddress() + "  ZIP : " + cc.GetZip() + "  Contact No : " + cc.GetPhoneNo() + "  EmailID : " + cc.GetEmail());

                        }

                    }
                    else
                    {
                        Console.WriteLine("No contact found!!!");
                    }
                }
                else if (choice == 7)
                {
                    ab.AddressByCity();

                }
                else if (choice == 8)
                {
                    ab.AddressByState();
                }
                else
                {
                    break;
                }
            } while (choice != 9);
        }
    }
}