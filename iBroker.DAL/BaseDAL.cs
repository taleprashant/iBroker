using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace iBroker.DAL
{
    public class BaseDAL
    {
        public MySqlConnection Connection;
        public String ConnectionString;

        public BaseDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
        }

        ~BaseDAL()
        {
            Connection.Close();
        }


    }
}
