using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            WaitWin(GROUPWINTITLE);

            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", 
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                    GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "GetText", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }

            CloseGroupsDialog();
            return list;
        }

        public void RemoveGroup(int index)
        {
            OpenGroupsDialog();
            SelectGroup(index);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            WaitWin(DELGROUPWINTITLE);
            aux.ControlClick(DELGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlClick(DELGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupsDialog();
        }

        private void WaitWin(string windowName)
        {
            aux.WinWait(windowName);
            aux.WinActivate(windowName);
            aux.WinWaitActive(windowName);
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialog();
        }

        private void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }


        private void SelectGroup(int index)
        {
            aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Select", "#0|#" + index + "", "");
        }
    }
}