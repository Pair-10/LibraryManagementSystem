using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Book : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public string ISBN { get; set; }
    //İlişki
    public virtual Category? Category { get; set; } = null;

    public Guid MaterialId { get; set; }

    public Book()
    {
    }

    public Book(Guid categoryId, string iSBN)
    {
        CategoryId = categoryId;
        ISBN = iSBN;
    }
}
