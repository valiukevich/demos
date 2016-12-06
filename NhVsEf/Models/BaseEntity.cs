namespace Models
{
    using Core;

    public class BaseEntity: IEntity
    {
        public virtual string Id { get; set; }
    }
}