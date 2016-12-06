namespace Models
{
    public class City : BaseEntity
    {
        public virtual int Id { get; set; }

        public virtual string TrajectActivityId { get; set; }

        public virtual Country Country { get; set; }
    }
}