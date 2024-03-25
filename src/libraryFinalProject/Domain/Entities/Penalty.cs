using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Penalty : Entity<Guid>
{
    public Guid ReturnId { get; set; }
    public decimal PenaltyPrice { get; set; } //Ceza ücreti.
    public DateTime PenaltyDate { get; set; } //Ceza yenilen gün sayısı returncreateddate-borrowedmaterialdeadline
    public bool PenaltyStatus { get; set; } //Ceza ödendi mi?
    //İlişki
    public virtual Return? Return { get; set; } = null;
    public Penalty()
    {
        
    }

    public Penalty(Guid returnId, decimal penaltyPrice, DateTime penaltyDate, bool penaltyStatus)
    {
        ReturnId = returnId;
        PenaltyPrice = penaltyPrice;
        PenaltyDate = penaltyDate;
        PenaltyStatus = penaltyStatus;
    }
}
