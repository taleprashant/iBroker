using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iBroker.Entities;
using MySql.Data.MySqlClient;

namespace iBroker.DAL
{
    public class BrokerDAL
    {
        private MySqlConnection Connection;
        private String ConnectionString;
        private MySqlDataAdapter MyDA;
        MySqlCommandBuilder commandBuilder;
        public BrokerDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            this.MyDA = new MySqlDataAdapter();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
            MyDA.SelectCommand = new MySqlCommand("select Id, Name, PhoneNo1, phoneno2, email, location, city, state from broker", Connection);
            commandBuilder = new MySqlCommandBuilder(MyDA);
        }

        ~BrokerDAL()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public DataTable GetBrokers()
        {
            MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select * from broker", Connection);

            DataTable societies = new DataTable();
            MyDA.Fill(societies);

            return societies;
        }

        public void UpdateBrokers(DataTable brokers)
        {
            MyDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            MyDA.InsertCommand = commandBuilder.GetInsertCommand();
            MyDA.Update(brokers);
        }

        public Broker GetBroker(string name)
        {
            string query = "select * from broker where name ='" + name + "'";
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand(query, Connection);

            DataTable customerTable = new DataTable();
            MyDA.Fill(customerTable);
            if (customerTable.Rows.Count > 0)
            {
                return new Broker
                {
                    Id = Convert.ToInt32(customerTable.Rows[0]["Id"]),
                    Name = customerTable.Rows[0]["Name"].ToString(),
                    PhoneNo1 = customerTable.Rows[0]["PhoneNo1"].ToString(),
                    PhoneNo2 = customerTable.Rows[0]["PhoneNo2"].ToString(),
                    Email = customerTable.Rows[0]["Email"].ToString(),
                    City = customerTable.Rows[0]["City"].ToString(),
                    State = customerTable.Rows[0]["State"].ToString(),
                };
            }
            else
            {
                return null;
            }
        }
    }
}
