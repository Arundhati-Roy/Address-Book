using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class ABook
    {
        List<Contact> aBook = new List<Contact>();
        // List<Contact>.Enumerator em = aBook.GetEnumerator();

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

        public void displayAll()
        {
            foreach (Contact c in aBook)
            {
                Console.WriteLine("\n");
                Console.WriteLine("First Name : " + c.getFirstName());
                Console.WriteLine("Last Name : " + c.getLastName());
                Console.WriteLine("City : " + c.getCity());
                Console.WriteLine("State : " + c.getState());
                Console.WriteLine("Address : " + c.getAddress());
                Console.WriteLine("Phone Number : " + c.getPhone());
            }
        }

    }
}