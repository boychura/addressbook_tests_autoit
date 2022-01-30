using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class ContactRemovalTest : TestBase
    {
        [Test]
        public void TestContactRemoving()
        {
            int index = 1;

            //List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveContact(index);

            //List<ContactData> newContacts = app.Contacts.GetContactList();
            //oldContacts.RemoveAt(index);
            //oldContacts.Sort();
            //newContacts.Sort();

            //Assert.AreEqual(oldContacts, newContacts);
        }
    }
}