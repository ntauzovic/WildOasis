using WildOasis.Domain.Enums;

namespace WildOasis.Domain.Entities;

public class Cabin
{
    private Cabin()
    {
    }
    public Cabin(
        string name,
        string description,
        int maxCapacity,
        int regularPrice,
        int discount,
        string image,
        Category category)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        MaxCapacity = maxCapacity;
        RegularPrice = regularPrice;
        Discount = discount;
        Image = image;
        Category = category;

    }

    public Cabin AddResort(Resort resort)
    {
        Resort = resort;
        return this;

    }

    public Guid Id { get;  set; }
    public string Name { get;  set; }
    public string Description { get;  set; }
    public int MaxCapacity { get; set; }
    public int RegularPrice { get;  set; }
    public int Discount { get; set; }
    public string Image { get;  set; }
    public Category Category { get; private set; }

    public Resort Resort
    {
        get;
         set;
    } 

    
   
}