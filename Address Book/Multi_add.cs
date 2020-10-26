using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        public void writeAllAddressBook()
        {
            foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
            {
                Console.WriteLine("Address Book Number = {0}", kvp.Key);
                Console.WriteLine("Address Book Contents are : ");
                a.writeAll(kvp.Value);

            }

        }
        public List<Contact> searchByCity(string y)
        {
            foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
            {
                List<Contact> cl = null;
                Contact cnew = null;
                foreach (Contact c in kvp.Value)
                {
                    if (c.getCity().Equals(y))
                    {
                        cnew = c;
                        cl.Add(cnew);
                        break;
                    }
                }
                return cl;
            }
            return null;
        }

        internal void addSearchBook(string city, List<Contact> lists)
        {
            mdict.Add(city, lists);
        }

        internal List<Contact> searchByState(string y)
        {
            foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
            {
                List<Contact> cl = null;
                Contact cnew = null;
                foreach (Contact c in kvp.Value)
                {
                    if (c.getState().Equals(y))
                    {
                        cnew = c;
                        cl.Add(cnew);
                        break;
                    }
                }
                return cl;
            }
            return null;
        }

        internal int countContactInCity()
        {
            return mdict.Keys.Count;
        }
    }
}
