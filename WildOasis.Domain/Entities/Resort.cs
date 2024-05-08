namespace WildOasis.Domain.Entities;

public class Resort
{
    public Resort(
        string name,
        string description,
        string address,uint number)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Address = address;
        Number = number;
    }

    private Resort()
    {
    }

    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Description { get;  set; }
    public string Address { get;  set; }
    public uint Number { get; set; }

    public IList<Cabin> Cabins { get; } = new List<Cabin>();
}