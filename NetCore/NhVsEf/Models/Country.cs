using System.Collections.Generic;

namespace Models
{
    public class Country : BaseEntity
    {
        public virtual ICollection<City> Cities { get; set; }
    }
}