using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressBookProblem
{
    class Program
    {
        public static Dictionary<string, List<Contact>> cityDictionary = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> stateDictionary = new Dictionary<string, List<Contact>>();
        static void Main(string[] args)
        {
            MultiDict md = new MultiDict();
            Console.WriteLine("Hello, How many address books you want to create?");
            int no_ABooks = Convert.ToInt32(Console.ReadLine());
            ABook a2 = new ABook();
            for (int j = 1; j <= no_ABooks; j++)
            {
                Console.WriteLine("Enter the name of address book " + j);
                String name = Console.ReadLine();
                ABook a = new ABook();
                bool val = true;
                while (val)
                {
                    Console.WriteLine("\nHello, Welcome to Address Book " + name + "\nChoose the operation you want to perform\n" +
                        "1.Add Contact" + "\n2.Edit Contact\n3.Delete a contact from the list\n4.Search by city\n5.Exit");
                    int k = Convert.ToInt32(Console.ReadLine());

                    switch (k)
                    {
                        case 1:
                            Console.WriteLine("\nAdd Contact\nHow many Contacts do you want to add ?");
                            int n = Convert.ToInt32(Console.ReadLine());
                            for (int i = 1; i <= n; i++)
                            {
                                Console.WriteLine("Enter the details of Contact " + i);
                                Console.WriteLine("Enter First Name : ");
                                String fname = Console.ReadLine();
                                Regex reg4 = new Regex(@"(^[a-z A-Z]*$)");
                                while (!reg4.IsMatch(fname))
                                {
                                    Console.WriteLine("Enter a valid name : ");
                                    name = Console.ReadLine();
                                }
                                Console.WriteLine("Enter Last Name : ");
                                String lname = Console.ReadLine();
                                Regex regex1 = new Regex(@"(^[a-z A-Z]*$)");
                                while (!regex1.IsMatch(lname))
                                {
                                    Console.WriteLine("Enter a valid name : ");
                                    name = Console.ReadLine();
                                }
                                Console.WriteLine("Enter your address : ");
                                String addr = Console.ReadLine();
                                Regex reg5 = new Regex(@"(^[a-z A-Z]*$)");
                                while (!reg5.IsMatch(addr))
                                {
                                    Console.WriteLine("Enter a valid address : ");
                                    addr = Console.ReadLine();
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
                                String phNo = Console.ReadLine();
                                Regex reg1 = new Regex(@"(^[7-9]{1}[0-9]{9}$)");
                                while (!reg1.IsMatch(phNo))
                                {
                                    Console.WriteLine("Enter a a valid mobile number : ");
                                    phNo = Console.ReadLine();
                                }
                                Console.WriteLine("Enter your email : ");
                                String mailID = Console.ReadLine();
                                Regex reg2 = new Regex("^[\\w-\\+]+(\\.[\\w]+)*@[\\w-]+(\\.[\\w]+)*(\\.[a-z]{2,})$");
                                while (!reg2.IsMatch(mailID))
                                {
                                    Console.WriteLine("Enter a a valid emailID : ");
                                    mailID = Console.ReadLine();
                                }
                                
                                Contact c1 = new Contact(fname, lname, city, state, addr, phNo);
                                a.addContact(c1);
                            }
                            Console.WriteLine("Contact successfully added...........Following are the details\n");
                            a.SortByName();
                            a.displayAll(a.getAddBook());
                            break;

                        case 2:
                            Console.WriteLine("Enter the first and last name of the contact seperated by space");
                            String edata1 = Console.ReadLine();
                            string[] edata = edata1.Split(" ");
                            Contact c = a.SearchUsingName(edata[0], edata[1]);
                            if (c == null)
                            {
                                Console.WriteLine("No such contacts found....Please enter correct input");
                                break;
                            }
                            Console.WriteLine("Following are the present details of the contact you chose to edit");
                            a.displayContact(c);
                            Console.WriteLine("Choose which detail you want to edit\n1.First Name\t2.Last Name\t3.City\t4.State\t5.Addresss\t6.Phone number");
                            int m = Convert.ToInt32(Console.ReadLine());
                            Contact cEdited = a.editContact(c, m);
                            Console.WriteLine("Here are the updated details");
                            a.displayContact(cEdited);
                            break;

                        case 3:
                            Console.WriteLine("Enter the first and last name of the contact you want to delete");
                            String ddata1 = Console.ReadLine();
                            string[] ddata = ddata1.Split(" ");
                            Contact cDel = a.SearchUsingName(ddata[0], ddata[1]);
                            if (cDel == null)
                            {
                                Console.WriteLine("No such contacts found....Please enter correct input");
                                break;
                            }
                            a.deleteContact(cDel);
                            Console.WriteLine("Contact successfully deleted\nFollowing is the contact list\n");
                            a.displayAll(a.getAddBook());
                            break;

                        case 4:
                            Console.WriteLine("Enter city to search");
                            string scity = Console.ReadLine();
                            Contact cSearch = a.SearchUsingCity(scity);
                            break;

                        case 5:
                            val = false;
                            break;

                        default: break;

                    }
                }

                md.addNewAddressBook(name, a.getAddBook());
            }
            md.displayAllAddressBook();
            Console.WriteLine("View by city or state?? 1.Yes\t 2.No");
            int k2 = Convert.ToInt32(Console.ReadLine());
            if (k2 == 1)
            {
                Console.WriteLine("Choose the criteria to search for \n1.City\t2.State");
                int s = Convert.ToInt32(Console.ReadLine());
                if (s == 1)
                {
                    Console.WriteLine("Enter the city name");
                    string city = Console.ReadLine();
                    List<Contact> l1 = new List<Contact>();
                    foreach (KeyValuePair<string, List<Contact>> kvp in cityDictionary)
                    {
                        if (kvp.Key == city)
                        {
                            l1 = kvp.Value;
                            break;
                        }
                    }
                    if (l1 != null)
                    {
                        Console.WriteLine("Following are the details of contacts who belong to " + city + "\n");
                        a2.displayAll(l1);
                        Console.WriteLine("Total number of persons belonging to this city is : " + l1.Count);
                    }
                    else
                    {
                        Console.WriteLine("No Person belongs to that city");
                    }
                }
                else
                {
                    Console.WriteLine("Enter the state name");
                    string state = Console.ReadLine();
                    List<Contact> l2 = new List<Contact>();
                    foreach (KeyValuePair<string, List<Contact>> kvp in stateDictionary)
                    {
                        if (kvp.Key == state)
                        {
                            l2 = kvp.Value;
                            break;
                        }
                    }
                    if (l2 != null)
                    {
                        Console.WriteLine("Following are the details of contacts who belong to " + state + "\n");
                        a2.displayAll(l2);
                        Console.WriteLine("Total number of persons belonging to this state is : " + l2.Count);
                    }
                    else
                    {
                        Console.WriteLine("No Person belongs to that state");
                    }
                }
            }

        }


        public static List<Contact> searchedContactDictionaryCity(string city)
        {
            List<Contact> l2 = new List<Contact>();
            foreach (KeyValuePair<string, List<Contact>> kvp in cityDictionary)
            {
                if (kvp.Key == city)
                {
                    l2 = kvp.Value;
                    break;
                }
            }
            return l2;
        }

        public static List<Contact> searchedContactDictionaryState(string state)
        {
            List<Contact> lSearched2 = new List<Contact>();
            foreach (KeyValuePair<string, List<Contact>> kvp in stateDictionary)
            {
                if (kvp.Key == state)
                {
                    lSearched2 = kvp.Value;
                    break;
                }
            }
            return lSearched2;

        }

    }

}