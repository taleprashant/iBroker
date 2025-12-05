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
    public class PropertyTypeDAL
    {
        private MySqlConnection Connection;
        private String ConnectionString;
        private MySqlDataAdapter MyDA;
        MySqlCommandBuilder commandBuilder;
        public PropertyTypeDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            this.MyDA = new MySqlDataAdapter();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
            MyDA.SelectCommand = new MySqlCommand("select Id, PropertyType, PropertySubType from PropertyType", Connection);
            commandBuilder = new MySqlCommandBuilder(MyDA);
        }

        ~PropertyTypeDAL()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public DataTable GetPropertyTypes()
        {
            MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select Id, PropertyType, PropertySubType from PropertyType", Connection);

            DataTable propTypes = new DataTable();
            MyDA.Fill(propTypes);

            return propTypes;
        }

        public void UpdatePropTypes(DataTable propTypes)
        {
            MyDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            MyDA.InsertCommand = commandBuilder.GetInsertCommand();
            MyDA.Update(propTypes);
        }

        public DataTable GetDistinctPropertyTypes()
        {
            MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select distinct PropertyType from PropertyType", Connection);

            DataTable propTypes = new DataTable();
            MyDA.Fill(propTypes);

            return propTypes;
        }

        public DataTable GetDistinctPropertySubTypes(string propType)
        {
            MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select distinct propertysubtype from PropertyType where propertytype = '" + propType + "'", Connection);

            DataTable propTypes = new DataTable();
            MyDA.Fill(propTypes);

            return propTypes;
        }
    }
}
