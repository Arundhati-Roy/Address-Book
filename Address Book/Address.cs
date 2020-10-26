using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookProblem
{
    class ABook
    {
        List<Contact> aBook = new List<Contact>();

        public void setAddBook(List<Contact> addBook)
        {
            this.aBook = addBook;
        }
        public List<Contact> getAddBook()
        {
            return aBook;
        }

        public void addContact(Contact c)
        {
            aBook.Add(c);
        }
        public void SortByName()
        {
            List<Contact> list = this.aBook;
            list.OrderBy(aBook => aBook.getFirstName()).ToList();

        }
        public void SortByCity()
        {
            List<Contact> list = this.aBook;
            list.OrderBy(aBook => aBook.getCity()).ToList();

        }
        public void SortByState()
        {
            List<Contact> list = this.aBook;
            list.OrderBy(aBook => aBook.getState()).ToList();

        }
        public void displayAll(List<Contact> l)
        {
            foreach (Contact c in l)
            {
                displayContact(c);
                Console.WriteLine("**************");
                
            }

        }
        public void writeAll(List<Contact> l)
        {
            foreach (Contact c in l)
            {
                writeContact(c);
                writeContactInCSV(c);
                Console.WriteLine("**************");

            }

        }

        public Contact SearchUsingName(string fname, string lname)
        {
            Contact cnew = null;
            foreach (Contact c in aBook)
            {
                if (c.getFirstName().Equals(fname) && c.getLastName().Equals(lname))
                {
                    cnew = c;
                    break;
                }
            }
            return cnew;
        }

        public Contact editContact(Contact c, int k)
        {
            switch (k)
            {
                case 1:
                    Console.WriteLine("Enter the new First name");
                    string fname = Console.ReadLine();
                    c.setFirstName(fname);
                    break;

                case 2:
                    Console.WriteLine("Enter the new Last name");
                    string lname = Console.ReadLine();
                    c.setLastName(lname);
                    break;

                case 3:
                    Console.WriteLine("Enter the new City");
                    string city = Console.ReadLine();
                    c.setCity(city);
                    break;

                case 4:
                    Console.WriteLine("Enter the new State");
                    string state = Console.ReadLine();
                    c.setState(state);
                    break;

                case 5:
                    Console.WriteLine("Enter the new Address");
                    string add = Console.ReadLine();
                    c.setAddress(add);
                    break;

                case 6:
                    Console.WriteLine("Enter the new phone number");
                    string pNum = Console.ReadLine();
                    c.setPhone(pNum);
                    break;

                default: break;
            }

            return (c);
        }

        public void displayContact(Contact c)
        {
            Console.WriteLine("First Name : " + c.getFirstName());
            Console.WriteLine("Last Name : " + c.getLastName());
            Console.WriteLine("City : " + c.getCity());
            Console.WriteLine("State : " + c.getState());
            Console.WriteLine("Address : " + c.getAddress());
            Console.WriteLine("Phone Number : " + c.getPhone());
            
        }
        public void writeContact(Contact c)
        {
            string path = @"C:\Users\priyadarshini roy\source\repos\Address Book\Address Book\ContactsFile.txt";
            string text = "First Name : " + c.getFirstName() + " Last Name : " + c.getLastName() + "  Address : " + c.getAddress() + "  City : " + c.getCity() + "  State : " + c.getState() + "  Contact No. : " + c.getPhone() + "\n";

            File.AppendAllText(path, text);
            Console.WriteLine("Written into file");
        }
        public void writeContactInCSV(Contact c)
        {
            string path = @"C:\Users\priyadarshini roy\source\repos\Address Book\Address Book\ContactsCSV.csv";
            string csv = string.Format("{0},{1},{2},{3},{4},{5}\n", c.getFirstName(), c.getLastName() , c.getAddress() , c.getCity(), c.getState(), c.getPhone() );
            File.AppendAllText(path, csv);
            Console.WriteLine("Written into Excel");
        }
        public void deleteContact(Contact c)
        {
            aBook.Remove(c);
        }
        public bool CheckForDuplicate(Contact c1)
        {
            bool val = true;
            foreach (Contact c in aBook)
            {
                if (c1.Equals(c))
                {
                    val = false;
                }
            }
            return val;
        }

        public Contact SearchUsingCity(string city)
        {
            Contact cnew = null;
            foreach (Contact c in this.aBook)
            {
                if (c.getCity().Equals(city))
                {
                    cnew = c;
                    break;
                }
            }
            return cnew;
        }
    }
}