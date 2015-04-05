using OrderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OrderApplication.DAL
{
    public class DAL_User
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\OrderManagement\DB\test.mdf;Integrated Security=True;Connect Timeout=30");
        public bool CreateUser(User user)
        {
            
            SqlCommand sqlCmd = new SqlCommand(string.Format("INSERT INTO [dbo].[User] ( [UserName], [UserPassword], [ActivationKey]) values('{0}','{1}','{2}')", user.name, user.pass, user.activationKey), sqlConn);
            sqlConn.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
            return true;
        }

        public bool Login(ref User user)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand(string.Format("select IsActivated  from [dbo].[User] where( [UserName]='{0}' and [UserPassword]='{1}' and [ActivationKey]='{2}')", user.name, user.pass, user.activationKey), sqlConn);
                sqlConn.Open();
                bool IsUserPresent = (bool)sqlCmd.ExecuteScalar();
                if (!IsUserPresent)
                {
                    sqlCmd = new SqlCommand(string.Format("UPDATE [dbo].[User] set IsActivated=1   where( [UserName]='{0}' and [UserPassword]='{1}' and [ActivationKey]='{2}')", user.name, user.pass, user.activationKey), sqlConn);
                    sqlCmd.ExecuteNonQuery();
                }
                sqlCmd = new SqlCommand(string.Format("Select Id from [dbo].[User]  where( [UserName]='{0}' and [UserPassword]='{1}' and [ActivationKey]='{2}')", user.name, user.pass, user.activationKey), sqlConn);
                user.ID=(int)sqlCmd.ExecuteScalar();
                return true;
            }
            catch { return false; }
        }


        internal bool Login(ref User user, bool p)
        {
            SqlCommand sqlCmd = new SqlCommand(string.Format("select IsActivated  from [dbo].[User] where( [UserName]='{0}' and [UserPassword]='{1}' )", user.name, user.pass), sqlConn);
            sqlConn.Open();
            try
            {
                bool IsUserPresent = (bool)sqlCmd.ExecuteScalar();
                sqlCmd = new SqlCommand(string.Format("Select [UserId] from [dbo].[User]  where( [UserName]='{0}' and [UserPassword]='{1}' and IsActivated=1 )", user.name, user.pass), sqlConn);
                user.ID = (int)sqlCmd.ExecuteScalar();
                return IsUserPresent;
            }
            catch { return false; }
        }
    }
}