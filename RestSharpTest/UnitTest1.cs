using AddressBookProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTest
{
    /*public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }*/
    [TestClass]
    public class RestSharpTestCase
    {
        RestClient client;
        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:3000");
        }

        /// <summary>
        /// Gets the employee list.
        /// </summary>
        /// <returns></returns>
        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/Contacts", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// Return employee list count.
        /// </summary>
        [TestMethod]
        public void OnCallingList_CheckCount()
        {
            IRestResponse response = getEmployeeList();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Assert.AreEqual(8, dataResponse.Count);

            foreach (Contact e in dataResponse)
            {
                Console.WriteLine("fName : " + e.fName + " Last Name : " + e.lName + " Address : " + e.address);
            }
        }

        /// <summary>
        /// Adds Employee
        /// </summary>
        [TestMethod]
        public void AddEmployee()
        {
            //var id = 1;
            RestRequest request = new RestRequest("/Contacts", Method.POST);
            JObject jObject = new JObject();
            //var id = jObject.GetValue("id");
            //jObject.Add("id",id);
            jObject.Add("fName", "Samay");
            jObject.Add("lName", "Raina");
            jObject.Add("city", "Hyd");
            jObject.Add("state", "Telangana");
            jObject.Add("address", "Hyderabad");
            jObject.Add("pNumber", "68687980");

            request.AddParameter("application/json", jObject, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Contact dataResponse = JsonConvert.DeserializeObject<Contact>(response.Content);
            Assert.AreEqual("Samay", dataResponse.fName);
            Assert.AreEqual("Hyderabad", dataResponse.address);
            Assert.AreEqual("68687980", dataResponse.pNumber);
            Assert.AreEqual("Hyd", dataResponse.city);

            System.Console.WriteLine(response.Content);

        }

        /// <summary>
        /// Adds Multiple Employees
        /// </summary>
        [TestMethod]
        public void AddMultipleEmployee()
        {
            List<Contact> employeeList = new List<Contact>();
            employeeList.Add(new Contact { fName = "A", pNumber = "459389", address = "Mumbai", city = "Hyd" });
            employeeList.Add(new Contact { fName = "B", pNumber = "989459389", address = "Pune", city = "Mum" });
            foreach (Contact e in employeeList)
            {
                RestRequest request = new RestRequest("/Contacts", Method.POST);
                JObject jObject = new JObject();
                jObject.Add("fName", e.fName);
                jObject.Add("pNumber", e.pNumber);
                jObject.Add("address", e.address);
                jObject.Add("city", e.city);

                request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                IRestResponse response1 = client.Execute(request);
                Assert.AreEqual(response1.StatusCode, HttpStatusCode.Created);
            }

            IRestResponse response = getEmployeeList();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            //Assert.AreEqual(8, dataResponse.Count);

            foreach (Contact e in dataResponse)
            {
                System.Console.WriteLine("ID : " + e.pNumber + " Name : " + e.fName + " Address : " + e.address);
            }
        }

        /// <summary>
        /// Updates Employee
        /// </summary>
        [TestMethod]
        public void UpdateEmployee()
        {
            RestRequest request = new RestRequest("/Contacts/7", Method.PUT);
            JObject jObject = new JObject();
            jObject.Add("fName", "Shreya");
            jObject.Add("address", "Bhilai");

            request.AddParameter("application/json", jObject, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Contact dataResponse = JsonConvert.DeserializeObject<Contact>(response.Content);
            Assert.AreEqual("Shreya", dataResponse.fName);
            Assert.AreEqual("Bhilai", dataResponse.address);
            System.Console.WriteLine(response.Content);
        }

        /// <summary>
        /// Deletes Employee
        /// </summary>
        [TestMethod]
        public void DeleteEmployee()
        {
            RestRequest request = new RestRequest("/Contacts/5", Method.DELETE);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            System.Console.WriteLine(response.Content);
        }

    }
}