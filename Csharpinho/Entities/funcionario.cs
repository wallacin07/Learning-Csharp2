namespace Exemplo.Entities;

public class Usuario{
    public Guid Id { get; set;} = Guid.NewGuid();
    public string Name { get; set;}
    public ICollection<Seguindo> Seguindo { get; set;}
     public ICollection<Seguindo> Seguidores { get; set;}
}

public class Seguindo
{
    public Guid Id { get; set;} = Guid.NewGuid();

    public Guid SeguidoId { get; set;}
    public Usuario Seguido {get; set;}

    public Guid SeguidorId { get; set;}
    public Usuario Seguidor {get; set;}
}