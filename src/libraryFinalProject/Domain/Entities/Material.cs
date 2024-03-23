using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;
public class Material : Entity<Guid>
{
    public Guid PublisherId { get; set; } //
    public Guid AuthorId { get; set; } //
    public string ISBN { get; set; }
    public DateTime PublicationDate { get; set; } // Yayımlanma tarihi
    public string Language { get; set; } // Dil
    public int PageCount { get; set; } // Sayfa sayısı
    public string Status { get; set; } // Durumu ( mevcut, ödünç verildi, kayıp gibi)
    public string MaterialName { get; set; } // Materyal adı
    public byte[] MaterialImage { get; set; } // Materyalin resmi
    public int Quantity { get; set; }//miktar
    //ilişki kısmı
    public virtual Publisher? Publisher { get; set; } = null;//Fk yayınevi tablosu ilişkisi
    public virtual Author? Author { get; set; } = null;//Fk yazar tablosu ilişkisi
    //Bir materyalin birden çok rezervasyonu  olabilir
    public virtual ICollection<Reservation>? Reservations { get; set; } = null;
    //Bir materyalin birden çok kategorituru olabilir
    public ICollection<CategoryType>?CategoryTypes { get; set; }=null;
    //Bir materyalin birden çok materyalçevirmeni olabilir
    public virtual ICollection<MaterialTranslator>? MaterialTranslators { get; set; } = null;
    //Bir materyalin  birden fazla yorumu olabilir
    public virtual ICollection<Comment>? Comments { get; set; } = null;
    //Bir materyalin birden fazla materyalkonumu olabilir
    public virtual ICollection<MaterialLocation>? MaterialLocations { get; set; } = null;
    //Bir materyalin birden fazla OduncAldıgiMetaryali olabilir
    public ICollection<BorrowedMaterial>? BorrowedMaterials { get; set; } = null;
    public Material()
    {
    }

    public Material(Guid publisherId, Guid authorId, string iSBN, DateTime publicationDate, string language, 
        int pageCount, string status, string materialName, byte[] materialImage, int quantity)
    {
        PublisherId = publisherId;
        AuthorId = authorId;
        ISBN = iSBN;
        PublicationDate = publicationDate;
        Language = language;
        PageCount = pageCount;
        Status = status;
        MaterialName = materialName;
        MaterialImage = materialImage;
        Quantity = quantity;
    }
}