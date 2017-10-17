using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparesFinder.Web.Models.DTO
{
    public class SalesSummaryOfYear
    {
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public int SalesOrderID { get; set; }
        public string ContactName { get; set; }
        public Decimal Total { get; set; }
    }
}
