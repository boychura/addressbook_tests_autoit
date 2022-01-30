using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";
        public static string DELETEPOPUP = "Question";
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();

            string count = aux.ControlTreeView(
                CONTACTWINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                    CONTACTWINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                    "GetText", "#0|#" + i, "");
                list.Add(new ContactData()
                {
                    Name = item
                });
            }

            return list;
        }

        private void WaitWin(string windowName)
        {
            aux.WinWait(windowName);
            aux.WinActivate(windowName);
            aux.WinWaitActive(windowName);
        }

        public void Add(ContactData newContact)
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            WaitWin(CONTACTWINTITLE);
            FillContactForm(newContact);
            CloseContactsDialog();
        }
        public void RemoveContact(int index)
        {
            SelectContact(index);
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d59");
            WaitWin(DELETEPOPUP);
            aux.ControlClick(DELETEPOPUP, "", "WindowsForms10.BUTTON.app.0.2c908d52");
        }

        public void FillContactForm(ContactData newContact)
        {
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d516");
            aux.Send(newContact.Name);
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d513");
            aux.Send(newContact.Surname);
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d520");
            aux.Send(newContact.Phone);
        }


        private void CloseContactsDialog()
        {
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
        }
        private void SelectContact(int index)
        {
            aux.ControlTreeView(
                CONTACTWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Select", "#0|#" + index + "", "");
        }
    }
}