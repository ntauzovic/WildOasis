using Ardalis.GuardClauses;

namespace WildOasis.Domain.Entities;

public class Booking
{
    private Booking()
    {
    }

    public Booking(
        DateTime createAt,
        DateTime stardetAt,
        DateTime endAt,
        int numGuest,
        decimal cabinPrice,
        decimal extraPrice,
        decimal totalPrice,
        //Enum status,
        bool hasBrekfast,
        bool isPaid,
        string observation
        )
    {
        Id = Guid.NewGuid();
        CreateAt = Guard.Against.Null(createAt, nameof(createAt));
        StartedAt = Guard.Against.Null(stardetAt, nameof(stardetAt));
        EndAt = Guard.Against.Null(endAt, nameof(endAt));
        NumGuest = Guard.Against.NegativeOrZero(numGuest, nameof(numGuest));
        CabinPrice = Guard.Against.NegativeOrZero(cabinPrice, nameof(cabinPrice));
        ExtraPrice = Guard.Against.NegativeOrZero(extraPrice, nameof(extraPrice));
        TotalPrice = Guard.Against.NegativeOrZero(totalPrice, nameof(totalPrice));
        // Status provjeriti
        HasBreakfast = hasBrekfast; // Nema potrebe za proverom boolean vrednosti
        IsPaid = isPaid; // Nema potrebe za proverom boolean vrednosti
        Observation = observation; 
        
    }

    
    public Guid Id { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime EndAt { get; private set; }
    public int NumGuest { get; private set; }
    public decimal CabinPrice { get; private set; }
    public decimal ExtraPrice { get; private set; }
    public decimal TotalPrice { get; private set; }
    // public Enum Status { get; private set; } // Kako bi implementirali proveru za enum?
    public bool HasBreakfast { get; private set; }
    public bool IsPaid { get; private set; }
    public string Observation { get; private set; }

    public Booking AddCabin(Cabin cabin)
    {
        Cabin = cabin;
        return this;

    }
    public Cabin Cabin { get; set; }

    
    public Booking AddUser(ApplicationUser user)
    {
        User= user;
        return this;

    }
    public ApplicationUser User { get; set; }


}