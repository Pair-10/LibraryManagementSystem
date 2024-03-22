﻿using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class EmaterialInvoice : Entity<Guid>
{
    public Guid EmaterialId { get; set; } // 
    public int Quantity { get; set; } // Miktar
    public decimal QuantityPrice { get; set; } // Birim Fiyat
    public decimal TotalPrice { get; set; } // Toplam Fiyat
    public string PaymentType { get; set; } // Ödeme Türü
    //ilişki
    public virtual Ematerial? Ematerial { get; set; } // FK
}

