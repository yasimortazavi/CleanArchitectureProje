using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Framwork.DTOs
{
    public class BaseEntityDTO : BaseDto,IDateDTO
    {
        public int ID { get; set; }
        public string LocalCreateOn { get; set; }
        public string LocalUpdateOn { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
