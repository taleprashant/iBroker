using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iBroker.Entities;
using MySql.Data.MySqlClient;

namespace iBroker.DAL
{
    public class BuilderDAL : BaseDAL, IDisposable
    {
        private MySqlDataAdapter MyDA;
        MySqlCommandBuilder commandBuilder;

        ~BuilderDAL()
        {
            Connection.Close();
        }

        public BuilderDAL() :base()
        {
            this.MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select Id, Name, PhoneNo, email, headofficeaddress from builder", Connection);
            commandBuilder = new MySqlCommandBuilder(MyDA);
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public DataTable GetBuilders()
        {
            MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select * from builder", Connection);

            DataTable builders = new DataTable();
            MyDA.Fill(builders);

            return builders;
        }

        public void UpdateBuilder(DataTable builders)
        {
            MyDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            MyDA.InsertCommand = commandBuilder.GetInsertCommand();
            MyDA.Update(builders);
        }

        public Builder GetBuilder(string name)
        {
            string query = "select * from builder where name ='" + name + "'";
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand(query, Connection);

            DataTable builderTable = new DataTable();
            MyDA.Fill(builderTable);
            if (builderTable.Rows.Count > 0)
            {
                return new Builder
                {
                    Id = Convert.ToInt32(builderTable.Rows[0]["Id"]),
                    Name = builderTable.Rows[0]["Name"].ToString(),
                    PhoneNo = builderTable.Rows[0]["PhoneNo"].ToString(),
                    Address = builderTable.Rows[0]["HeadOfficeAddress"].ToString(),
                    Email = builderTable.Rows[0]["Email"].ToString(),
                };
            }
            else
            {
                return null;
            }
        }
    }
}
