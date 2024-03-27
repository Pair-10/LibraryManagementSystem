using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Payment : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid PaymentTypeId { get; set; }
    public Guid OrderId { get; set; }
    public decimal PaymentPrice { get; set; }
    public string Desc { get; set; }
    //İlişki
    public virtual PaymentType? PaymentType { get; set; } = null; //1-çok ilişki
    public virtual User? User { get; set; } = null; // 1-çok ilişki 
    public virtual Penalty? Penalty { get; set; } = null; // 1-1 ilişki 
    public virtual Order? Order { get; set; } = null; // 1-1 ilişki
    public Payment()
    {

    }

    public Payment(Guid orderId, Guid userId, Guid paymentTypeId, decimal paymentPrice, string desc)
    {
        UserId = userId;
        OrderId = orderId;
        PaymentPrice = paymentPrice;
        Desc = desc;
        PaymentTypeId = paymentTypeId;
    }
}
