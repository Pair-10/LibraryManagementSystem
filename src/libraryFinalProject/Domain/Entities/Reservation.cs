using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Reservation : Entity<Guid>
{
   
    public Guid UserId { get; set; } //
     public Guid MaterialId { get; set; } //
    public DateTime ReservationDate { get; set; } // Rezervasyon tarihi
    public string Status { get; set; } // Durumu (onaylandı, bekliyor, iptal edildi)
    //ilişki kısmı
    public virtual User? User { get; set; } = null; //Fk kullanıcı tablosu ilişkisi
    public virtual Material? Material { get; set; } = null;//FK materyal tablosu ilişkisi
    public Reservation()
    {
    }

    public Reservation(Guid userId, Guid materialId, DateTime reservationDate, string status)
    {
        UserId = userId;
        MaterialId = materialId;
        ReservationDate = reservationDate;
        Status = status;
    }
}
