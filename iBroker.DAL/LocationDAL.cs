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
    public class LocationDAL : IDisposable
    {
        private MySqlConnection Connection;
        private String ConnectionString;
        private MySqlDataAdapter MyDA;
        MySqlCommandBuilder commandBuilder;
        public LocationDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            this.MyDA = new MySqlDataAdapter();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
            MyDA.SelectCommand = new MySqlCommand("select Id, Location from location", Connection);
            commandBuilder = new MySqlCommandBuilder(MyDA);
        }

        ~LocationDAL()
        {
            MyDA.Dispose();
            Connection.Close();
        }

        public void Dispose()
        {
            MyDA.Dispose();
            Connection.Close();
        }

        public DataTable GetLocations()
        {
            MyDA.SelectCommand = new MySqlCommand("select Id, Location from location", Connection);
            DataTable locations = new DataTable();
            MyDA.Fill(locations);

            return locations;
        }

        public void UpdateLocations(DataTable locations)
        {
            MyDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            MyDA.InsertCommand = commandBuilder.GetInsertCommand();
            MyDA.Update(locations);
            
        }

        public void UpdateLocationMaster(string location)
        {
            MySqlCommand cmd = new MySqlCommand("select count(Id) from Location where LOWER(location) = '" + location.ToLower() + "'",
                Connection);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
            }
            else
            {
                string insertQuery = "insert into location (location) " +
                "values ('{0}')";
                insertQuery = String.Format(insertQuery, location);

                cmd = new MySqlCommand(insertQuery, Connection);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
            }
        }
    }
}
