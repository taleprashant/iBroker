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
    public class SourceDAL :IDisposable
    {
        private MySqlConnection Connection;
        private String ConnectionString;
        private MySqlDataAdapter MyDA;
        MySqlCommandBuilder commandBuilder;
        public SourceDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            this.MyDA = new MySqlDataAdapter();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
            MyDA.SelectCommand = new MySqlCommand("select id, source from source", Connection);
            commandBuilder = new MySqlCommandBuilder(MyDA);
        }

        ~SourceDAL()
        {
            MyDA.Dispose();
            Connection.Close();
        }

        public void Dispose()
        {
            MyDA.Dispose();
            Connection.Close();
        }

        public DataTable GetSources()
        {
            MyDA.SelectCommand = new MySqlCommand("select Id, Source from source", Connection);
            DataTable locations = new DataTable();
            MyDA.Fill(locations);

            return locations;
        }

        public void UpdateSources(DataTable sources)
        {
            MyDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            MyDA.InsertCommand = commandBuilder.GetInsertCommand();
            MyDA.Update(sources);

        }
    }
}
