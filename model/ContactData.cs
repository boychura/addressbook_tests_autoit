using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public int CompareTo(ContactData other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(ContactData other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
