using SparesFinder.Web.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparesFinder.Web.DAL.Abstracts
{
    public interface IDataManager
    {
        List<SalesByYear> getSalesByYear();
        List<SalesSummaryOfYear> getSalesSummaryOfYear(int year);
    }
}