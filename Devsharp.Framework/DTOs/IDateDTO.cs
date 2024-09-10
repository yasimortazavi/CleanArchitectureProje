﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Framwork.DTOs
{
    public interface IDateDTO
    {
         string LocalCreateOn { get; set; }
         string LocalUpdateOn { get; set; }
         DateTime CreateOn { get; set; }
         DateTime UpdateOn { get; set; }
    }
}
