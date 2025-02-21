namespace Exemplo.Entities;

public class EntityA
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime? CreationDate { get; set; }

    // public int? EntityBId { get; set; }
    public ICollection<EntityB> EntityBs{ get; set; } = [];
}