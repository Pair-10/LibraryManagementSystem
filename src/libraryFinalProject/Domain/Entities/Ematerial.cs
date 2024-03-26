using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Ematerial : Entity<Guid>
{
    public Guid CategoryTypeId { get; set; }//
    public decimal Price { get; set; }//Fiyat
    public string PdfUrl { get; set; }
    //ilişki
    public virtual CategoryType? CategoryType { get; set; } = null;//Fk

    //Bir emetaryelin birden çok sepetemetaryeli olabilir
    public virtual ICollection<BasketEmaterial>? BasketEmeterials { get; set; } = null;
    //Bir Emetaryelin birden çok EmateryalFaturalası olabilir
    public virtual ICollection<EmaterialInvoice>? Invoices { get; set; } = null;
    //Bir Emetaryelin birden çok EmateryalSiparisi olabilir
    public ICollection<OrderEMaterial>? OrderEMaterials { get; set; } = null;

    public Ematerial()
    {

    }
    public Ematerial(Guid categoryTypeId, decimal price, string pdfUrl)
    {
        CategoryTypeId = categoryTypeId;
        Price = price;
        PdfUrl = pdfUrl;
    }
}

