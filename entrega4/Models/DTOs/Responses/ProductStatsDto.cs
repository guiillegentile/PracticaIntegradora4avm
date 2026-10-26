using System;
using System.Collections.Generic;
using System.Text;
namespace PracticaIntegradora4.Models.DTOs.Responses;

public class ProductStatsDto
{
    public int Total { get; set; }
    public decimal AveragePrice { get; set; }
    public string MostExpensiveName { get; set; } = string.Empty;
}