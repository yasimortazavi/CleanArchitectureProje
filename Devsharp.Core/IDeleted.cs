﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Interface
{
    public interface IDeleted
    {
        public bool Deleted { get; set; }
        public DateTime DeleteDate { get; set; }
        public int DeletedUser { get; set; }
    }
}
