using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Comment : Entity<Guid>
{
    public Guid MaterialId { get; set; } //
    public Guid UserId { get; set; } //
    public DateTime CommentDate { get; set; } // Yorum tarihi
    public string CommentDesc { get; set; } // Yorum açıklaması
    //ilişki kısmı
    public virtual Material? Material { get; set; } = null;//ilişki Fk
    public virtual User? User { get; set; } = null;//ilişki Fk
    public Comment()
    {
    }

    public Comment(Guid materialId, Guid userId, DateTime commentDate, string commentDesc)
    {
        MaterialId = materialId;
        UserId = userId;
        CommentDate = commentDate;
        CommentDesc = commentDesc;
    }
}

