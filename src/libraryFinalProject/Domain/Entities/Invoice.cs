using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Invoice : Entity<Guid>
{
    public DateTime InvoiceDate { get; set; } // fatura tarihi
    public decimal InvoicePrice { get; set; } // fatura tutarı
    public string InvoiceType { get; set; } // fatura türü
    public bool Status { get; set; } // fatura durumu
    
    public virtual Order? Order { get; set; } = null;
    public virtual ICollection<EmaterialInvoice>? EmaterialInvoices { get; set; } = null;
    public Invoice()
    {
    }

    public Invoice(DateTime invoiceDate, decimal invoicePrice, string invoiceType, bool status)
    {
        InvoiceDate = invoiceDate;
        InvoicePrice = invoicePrice;
        InvoiceType = invoiceType;
        Status = status;
    }
}
