using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            int index = 2;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.RemoveGroup(index);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(index);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}