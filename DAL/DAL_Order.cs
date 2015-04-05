using OrderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OrderApplication.DAL
{
    public class DAL_Order
    {
        public bool CreateOrder(Order order)
        {
            SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\OrderManagement\DB\test.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand sqlCmd = new SqlCommand(string.Format("insert into [Order] (OrderNumber,TotalPrice)values ({0},{1})", order.OrderId, order.Price), sqlConn);
            sqlConn.Open();
            sqlCmd.ExecuteNonQuery();
            foreach (Product p in order.Products)
            {
                sqlCmd = new SqlCommand(string.Format("insert into [Junction](ProductId,UserId,OrderId,Quantity) values ({0},{1},{2},{3})", p.ProductId, order.UserId, order.OrderId,p.Quantity), sqlConn);
                sqlCmd.ExecuteNonQuery();
            }
            return true;
        }


    }
}