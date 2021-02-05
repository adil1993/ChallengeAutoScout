using Data_Transfer_Object;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAutoScout24
{
  [TestClass]
  public class ContactTests
  {
    /// <summary>
    /// 
    /// </summary>
    [TestMethod]
    public void ContactTestConstructor()
    {
      double dateInTimeStamp = 1583314000000;
      var contactDateTime = Contact.UnixTimeStampToDateTime(dateInTimeStamp);

      Contact contact = new Contact(1101, contactDateTime);

      Assert.AreEqual(contact.listingId, 1101);
      Assert.AreEqual(contact.ContactDate.Date.Day, 4);
      Assert.AreEqual(contact.ContactDate.Date.Month, 3);
      Assert.AreEqual(contact.ContactDate.Date.Year, 2020);
    }

    /// <summary>
    /// 
    /// </summary>
    [TestMethod]

    public void UnixTimeStampTest()
    {
      double dateInTimeStamp = 1583314000000;
      var contactDateTime = Contact.UnixTimeStampToDateTime(dateInTimeStamp);

      Assert.AreEqual(contactDateTime.Date.Day, 4);
      Assert.AreEqual(contactDateTime.Date.Month, 3);
      Assert.AreEqual(contactDateTime.Date.Year, 2020);
    }
  }
}
