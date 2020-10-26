using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Class1
    {
        private string name;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phoneNo;
        private string email;

        public Class1(string name, string address, string city, string state, string zip, string phoneNo, string email)
        {
            this.name = name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNo = phoneNo;
            this.email = email;
        }
        public String GetName()
        {
            return name;
        }
        public String GetAddress()
        {
            return address;
        }
        public String GetCity()
        {
            return city;
        }
        public String GetState()
        {
            return state;
        }
        public String GetZip()
        {
            return zip;
        }
        public String GetPhoneNo()
        {
            return phoneNo;
        }
        public void SetPhoneNo(String phoneNo)
        {
            this.phoneNo = phoneNo;
        }
        public String GetEmail()
        {
            return email;
        }
    }
}