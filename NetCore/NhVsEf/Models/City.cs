using System;
using System.Collections.Generic;

namespace Models
{
    public class City : BaseEntity
    {
        public virtual Country Country { get; set; }
    }
}
