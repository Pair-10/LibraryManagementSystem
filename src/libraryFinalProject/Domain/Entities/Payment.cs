using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Payment : Entity<Guid>
{
    public bool PaymentType { get; set; }
    public Guid UserId { get; set; }
    public decimal PaymentPrice { get; set; }
    public string Desc { get; set; }
    public virtual User? User { get; set; } = null; // 1-çok ilişki 
    public virtual Penalty? Penalty { get; set; } = null; // 1-1 ilişki 
    public virtual Order? Order { get; set; } = null; // 1-1 ilişki
    public Payment()
    {

    }

    public Payment(bool paymentType, Guid userId, decimal paymentPrice, string desc)
    {
        PaymentType = paymentType;
        UserId = userId;
        PaymentPrice = paymentPrice;
        Desc = desc;
    }
}
