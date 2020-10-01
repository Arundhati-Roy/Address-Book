using System;

namespace AddressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            ABook a = new ABook();
            bool val = true;
            while (val)
            {
                Console.WriteLine("\nHello, Welcome to Address Book\nChoose the operation you want to perform\n1.Add Contact\n2.Edit Contact\n3.Delete a contact from the list\n4.Exit");
                int k = Convert.ToInt32(Console.ReadLine());

                switch (k)
                {
                    case 1:
                        Console.WriteLine("\nAdd Contact\nHow many Contacts do you want to add ?");
                        int n = Convert.ToInt32(Console.ReadLine());
                        for (int i = 1; i <= n; i++)
                        {
                            Console.WriteLine("Enter the details of Contact " + i + " to be added sepetated by space");
                            string alldata = Console.ReadLine();
                            string[] sepData = alldata.Split(" ");
                            Contact c1 = new Contact(sepData[0], sepData[1], sepData[2], sepData[3], sepData[4], long.Parse(sepData[5]));
                            a.addContact(c1);
                        }
                        Console.WriteLine("Contact successfully added...........Following are the details\n");
                        a.displayAll();
                        break;

                    case 2:
                        Console.WriteLine("Enter the first and last name of the contact seperated by space");
                        String edata1 = Console.ReadLine();
                        string[] edata = edata1.Split(" ");
                        Contact c = a.SearchUsingName(edata[0], edata[1]);
                        if (c == null)
                        {
                            Console.WriteLine("No such contacts found....Please enter correct input");
                            break;
                        }
                        Console.WriteLine("Following are the present details of the contact you chose to edit");
                        a.displayContact(c);
                        Console.WriteLine("Choose which detail you want to edit\n1.First Name\t2.Last Name\t3.Email\t4.Addresss\t5.Phone number");
                        int m = Convert.ToInt32(Console.ReadLine());
                        Contact cEdited = a.editContact(c, m);
                        Console.WriteLine("Here are the updated details");
                        a.displayContact(cEdited);
                        break;

                    case 3:
                        Console.WriteLine("Enter the first and last name of the contact you want to delete");
                        String ddata1 = Console.ReadLine();
                        string[] ddata = ddata1.Split(" ");
                        Contact cDel = a.SearchUsingName(ddata[0], ddata[1]);
                        if (cDel == null)
                        {
                            Console.WriteLine("No such contacts found....Please enter correct input");
                            break;
                        }
                        a.deleteContact(cDel);
                        Console.WriteLine("Contact successfully deleted\nFollowing is the contact list\n");
                        a.displayAll();
                        break;

                    case 4:
                        val = false;
                        break;

                    default: break;

                }
            }
        }
    }
}