using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace iBroker.DAL
{
    public class SocietyDAL
    {
        private MySqlConnection Connection;
        private String ConnectionString;
        private MySqlDataAdapter MyDA;
        MySqlCommandBuilder commandBuilder;
        public SocietyDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            this.MyDA = new MySqlDataAdapter();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
            MyDA.SelectCommand = new MySqlCommand("select Id, Societyname from society", Connection);
            commandBuilder = new MySqlCommandBuilder(MyDA);
        }

        ~SocietyDAL()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public DataTable GetSocieties()
        {
            MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select Id, SocietyName from society", Connection);

            DataTable societies = new DataTable();
            MyDA.Fill(societies);

            return societies;
        }

        public void UpdateSocieties(DataTable societies)
        {
            MyDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            MyDA.InsertCommand = commandBuilder.GetInsertCommand();
            MyDA.Update(societies);
        }

        public void UpdateSocietyMaster(string societyName)
        {
            MySqlCommand cmd = new MySqlCommand("select count(Id) from society where LOWER(SocietyName) = '" + societyName.ToLower() + "'",
                Connection);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
            }
            else
            {
                string insertQuery = "insert into society (SocietyName) " +
                "values ('{0}')";
                insertQuery = String.Format(insertQuery, societyName);

                cmd = new MySqlCommand(insertQuery, Connection);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
            }
        }
    }
}
