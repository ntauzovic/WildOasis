using Ardalis.SmartEnum;

namespace WildOasis.Domain.Enums;

public abstract class Category : SmartEnum<Category>
{
    public static Category Bungalow = new BungalowCategory();
    public static Category Hotel = new HotelCategory();

    public static Category Motel = new MotelCategory();
    public static Category AutoCamp = new AutoCampCategory();
    
   

    public  abstract string Description { get; }

    public abstract List<Category> Subcategory { get; }

    public Category(string name, int value) : base(name, value)
    {
    }
    private sealed class BungalowCategory : Category
    {
        public BungalowCategory() : base( nameof(Bungalow), 1)
        {
        }

        public override string Description => "Bungalow for a peaceful getaway surrounded by nature's beauty";
        public override List<Category> Subcategory => new () { Bungalow, AutoCamp };
    }
    
    private sealed class HotelCategory : Category
    {
        public HotelCategory() : base( nameof(Hotel), 2)
        {
        }

        public override string Description => "hotel one of the best on south coast";
        public override List<Category> Subcategory => new List<Category>();
    }
    
    private sealed class MotelCategory : Category
    {
        public MotelCategory() : base( nameof(Motel), 3)
        {
        }

        public override string Description => "one of the best motel on south coast";
        public override List<Category> Subcategory => new List<Category>();
    }
    private sealed class AutoCampCategory : Category
    {
        public AutoCampCategory() : base( nameof(AutoCamp), 4)
        {
        }

        public override string Description => "AutoCampCategory";
        public override List<Category> Subcategory => new List<Category>();
    }
    
  

}

