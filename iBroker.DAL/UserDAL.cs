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
    public class UserDAL
    {
        private MySqlConnection Connection;
        private String ConnectionString;
        public UserDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
        }

        ~UserDAL()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public DataTable GetAllUsers()
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select u.id, u.FirstName, u.LastName, u.PhoneNo1, u.PhoneNo2, u.Email, (select role from role r where r.id = u.roleid) as role, password from user u", Connection);

            DataTable users = new DataTable();
            MyDA.Fill(users);

            return users;
        }

        public int Insert(User user)
        {
            string insertQuery = "insert into user (FirstName, LastName, PhoneNo1, PhoneNo2, Email, RoleId, Password) " +
                "values ('{0}','{1}','{2}','{3}','{4}', {5},'{6}')";
            insertQuery = String.Format(insertQuery, user.FirstName, user.LastName, user.PhoneNo1, user.PhoneNo2, user.Email, user.RoleId, user.Password);

            MySqlCommand cmd = new MySqlCommand(insertQuery, Connection);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return Convert.ToInt32(id);
        }

        public int Update(User user)
        {
            string updateQuery = "update user set FirstName='{0}', LastName='{1}', PhoneNo1='{2}', PhoneNo2='{3}', Email='{4}', RoleId={5}, Password='{6}' " +
                " where id=" + user.Id;
            updateQuery = String.Format(updateQuery, user.FirstName, user.LastName, user.PhoneNo1, user.PhoneNo2, user.Email,
                user.RoleId, user.Password);

            MySqlCommand cmd = new MySqlCommand(updateQuery, Connection);
            cmd.ExecuteNonQuery();
            return user.Id;
        }

        public bool UserExists(User user)
        {
            MySqlCommand cmd = new MySqlCommand("select count(Id) from user where phoneno1 = '" + user.PhoneNo1 + "' or phoneno2= '" + user.PhoneNo1 + "'",
                Connection);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                return true;
            }

            return false;
        }

        public User ValidateUser(string phoneNo, string password)
        {
            string query = string.Format("select * from user where (phoneno1 = '{0}' or phoneno2= '{0}') and password='{1}'", phoneNo, password);
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand(query, Connection);

            DataTable customerTable = new DataTable();
            MyDA.Fill(customerTable);
            if (customerTable.Rows.Count > 0)
            {
                return new User
                {
                    Id = Convert.ToInt32(customerTable.Rows[0]["Id"]),
                    FirstName = customerTable.Rows[0]["FirstName"].ToString(),
                    LastName = customerTable.Rows[0]["LastName"].ToString(),
                    PhoneNo1 = customerTable.Rows[0]["PhoneNo1"].ToString(),
                    PhoneNo2 = customerTable.Rows[0]["PhoneNo2"].ToString(),
                    Email = customerTable.Rows[0]["Email"].ToString(),
                    Password = customerTable.Rows[0]["Password"].ToString(),
                    RoleId = Convert.ToInt32(customerTable.Rows[0]["RoleId"]),
                };
            }
            else
            {
                return null;
            }
        }

        public DataTable Roles()
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select id,role from role", Connection);

            DataTable roles = new DataTable();
            MyDA.Fill(roles);

            return roles;
        }
    }
}
