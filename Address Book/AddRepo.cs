using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
//using AddressBookProblem.Contacts;

namespace AddressBookProblem
{
    public class AddRepo
    {
        public static SqlConnection ConnSetup()
        {
            return new SqlConnection(@"Data Source=(LocalDb)\RoyDB;Initial Catalog=AddressBookDB;Integrated Security=True");
        }

        public string UpdateAddBook(string type,string name)
        {
            SqlConnection sqlConnection = ConnSetup();
            //int salary = 0;
            try
            {
                Contact contact = new Contact();
                //var type = "";
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = @"update AddressBookDictionary 
                                     set type=@type where name=@name";

                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@name", name);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Console.WriteLine(rows + " row(s) affected");
                    }
                    else
                    {
                        Console.WriteLine("Please check your query");
                    }

                    string query2 = @"select * from Contacts c,AddressBookDictionary a
                                     where c.ABname=a.name";

                    cmd = new SqlCommand(query2, sqlConnection);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var contactId = dr.GetInt32(0);
                            contact.fName = dr.GetString(2);
                            contact.lName = dr.GetString(3);
                            contact.pNumber = dr.GetString(4);
                            if (dr["addr"] != DBNull.Value)
                                contact.address = dr.GetString(5);
                            if (dr["city"] != DBNull.Value)
                                contact.city = dr.GetString(6);
                            if (dr["state"] != DBNull.Value)
                                contact.state = dr.GetString(7);
                            var email = dr.GetString(8);
                            var adName = dr.GetString(9);
                            type = dr.GetString(10);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                                contactId, contact.fName, contact.lName, contact.pNumber, contact.address, contact.city, contact.state, email,
                                adName, type);
                            Console.WriteLine("\n");
                        }

                        
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                    sqlConnection.Close();
                    return type;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("Null data found");
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            //return salary;
        }


    }
}
