using AddressBookProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Updates in address book should reflect in contact.
        /// </summary>
        [TestMethod]
        public void UpdateInAddressBook_ChangeInContact()
        {
            //Arrange
            AddRepo addRepo = new AddRepo();

            //Act
            string type = addRepo.UpdateAddBook("Acquaintance","a");

            //Arrange
            Assert.AreEqual("Acquaintance",type);
        }

        /// <summary>
        /// Adds the mult employee record time.
        /// </summary>
        [TestMethod]
        public void AddMultEmployee_RecordTime()
        {
            //Arrange
            AddRepo addRepo = new AddRepo();

            //Act
            DateTime sd = DateTime.Now;
            addRepo.AddToContact_CheckTypeFromAddressDict("Abhimanyu","Roy","635876987","Colleagues");
            addRepo.AddToContact_CheckTypeFromAddressDict("Samay", "Raina", "84776987", "Friend");
            addRepo.AddToContact_CheckTypeFromAddressDict("Neha", "Roy", "9845976987", "Family");
            addRepo.AddToContact_CheckTypeFromAddressDict("Jeet", "Roy", "635876987", "Acquaintance");
            DateTime ed = DateTime.Now;

            //Arrange
            Console.WriteLine("Duration {0}", sd - ed);
        }

        /// <summary>
        /// Adds the mult employee record time withthread.
        /// </summary>
        [TestMethod]
        public void AddMultEmployee_RecordTimeWiththread()
        {
            //Arrange
            AddRepo addRepo = new AddRepo();
            //addRepo.DelAddressBookType();

            //Act
            DateTime sd = DateTime.Now;
            addRepo.AddToContact_CheckTypeFromAddressDictWithThread("Abhimanyu", "Roy", "635876987", "Family");
            addRepo.AddToContact_CheckTypeFromAddressDictWithThread("Samay", "Roy", "84776987", "Friend");
            addRepo.AddToContact_CheckTypeFromAddressDictWithThread("Neha", "Roy", "9845976987", "Family");
            addRepo.AddToContact_CheckTypeFromAddressDictWithThread("Jeet", "Roy", "635876987", "Acquaintance");
            DateTime ed = DateTime.Now;

            //Arrange
            //Assert.AreEqual(payroll.basicPay, sal);
            Console.WriteLine("Duration {0}", sd - ed);
        }
    }
}
