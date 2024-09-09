using Devsharp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Core
{
    public abstract class BaseEntity : Entity, IDateEntity, IUserModifer
    {
        public int ID { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        
        public int CreateUser { get; set; }
        public int EditUser { get; set; }
      
    }
}
