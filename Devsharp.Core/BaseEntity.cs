using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core
{
    public abstract class BaseEntity 
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        
        public int CreateUser { get; set; }
        public int EditUser { get; set; }
      
    }
}
