namespace Models
{
    using System.Collections.Generic;

    public class Country : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}