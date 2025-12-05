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
    public class LeadDAL : IDisposable
    {
        private MySqlConnection Connection;
        private String ConnectionString;

        public LeadDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
        }

        public Lead GetLead(int leadId=0, int clientId = 0)
        {
            string query = string.Empty;
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            List<int> clientIds = new List<int>();
            if (leadId != 0)
            {
                query = "select * from `lead` where id=" + leadId;
            }else if(clientId != 0)
            {
                query = "select * from `lead` where clientId=" + clientId;
            }
            
            MyDA.SelectCommand = new MySqlCommand(query, Connection);
            DataTable leadTable = new DataTable();
            MyDA.Fill(leadTable);
            if (leadTable.Rows.Count > 0)
            {
                return new Lead
                {
                    Id = Convert.ToInt32(leadTable.Rows[0]["Id"]),
                    TransactionType = leadTable.Rows[0]["TransactionType"].ToString(),
                    PropertyType = leadTable.Rows[0]["PropertyType"].ToString(),
                    PropertySubType = leadTable.Rows[0]["PropertySubType"].ToString(),
                    MinBudget = Convert.ToInt64(leadTable.Rows[0]["MinBudget"]),
                    MaxBudget = Convert.ToInt64(leadTable.Rows[0]["MaxBudget"]),
                    Bedrooms = leadTable.Rows[0]["Bedrooms"].ToString(),
                    Location = leadTable.Rows[0]["Location"].ToString(),
                    ClientId = Convert.ToInt32(leadTable.Rows[0]["ClientId"]),
                    IsActive = Convert.ToBoolean(leadTable.Rows[0]["IsActive"]),
                    Source = leadTable.Rows[0]["Source"].ToString(),
                    SocietyPreference = leadTable.Rows[0]["SocietyPreference"].ToString(),
                    Remark = leadTable.Rows[0]["Remark"].ToString(),
                    FurnitureStatus = leadTable.Rows[0]["FurnitureStatus"].ToString(),
                    RequiredRentFor = leadTable.Rows[0]["RequiredRentFor"].ToString(),
                    CreatedDate = leadTable.Rows[0]["CreatedDate"].ToString(),
                    MinArea = leadTable.Rows[0]["MinArea"] is DBNull ? 0 : Convert.ToInt32(leadTable.Rows[0]["MinArea"]),
                    MaxArea = leadTable.Rows[0]["MaxArea"] is DBNull ? 0 : Convert.ToInt32(leadTable.Rows[0]["MaxArea"]),
                };
            }
            else
            {
                return null;
            }
        }

        ~LeadDAL()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public int Insert(Lead lead)
        {
            string insertQuery = "insert into `lead` (TransactionType, PropertyType, PropertySubType, MinBudget, MaxBudget, Bedrooms, Location, " +
                "ClientId, IsActive, Source, SocietyPreference, Remark, FurnitureStatus, CreatedDate, RequiredRentFor, MinArea, MaxArea) values ('{0}','{1}','{2}','{3}','{4}', '{5}','{6}', {7}, {8}," +
                "'{9}','{10}','{11}','{12}', STR_TO_DATE('{13}', '%d/%m/%Y'), '{14}', '{15}', '{16}')";
            insertQuery = String.Format(insertQuery, lead.TransactionType, lead.PropertyType, lead.PropertySubType, lead.MinBudget, lead.MaxBudget, 
                lead.Bedrooms, lead.Location, lead.ClientId, lead.IsActive, lead.Source, lead.SocietyPreference, lead.Remark, lead.FurnitureStatus, lead.CreatedDate,
                lead.RequiredRentFor, lead.MinArea, lead.MaxArea);

            MySqlCommand cmd = new MySqlCommand(insertQuery, Connection);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return Convert.ToInt32(id);
        }

        public DataTable GetLeads(LeadSearch leadSearch = null)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string searchQuery = "select * from `lead` where IsActive=" + (leadSearch !=null && !leadSearch.Active ? 0 : 1);

            if(leadSearch != null)
            {
                if (!string.IsNullOrEmpty(leadSearch.ReminderDateFrom) && !string.IsNullOrEmpty(leadSearch.ReminderDateTo))
                {
                    string followUpQuery = string.Empty;
                    List<int> leadIds = new List<int>();
                    followUpQuery = "select distinct LeadId from leadfollowup where reminderdate between '{0}' and '{1}' and status='Open'";
                    followUpQuery = string.Format(followUpQuery, leadSearch.ReminderDateFrom, leadSearch.ReminderDateTo);

                    MyDA.SelectCommand = new MySqlCommand(followUpQuery, Connection);
                    DataTable followUpTable = new DataTable();
                    MyDA.Fill(followUpTable);
                    leadIds = (from DataRow dr in followUpTable.Rows
                               select Convert.ToInt32(dr["leadid"])).ToList();

                    if (leadIds.Count > 0)
                    {
                        searchQuery = searchQuery + " and Id in (" + string.Join(",", leadIds) + ")";
                    }
                    else
                    {
                        searchQuery = searchQuery + " and 1 = 2";
                    }
                }

                string customerQuery = string.Empty;
                List<int> clientIds = new List<int>();
                if (leadSearch.ClientName != null && !string.IsNullOrEmpty(leadSearch.ClientName))
                {
                    customerQuery = "select id from customer where ";
                    customerQuery = customerQuery + " (firstname like '%" + leadSearch.ClientName + "%' or lastname like '%" + leadSearch.ClientName + "%')";
                }
                if (leadSearch.ClientPhoneNo != null && !string.IsNullOrEmpty(leadSearch.ClientPhoneNo))
                {
                    customerQuery = customerQuery + (string.IsNullOrEmpty(customerQuery) ? "select id from customer where " : " and ");
                    customerQuery = customerQuery + " (phoneno1 like '%" + leadSearch.ClientPhoneNo + "%' or phoneno2 like '%" + leadSearch.ClientPhoneNo + "%')";
                }
                if (leadSearch.ClientEmail != null && !string.IsNullOrEmpty(leadSearch.ClientEmail))
                {
                    customerQuery = customerQuery + (string.IsNullOrEmpty(customerQuery) ? "select id from customer where " : " and ");
                    customerQuery = customerQuery + " email like '%" + leadSearch.ClientEmail + "%'";
                }

                if (!String.IsNullOrEmpty(customerQuery))
                {
                    MyDA.SelectCommand = new MySqlCommand(customerQuery, Connection);

                    DataTable custTable = new DataTable();
                    MyDA.Fill(custTable);
                    clientIds = (from DataRow dr in custTable.Rows
                                 select Convert.ToInt32(dr["id"])).ToList();
                }
                if(clientIds.Count > 0)
                {
                    searchQuery = searchQuery + " and ClientId in (" + string.Join(",", clientIds) + ")";
                }
            }

            if (leadSearch != null)
            {
                if(leadSearch.TransactionType != null && !string.IsNullOrWhiteSpace(leadSearch.TransactionType) && leadSearch.TransactionType != "ALL")
                {
                    searchQuery = searchQuery + " and transactiontype = '";
                    searchQuery = searchQuery + leadSearch.TransactionType + "'";
                }

                if (leadSearch.PropertyType != null && !string.IsNullOrWhiteSpace(leadSearch.PropertyType) && leadSearch.PropertyType != "ALL")
                {
                    searchQuery = searchQuery + " and propertytype = '";
                    searchQuery = searchQuery + leadSearch.PropertyType + "'";
                }

                string bedroomsFilter = string.Empty;
                if (leadSearch.Bedrooms != null && leadSearch.Bedrooms.Count > 0)
                {
                    foreach (string bedroom in leadSearch.Bedrooms)
                    {
                        if (bedroom == "") continue;
                        bedroomsFilter = bedroomsFilter + (string.IsNullOrEmpty(bedroomsFilter) ? "(bedrooms like '%" + bedroom + "%'" : "or bedrooms like '%" + bedroom + "%'");
                    }
                    bedroomsFilter = bedroomsFilter + (string.IsNullOrEmpty(bedroomsFilter) ? string.Empty : ")");

                    if (!string.IsNullOrEmpty(bedroomsFilter))
                    {
                        searchQuery = searchQuery + " and " + bedroomsFilter;
                    }
                }

                if(leadSearch.BudgetMin != 0 && leadSearch.BudgetMax != 0)
                {
                    searchQuery = searchQuery + " and (MinBudget between ";
                    searchQuery = searchQuery + leadSearch.BudgetMin + " and " + leadSearch.BudgetMax;
                    searchQuery = searchQuery + " or MaxBudget between ";
                    searchQuery = searchQuery + leadSearch.BudgetMin + " and " + leadSearch.BudgetMax + ")";
                }

                //if(leadSearch.BudgetMax != 0)
                //{
                //    searchQuery = searchQuery + " and MaxBudget between ";
                //    searchQuery = searchQuery + leadSearch.BudgetMin + " and " + leadSearch.BudgetMax;
                //}

                if(leadSearch.FurnitureStatus != null && leadSearch.FurnitureStatus.Count > 0)
                {
                    if (leadSearch.FurnitureStatus.Contains("FullyFurnished"))
                    {
                        searchQuery = searchQuery + " and furnitureStatus like '%FullyFurnished%'";
                    }
                    if (leadSearch.FurnitureStatus.Contains("SemiFurnished"))
                    {
                        searchQuery = searchQuery + " and furnitureStatus like '%SemiFurnished%'";
                    }
                    if (leadSearch.FurnitureStatus.Contains("NonFurnished"))
                    {
                        searchQuery = searchQuery + " and furnitureStatus like '%NonFurnished%'";
                    }
                }

                if(leadSearch.Locations != null && leadSearch.Locations.Count > 0)
                {
                    searchQuery = searchQuery + " and ";
                    string locationFilter = string.Empty;
                    foreach (string loc in leadSearch.Locations)
                    {
                        locationFilter = locationFilter + (string.IsNullOrEmpty(locationFilter) ? (" location like '%" + loc + "%'") : (" or location like '%" + loc + "%'"));
                    }

                    searchQuery = searchQuery + "(" +locationFilter + ")";
                }

                if(!string.IsNullOrEmpty(leadSearch.RegistrationDateFrom) && !string.IsNullOrEmpty(leadSearch.RegistrationDateTo))
                {
                    searchQuery = searchQuery + " and createdDate between STR_TO_DATE('" + leadSearch.RegistrationDateFrom  + "', '%d/%m/%Y') and STR_TO_DATE('" + leadSearch.RegistrationDateTo + "', '%d/%m/%Y')";
                }

                if (!string.IsNullOrEmpty(leadSearch.Source) && leadSearch.Source != "ALL")
                {
                    searchQuery = searchQuery + " and source like '%"+ leadSearch.Source + "'";
                }
            }

            MyDA.SelectCommand = new MySqlCommand(searchQuery, Connection);

            DataTable leadTable = new DataTable();
            MyDA.Fill(leadTable);
            //DataColumn workCol = leadTable.Columns.Add("CustID", typeof(Int32));
            leadTable.Columns.Add("Client FirstName", typeof(String));
            leadTable.Columns.Add("Client LastName", typeof(String));
            leadTable.Columns.Add("Client PhoneNo", typeof(String));

            DataTable clientTable;
            foreach (DataRow row in leadTable.Rows)
            {
                clientTable = new DataTable();
                var clientId = row["ClientId"];
                MyDA.SelectCommand = new MySqlCommand("select * from customer where id=" + clientId, Connection);
                MyDA.Fill(clientTable);
                row["Client FirstName"] = clientTable.Rows[0]["firstname"];
                row["Client LastName"] = clientTable.Rows[0]["lastname"];
                row["Client PhoneNo"] = clientTable.Rows[0]["phoneno1"];
            }

            return leadTable;
        }

        public DataTable GetLeads()
        {
            DataTable leads = new DataTable();

            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string searchQuery = "select l.*, c.FirstName 'Client FirstName', c.LastName 'Client LastName', c.PhoneNo1 'Client PhoneNo', C.PhoneNo2 from `lead` l join customer c " +
                                    " on l.ClientId = c.id where IsActive = " + 1;
            MyDA.SelectCommand = new MySqlCommand(searchQuery, Connection);
            MyDA.Fill(leads);

            return leads;
        }

        public int Update(Lead lead)
        {
            string updateQuery = "update `lead` set TransactionType='{0}', PropertyType='{1}', PropertySubType='{2}', MinBudget='{3}', MaxBudget='{4}', " +
                "Bedrooms='{5}', IsActive={6}, Location='{7}', Source='{8}', SocietyPreference='{9}', Remark='{10}', FurnitureStatus='{11}', " +
                "CreatedDate=STR_TO_DATE('{12}', '%d/%m/%Y'), RequiredRentFor='{13}', MinArea='{14}', MaxArea='{15}' where id=" + lead.Id;
            updateQuery = String.Format(updateQuery, lead.TransactionType, lead.PropertyType, lead.PropertySubType, lead.MinBudget, lead.MaxBudget, lead.Bedrooms, 
                lead.IsActive ? 1 : 0, lead.Location, lead.Source, lead.SocietyPreference, lead.Remark, lead.FurnitureStatus, lead.CreatedDate, lead.RequiredRentFor,
                lead.MinArea, lead.MaxArea);

            MySqlCommand cmd = new MySqlCommand(updateQuery, Connection);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(lead.Id);
        }

        public int GetNextLeadId()
        {
            MySqlCommand cmd = new MySqlCommand("select MAX(Id) from `lead`", Connection);
            int maxLeadId = (int)cmd.ExecuteScalar();
            return maxLeadId;
        }
    }
}
