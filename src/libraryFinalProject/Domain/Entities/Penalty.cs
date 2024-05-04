//using NArchitecture.Core.Persistence.Repositories;

//namespace Domain.Entities;
//public class Penalty : Entity<Guid>
//{
//    public Guid ReturnedId { get; set; }
//    public Guid UserId { get; set; }
//    public decimal PenaltyPrice { get; set; } //Ceza ücreti.
//    public int TotalPenaltyDays { get; set; } //Ceza yenilen gün sayısı returncreateddate-borrowedmaterialdeadline
//    public bool PenaltyStatus { get; set; } //Ceza ödendi mi?
//    //İlişki
//    public virtual Returned? Returned { get; set; } = null;
//    public virtual Payment? Payment { get; set; } = null;
//    public Penalty()
//    {

//    }

//    public Penalty( Guid returnedId, decimal penaltyPrice, int totalPenaltyDays, bool penaltyStatus, Guid userId)
//    {
//        ReturnedId = returnedId;
//        PenaltyPrice = penaltyPrice;
//        TotalPenaltyDays = totalPenaltyDays;
//        PenaltyStatus = penaltyStatus;
//        UserId = userId;
//    }
//}
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Penalty : Entity<Guid>
{
    public Guid ReturnedId { get; set; }
    public Guid UserId { get; set; }
    public Guid MaterialId { get; set; }
    public decimal PenaltyPrice { get; set; } //Ceza ücreti.
    public int TotalPenaltyDays { get; set; } //Ceza yenilen gün sayısı returncreateddate-borrowedmaterialdeadline
    public bool PenaltyStatus { get; set; } //Ceza ödendi mi?
    //İlişki
    public virtual Returned? Returned { get; set; } = null;
    public virtual Payment? Payment { get; set; } = null;
    public Penalty()
    {

    }

    public Penalty(Guid returnedId, decimal penaltyPrice, int totalPenaltyDays, bool penaltyStatus, Guid userId)
    {
        ReturnedId = returnedId;
        PenaltyPrice = penaltyPrice;
        TotalPenaltyDays = totalPenaltyDays;
        PenaltyStatus = penaltyStatus;
        UserId = userId;
    }
}
