using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iBroker.Entities;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace iBroker.DAL
{
    public class CustomerDAL : IDisposable
    {
        private MySqlConnection Connection;
        private String ConnectionString;

        public CustomerDAL()
        {
           this.ConnectionString= ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
        }

        ~CustomerDAL()
        {
            Connection.Close();
        }

        public Customer GetCustomer(int clientId = 0, string phoneNo = null)
        {
            string query = string.Empty;
            if (clientId != 0)
            {
                query = "select * from customer where id=" + clientId;
            }
            else if (phoneNo != null)
            {
                query = "select * from customer where phoneno1='" + phoneNo + "' or phoneno2='" + phoneNo + "'";
            }


            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand(query, Connection);

            DataTable customerTable = new DataTable();
            MyDA.Fill(customerTable);
            if (customerTable.Rows.Count > 0)
            {
                return new Customer
                {
                    Id = Convert.ToInt32(customerTable.Rows[0]["Id"]),
                    FirstName = customerTable.Rows[0]["FirstName"].ToString(),
                    LastName = customerTable.Rows[0]["LastName"].ToString(),
                    PhoneNo1 = customerTable.Rows[0]["PhoneNo1"].ToString(),
                    PhoneNo2 = customerTable.Rows[0]["PhoneNo2"].ToString(),
                    Email = customerTable.Rows[0]["Email"].ToString(),
                    FlatNo = customerTable.Rows[0]["FlatNo"].ToString(),
                    Society = customerTable.Rows[0]["Society"].ToString(),
                    Landmark = customerTable.Rows[0]["Landmark"].ToString(),
                    City = customerTable.Rows[0]["City"].ToString(),
                    State = customerTable.Rows[0]["State"].ToString(),
                    Country = customerTable.Rows[0]["Country"].ToString(),
                    AddressOther = customerTable.Rows[0]["AddressOther"].ToString(),
                };
            }
            else
            {
                return null;
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public int Insert(Customer customer)
        {
            string insertQuery = "insert into customer (FirstName, PhoneNo1, PhoneNo2, Email, AddressOther) " +
                "values ('{0}','{1}','{2}','{3}','{4}')";
            insertQuery = String.Format(insertQuery, customer.FirstName, customer.PhoneNo1, customer.PhoneNo2, customer.Email,customer.AddressOther);
           
            MySqlCommand cmd = new MySqlCommand(insertQuery, Connection);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return Convert.ToInt32(id);
        }

        public int Update(Customer customer)
        {
            string updateQuery = "update customer set FirstName='{0}', PhoneNo1='{1}', PhoneNo2='{2}', Email='{3}',AddressOther='{4}' " +
                " where id=" + customer.Id;
            updateQuery = String.Format(updateQuery, customer.FirstName, customer.PhoneNo1, customer.PhoneNo2, customer.Email,
                customer.AddressOther);

            MySqlCommand cmd = new MySqlCommand(updateQuery, Connection);
            cmd.ExecuteNonQuery();
            return customer.Id;
        }

        public bool CustomeExists(Customer customer)
        {
            MySqlCommand cmd = new MySqlCommand("select count(Id) from customer where phoneno1 = '" + customer.PhoneNo1 + "' or phoneno2= '" + customer.PhoneNo1 + "'",
                Connection);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if(count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
