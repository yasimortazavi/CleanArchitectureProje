using Devsharp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Core
{
    public class BaseRelation :IEntity,  IUserModifer
    {
        public int CreateUser { get; set; }
        public int EditUser { get; set; }
        public int DeletedUser { get; set; }
    }
}
