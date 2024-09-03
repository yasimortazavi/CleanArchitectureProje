﻿using Devsharp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Core
{
    public abstract class BaseEntity : IEntity, IDateEntity, IUserModifer
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        
        public int CreateUser { get; set; }
        public int EditUser { get; set; }
      
    }
}
