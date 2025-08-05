public class EntityBase : IEntityBase
{
    public int Id { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Pending;
}