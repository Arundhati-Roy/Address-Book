using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class MultiDict
    {
        ABook a = new ABook();
        Dictionary<string, List<Contact>> mdict = new Dictionary<string, List<Contact>>();
        //Contact c= new Contact()


        public void addNewAddressBook(string key, List<Contact> list)
        {
            mdict.Add(key, list);
        }

        public void displayAllAddressBook()
        {
            foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
            {
                Console.WriteLine("Address Book Number = {0}", kvp.Key);
                Console.WriteLine("Address Book Contents are : ");
                a.displayAll(kvp.Value);

            }
        }
    }
}