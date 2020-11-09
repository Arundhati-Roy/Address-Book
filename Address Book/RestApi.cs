using AddressBookProblem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book
{
    public class RestApi
    {
        RestClient client = new RestClient("http://localhost:3000");

        public IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/Contacts", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public void AddEmployee(List<Contact> l)
        {
            /*List<Contact> employeeList = new List<Contact>();
            employeeList.Add(new Contact { fName = "A", pNumber = "459389", address = "Mumbai", city = "Hyd" });
            employeeList.Add(new Contact { fName = "B", pNumber = "989459389", address = "Pune", city = "Mum" });*/
            foreach (Contact e in l)
            {
                RestRequest request = new RestRequest("/Contacts", Method.POST);
                JObject jObject = new JObject();
                jObject.Add("fName", e.fName);
                jObject.Add("pNumber", e.pNumber);
                jObject.Add("address", e.address);
                jObject.Add("city", e.city);

                request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                IRestResponse response1 = client.Execute(request);
            }

            IRestResponse response = getEmployeeList();
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            //Assert.AreEqual(8, dataResponse.Count);

            foreach (Contact e in dataResponse)
            {
                System.Console.WriteLine("Phone Number : " + e.pNumber + " Name : " + e.fName + " Address : " + e.address);
            }
        }
    }
}
