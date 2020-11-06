using AddressBookProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UpdateInAddressBook_ChangeInContact()
        {
            //Arrange
            AddRepo addRepo = new AddRepo();
            Contact payroll = new Contact();

            //Act
            string type = addRepo.UpdateAddBook("Acquaintance","a");

            //Arrange
            Assert.AreEqual("Acquaintance",type);
        }
    }
}
