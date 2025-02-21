namespace  Exemplo.Entities;


public class EntityB
{
    public int Id { get; set;}
    public  string? Name { get; set;}

    public ICollection<EntityA> EntityAs { get; set; } = [];

    // public int EntityAId { get; set;}
    // public EntityA? EntityA{ get; set;}
}