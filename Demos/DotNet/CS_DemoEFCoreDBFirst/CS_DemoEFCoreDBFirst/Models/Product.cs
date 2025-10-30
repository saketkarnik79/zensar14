﻿using System;
using System.Collections.Generic;

namespace CS_DemoEFCoreDBFirst.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }
}
