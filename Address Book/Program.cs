﻿using System;
using System.Collections.Generic;

namespace AddressBookProblem
{
    class Program
    {
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
                    Console.WriteLine("\nHello, Welcome to Address Book " + j + "\nChoose the operation you want to perform\n" +
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
                                //string alldata = Console.ReadLine();
                                //string[] sepData = alldata.Split(" ");
                                Console.WriteLine("First Name: ");
                                String fname = Console.ReadLine();
                                Console.WriteLine("Last Name: ");
                                String lname = Console.ReadLine();
                                Console.WriteLine("City: ");
                                String city = Console.ReadLine();
                                Console.WriteLine("State: ");
                                String state = Console.ReadLine();
                                Console.WriteLine("Address: ");
                                String addr = Console.ReadLine();
                                Console.WriteLine("Phone no.: ");
                                int phNo = Convert.ToInt32(Console.ReadLine());
                                Contact c1 = new Contact(fname, lname, city, state, addr, phNo);
                                a.addContact(c1);
                            }
                            Console.WriteLine("Contact successfully added...........Following are the details\n");
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
            MultiDict md2 = new MultiDict();
            MultiDict md3 = new MultiDict();
            Console.WriteLine("Do you wanna search person by city or state?(1.Yes or 2.N0)");
            int k2 = Convert.ToInt32(Console.ReadLine());
            if (k2 == 1)
            {
                Console.WriteLine("Choose the criteria to search for \n1.City\t2.State");
                int s = Convert.ToInt32(Console.ReadLine());
                if (s == 1)
                {
                    Console.WriteLine("Enter the city name");
                    string city = Console.ReadLine();
                    List<Contact> l1 = md.searchByCity(city);
                    if (l1 != null)
                    {
                        Console.WriteLine("Following are the details of contacts who belong to " + city);
                        a2.displayAll(l1);
                        md2.addSearchBook(city, a2.getAddBook());
                        Console.WriteLine("Total contacts in city "+city+"are: "+md2.countContactInCity());
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
                    List<Contact> l2 = md.searchByState(state);
                    if (l2 != null)
                    {
                        Console.WriteLine("Following are the details of contacts who belong to " + state);
                        a2.displayAll(l2);
                        md3.addSearchBook(state, a2.getAddBook());
                        Console.WriteLine("Total contacts in state " + state + "are: " + md3.countContactInCity());
                    }
                    else
                    {
                        Console.WriteLine("No Person belongs to that state");
                    }
                }
            }
        }
    }
}
