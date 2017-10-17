
using SparesFinder.Web.DAL.Abstracts;
using SparesFinder.Web.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SparesFinder.Web.DAL
{
    public class DataManager : IDataManager
    {
        public List<SalesByYear> getSalesByYear()
        {

            var result = new List<SalesByYear>();
            var connectionString =
                @"Data Source=.\sqlexpress;Initial Catalog=AdventureWorks2008;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn;
            SqlCommand cmd;
            using (conn = new SqlConnection(connectionString))


            using (cmd = new SqlCommand("sp_GetSalesByYear", conn))

            {
                try
                {


                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new SalesByYear
                        {
                            Year = (int)reader["OrderYear"],
                            ShippedInDays = (int)reader["TimeToShip"],
                            Total = (Decimal)reader["Total"]

                        });
                        // Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
                catch (Exception ex)
                {
                    //todo logger
                    throw;
                }
            }
            return result;
        }


        public List<SalesSummaryOfYear> getSalesSummaryOfYear(int year)
        {
            var result = new List<SalesSummaryOfYear>();
            var connectionString =
                @"Data Source=.\sqlexpress;Initial Catalog=AdventureWorks2008;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn;
            SqlCommand cmd;
            using (conn = new SqlConnection(connectionString))


            using (cmd = new SqlCommand("sp_SalesOrderDetailsByYear", conn))

            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SalesYear", year));
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new SalesSummaryOfYear
                        {
                            OrderDate = (string)reader["OrderDate"],
                            ShipDate = (string)reader["ShipDate"],
                            SalesOrderID = (int)reader["SalesOrderID"],
                            ContactName = (string)reader["CustomerName"],
                            Total = (Decimal)reader["Total"],

                        });
                        // Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
                catch (Exception ex)
                {
                    //todo logger
                    throw;
                }

            }
            return result;
        }
    }
}