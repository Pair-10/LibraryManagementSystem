using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Magazine : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public string ISSN { get; set; }
    public string Issue { get; set; }
    //İlişki
    public virtual Category? Category { get; set; } = null;

    public Magazine()
    {
    }

    public Magazine(Guid categoryId, string ıSSN, string ıssue)
    {
        CategoryId = categoryId;
        ISSN = ıSSN;
        Issue = ıssue;
    }
}