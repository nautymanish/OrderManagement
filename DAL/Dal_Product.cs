using OrderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OrderApplication.DAL
{
    public class DAL_Product
    {
        public List<Product> GetProducts()
        {
            SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\OrderManagement\DB\test.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand sqlCmd = new SqlCommand(string.Format("select * from dbo.Product"), sqlConn);
            sqlConn.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            List<Product> lstProducts = new List<Product>();
            try
            {
                while (dr.Read())
                {
                    lstProducts.Add(new Product(Convert.ToInt32(dr["ProductId"].ToString()),dr["ProductName"].ToString(),Convert.ToDouble(dr["ProductPrice"].ToString()),0));
                }
            }
            catch {  }
            return lstProducts; 
        }


    }
}