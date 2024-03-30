using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Penalty : Entity<Guid>
{
    public Guid ReturnedId { get; set; }
    public Guid PaymentId { get; set; }
    public decimal PenaltyPrice { get; set; } //Ceza ücreti.
    public int TotalPenaltyDays { get; set; } //Ceza yenilen gün sayısı returncreateddate-borrowedmaterialdeadline
    public bool PenaltyStatus { get; set; } //Ceza ödendi mi?
    //İlişki
    public virtual Returned? Returned { get; set; } = null;
    public virtual Payment? Payment { get; set; } = null;
    public Penalty()
    {

    }

    public Penalty(Guid paymentId, Guid returnedId, decimal penaltyPrice, int totalPenaltyDays, bool penaltyStatus)
    {
        ReturnedId = returnedId;
        PenaltyPrice = penaltyPrice;
        TotalPenaltyDays = totalPenaltyDays;
        PenaltyStatus = penaltyStatus;
        PaymentId = paymentId;
    }
}
