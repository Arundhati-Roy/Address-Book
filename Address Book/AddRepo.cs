using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
//using AddressBookProblem.Contacts;

namespace AddressBookProblem
{
    public class AddRepo
    {
        public static SqlConnection ConnSetup()
        {
            return new SqlConnection(@"Data Source=(LocalDb)\RoyDB;Initial Catalog=AddressBookDB;Integrated Security=True");
        }

        public string UpdateAddBook(string type, string name)
        {
            var retType = "";
            SqlConnection sqlConnection = ConnSetup();
            //int salary = 0;
            try
            {
                Contact contact = new Contact();
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
                            if (adName == name)
                                retType = type;

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
            return retType;
        }
        public string UpdateAddBook_FirstName(int cId, string name)
        {
            var retType = "";
            SqlConnection sqlConnection = ConnSetup();
            //int salary = 0;
            try
            {
                Contact contact = new Contact();
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = @"update Contacts 
                                     set fName=@name where cId=@cId";

                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@cId", cId);
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

                    /*string query2 = @"select * from Contacts c,AddressBookDictionary a
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
                            if (adName == name)
                                retType = type;

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
                    dr.Close();*/
                    sqlConnection.Close();
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
            return retType;
        }
        public string UpdateAddBook_LastName(int cId, string name)
        {
            var retType = "";
            SqlConnection sqlConnection = ConnSetup();
            //int salary = 0;
            try
            {
                Contact contact = new Contact();
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = @"update Contacts 
                                     set lName=@name where cId=@cId";

                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@cId", cId);
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

                    /*string query2 = @"select * from Contacts c,AddressBookDictionary a
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
                            if (adName == name)
                                retType = type;

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
                    dr.Close();*/
                    sqlConnection.Close();
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
            return retType;
        }
        public int DelContact(int cId)
        {
            SqlConnection sqlConnection = ConnSetup();
            try
            {
                using (sqlConnection)
                {
                    string query = @"delete from Contacts where cID="+cId;

                    //define sql object
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);

                    sqlConnection.Open();

                    //cmd.Parameters.AddWithValue("@name", "nallia");

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Console.WriteLine(rows + " row(s) affected");
                    }
                    else
                    {
                        Console.WriteLine("Please check your query");
                    }
                    sqlConnection.Close();
                    return rows;
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
        }

        public List<Contact> GetAllContacts()
        {
            var retType = "";
            List<Contact> contacts = new List<Contact>();
            SqlConnection sqlConnection = ConnSetup();
            //int salary = 0;
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();

                    string query2 = @"select * from Contacts c,AddressBookDictionary a
                                     where c.ABname=a.name";

                    SqlCommand cmd = new SqlCommand(query2, sqlConnection);
                    cmd = new SqlCommand(query2, sqlConnection);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Contact contact = new Contact();
                            contact.cId = dr.GetInt32(0);
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
                            var type = dr.GetString(10);
                            /*if (adName == name)
                                retType = type;*/

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                                contact.cId, contact.fName, contact.lName, contact.pNumber, contact.address, contact.city, contact.state, email,
                                adName, type);
                            Console.WriteLine("\n");
                            contacts.Add(contact);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                    sqlConnection.Close();
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
            return contacts;
        }

        public int DelAddressBookType()
        {
            SqlConnection sqlConnection = ConnSetup();
            try
            {
                using (sqlConnection)
                {
                    string query = @"delete from AddressBookDictionary where name='c'";

                    //define sql object
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);

                    sqlConnection.Open();

                    //cmd.Parameters.AddWithValue("@name", "nallia");

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Console.WriteLine(rows + " row(s) affected");
                    }
                    else
                    {
                        Console.WriteLine("Please check your query");
                    }
                    sqlConnection.Close();
                    return rows;
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
        }

        public void AddToContact_CheckTypeFromAddressDict(string fname, string lname, string phNo, string type)
        {
            SqlConnection sqlConnection = ConnSetup();
            try
            {
                Contact contact = new Contact();
                using (sqlConnection)
                {
                    sqlConnection.Open();

                    //define sql object
                    SqlCommand cmd = new SqlCommand("spAddContact", sqlConnection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@phNo", phNo);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            contact.cId = dr.GetInt32(0);
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
                                contact.cId, contact.fName, contact.lName, contact.pNumber, contact.address, contact.city, contact.state, email,
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
        }

        public void AddToContact_CheckTypeFromAddressDictWithThread(string fname, string lname, string phNo, string type)
        {
            Task thread = new Task(() =>
            {
                SqlConnection sqlConnection = ConnSetup();
                try
                {
                    Contact contact = new Contact();
                    using (sqlConnection)
                    {
                        sqlConnection.Open();

                        //define sql object
                        SqlCommand cmd = new SqlCommand("spAddContact", sqlConnection);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@fname", fname);
                        cmd.Parameters.AddWithValue("@lname", lname);
                        cmd.Parameters.AddWithValue("@phNo", phNo);

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
            });
            thread.Start();
        }

        public void AddContact(Contact c, string type)
        {
            Task thread = new Task(() =>
            {
                SqlConnection sqlConnection = ConnSetup();
                try
                {
                    Contact contact = new Contact();
                    using (sqlConnection)
                    {
                        sqlConnection.Open();

                        //define sql object
                        SqlCommand cmd = new SqlCommand("spFullAddContact", sqlConnection);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@fname", c.fName);
                        cmd.Parameters.AddWithValue("@lname", c.lName);
                        cmd.Parameters.AddWithValue("@phNo", c.pNumber);
                        cmd.Parameters.AddWithValue("@city", c.city);
                        cmd.Parameters.AddWithValue("@state", c.state);
                        cmd.Parameters.AddWithValue("@addr", c.address);


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
            });
            thread.Start();

        }
    }
}
