using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaIntegradora4.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
