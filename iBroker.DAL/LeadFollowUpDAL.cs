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
    public class LeadFollowUpDAL :IDisposable
    {
        private MySqlConnection Connection;
        private String ConnectionString;

        public LeadFollowUpDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
        }

        ~LeadFollowUpDAL()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public void SaveAll(DataTable leadFollowUpTable)
        {
            string sql = "INSERT INTO LeadFollowUp (leadid, date, comment, followupby, reminderdate, shownby, status) " +
                "VALUES (@leadid, @date, @comment, @followupby, @reminderdate, @shownby, @status)";

            string updateSql = "UPDATE LeadFollowUp SET leadid=@leadid, date=@date, comment=@comment, followupby=@followupby, reminderdate=@reminderdate, " +
                "shownby= @shownby, status=@status where id=@id";

            foreach (DataRow r in leadFollowUpTable.Rows)
            {
                MySqlCommand cmd = Connection.CreateCommand();

                cmd.Parameters.AddWithValue("@leadid", r["leadid"]);
                cmd.Parameters.AddWithValue("@date", r["Date"]);
                cmd.Parameters.AddWithValue("@comment", r["Comment"]);
                cmd.Parameters.AddWithValue("@followupby", r["FollowUpBy"]);
                cmd.Parameters.AddWithValue("@reminderdate", r["ReminderDate"]);
                cmd.Parameters.AddWithValue("@shownby", r["shownby"]);
                cmd.Parameters.AddWithValue("@status", r["status"]);

                if (Convert.ToInt32(r["Id"]) != 0)
                {
                    cmd.CommandText = updateSql;
                    cmd.Parameters.AddWithValue("@id", r["Id"]);
                }
                else
                {
                    cmd.CommandText = sql;
                    //cmd.Parameters.AddWithValue("@leadid", r["leadid"]);
                    //cmd.Parameters.AddWithValue("@date", r["Date"]);
                    //cmd.Parameters.AddWithValue("@comment", r["Comment"]);
                    //cmd.Parameters.AddWithValue("@followupby", r["FollowUpBy"]);
                    //cmd.Parameters.AddWithValue("@reminderdate", r["ReminderDate"]);
                    //cmd.Parameters.AddWithValue("@shownby", r["shownby"]);
                }
                
                cmd.ExecuteNonQuery();
            }
            
        }

        public DataTable GetLeadFollowUps(int leadId)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select * from leadfollowup where leadid=" + leadId + " order by Date desc", Connection);

            DataTable followUpTable = new DataTable();
            MyDA.Fill(followUpTable);

            return followUpTable;
        }

        public DataTable GetLeadFollowUps(string date)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            //MyDA.SelectCommand = new MySqlCommand("select * from leadfollowup where reminderdate='" + date + "'", Connection);

            //DataTable followUpTable = new DataTable();
            //MyDA.Fill(followUpTable);
            //followUpTable.Columns.Add("Client FirstName", typeof(String));
            //followUpTable.Columns.Add("Client LastName", typeof(String));
            //followUpTable.Columns.Add("Client PhoneNo", typeof(String));
            //followUpTable.Columns.Add("Transaction", typeof(String));
            //followUpTable.Columns.Add("PropertyType", typeof(String));

            //DataTable leadTable;
            //DataTable clientTable;
            //foreach (DataRow row in followUpTable.Rows)
            //{
            //    leadTable = new DataTable();
            //    var leadId = row["LeadId"];
            //    MyDA.SelectCommand = new MySqlCommand("select * from `lead` where id=" + leadId, Connection);
            //    MyDA.Fill(leadTable);
            //    row["Transaction"] = leadTable.Rows[0]["TransactionType"];
            //    row["PropertyType"] = leadTable.Rows[0]["PropertyType"];

            //    clientTable = new DataTable();
            //    var clientId = leadTable.Rows[0]["ClientId"];
            //    MyDA.SelectCommand = new MySqlCommand("select * from customer where id=" + clientId, Connection);
            //    MyDA.Fill(clientTable);
            //    row["Client FirstName"] = clientTable.Rows[0]["firstname"];
            //    row["Client LastName"] = clientTable.Rows[0]["lastname"];
            //    row["Client PhoneNo"] = clientTable.Rows[0]["phoneno1"];
            //}

            string query = "select c.FirstName, c.LastName, c.PhoneNo1, l.TransactionType, l.propertytype, lfu.* " +
            "from leadfollowup lfu join `lead` l " +
            " ON lfu.leadId = l.id join customer c " +
            " ON l.ClientId = c.id " +
            " where l.IsActive = 1 and lfu.Status = 'Open' and lfu.ReminderDate = '{0}' " +
            " order by date desc ";
            MyDA.SelectCommand = new MySqlCommand(string.Format(query, date), Connection);
            DataTable followUpTable = new DataTable();
            MyDA.Fill(followUpTable);

            return followUpTable;
        }
    }
}
