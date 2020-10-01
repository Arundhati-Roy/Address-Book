using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class Contact
    {
        protected string fName, lName, city, state, address;
        protected long pNumber;

        public Contact(string fName, string lName, string city, string state, string address, long pNumber)
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

        public long getPhone()
        {
            return this.pNumber;
        }
        public void setPhone(long pno)
        {
            this.pNumber = pno;
        }


    }
}