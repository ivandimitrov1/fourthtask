using System;
using System.Collections.Generic;

namespace Fourth.Infrastructure.Data.Entities;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
