using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Domain
{
    public class Customer : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string FullName
        {
            get => FirstName + " " + LastName;
        }

        public string UserName { get; set; }

        public string Password { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
