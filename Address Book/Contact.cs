using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    public class Contact
    {
        public string fName, lName, city, state, address, pNumber;

        public Contact()
        { 
        }
        public Contact(string fName, string lName, string city, string state, string address, string pNumber)
        {
            this.fName = fName;
            this.lName = lName;
            this.city = city;
            this.state = state;
            this.address = address;
            this.pNumber = pNumber;
        }

        public string getFirstName()
        {
            return this.fName;
        }
        public void setFirstName(string fName)
        {
            this.fName = fName;
        }

        public string getLastName()
        {
            return this.lName;
        }
        public void setLastName(string lName)
        {
            this.lName = lName;
        }

        public string getAddress()
        {
            return this.address;
        }
        public void setAddress(string add)
        {
            this.address = add;
        }

        public string getCity()
        {
            return this.city;
        }
        public void setCity(string city)
        {
            this.city = city;
        }
        public string getState()
        {
            return this.state;
        }
        public void setState(string state)
        {
            this.state = state;
        }

        public string getPhone()
        {
            return this.pNumber;
        }
        public void setPhone(string pno)
        {
            this.pNumber = pno;
        }

        public override bool Equals(object c)
        {
            if (c == null || (GetType() != c.GetType()))
            {
                return false;
            }
            Contact c2 = (Contact)c;

            return (fName == c2.getFirstName()) && (lName == c2.getLastName());
        }
    }
}