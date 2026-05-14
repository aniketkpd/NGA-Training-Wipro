using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }
}
