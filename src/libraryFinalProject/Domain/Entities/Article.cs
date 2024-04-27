using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Article : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public string PublictionName { get; set; }
    //İlişki
    public virtual Category? Category { get; set; } = null;

    public Guid MaterialId { get; set; }
    public Article()
    {
    }

    public Article(Guid categoryId, string publictionName)
    {
        CategoryId = categoryId;
        PublictionName = publictionName;
    }
}