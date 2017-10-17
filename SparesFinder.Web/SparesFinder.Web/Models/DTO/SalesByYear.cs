using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparesFinder.Web.Models.DTO
{
    public class SalesByYear
    {
        public int Year { get; set; }
        public int ShippedInDays { get; set; }
        public Decimal Total { get; set; }
    }
}