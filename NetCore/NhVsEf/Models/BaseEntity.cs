using Common;

namespace Models
{
    public class BaseEntity : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
    }
}