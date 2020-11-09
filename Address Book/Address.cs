using Address_Book;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookProblem
{
    class ABook
    {
        List<Contact> aBook = new List<Contact>();
        AddRepo addRepo = new AddRepo();

        public void setAddBook(List<Contact> addBook)
        {
            this.aBook = addBook;
        }
        public List<Contact> getAddBook()
        {
            return aBook;
        }
        public void addContact(Contact c,string name)
        {
            aBook.Add(c);
            //addRepo.AddToContact_CheckTypeFromAddressDict(c.fName, c.lName, c.pNumber, name);
            addRepo.AddContact(c,name);
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
            RestApi rest = new RestApi();
            rest.AddEmployee(l);
            //writeContactInJson(l);
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
                    addRepo.UpdateAddBook_FirstName(c.cId, c.fName);
                    break;

                case 2:
                    Console.WriteLine("Enter the new Last name");
                    string lname = Console.ReadLine();
                    c.setLastName(lname);
                    addRepo.UpdateAddBook_FirstName(c.cId, c.lName);
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
            string text = "First Name : " + c.getFirstName() + " Last Name : " + c.getLastName() + "  Address : " + c.getAddress() + "  City : " + c.getCity() +
                "  State : " + c.getState() + "  Contact No. : " + c.getPhone() + "\n";

            File.WriteAllText(path, text);
            Console.WriteLine("Written into file");
        }
        public void writeContactInCSV(Contact contact)
        {
            string path = @"C:\Users\priyadarshini roy\source\repos\Address Book\Address Book\ContactsCSV.csv";
            string csv = string.Format("{0},{1},{2},{3},{4},{5},{6}\n",
                contact.cId, contact.fName, contact.lName, contact.pNumber, contact.getAddress(), contact.getCity(), contact.getState());
            File.WriteAllText(path, csv);
            Console.WriteLine("Written into Excel");
        }
        public void writeContactInJson(List<Contact> l)
        {
            string expfp = @"C:\Users\priyadarshini roy\source\repos\Address Book\Address Book\ContactsJson.json";

            //writing into json
            JsonSerializer ser = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(expfp))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                foreach (Contact c in l)
                {
                    ser.Serialize(jw, c);
                }
            }
            Console.WriteLine("\nWritten into json file");
        }
        public void deleteContact(Contact c)
        {
            aBook.Remove(c);
            addRepo.DelContact(c.cId);
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