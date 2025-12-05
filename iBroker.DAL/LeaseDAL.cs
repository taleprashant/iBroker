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
    public class LeaseDAL:BaseDAL, IDisposable
    {
        public LeaseDAL() : base()
        {

        }
        public void Dispose()
        {
            Connection.Close();
        }

        public Lease GetLease(int leaseId)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select * from lease where id=" + leaseId, Connection);

            DataTable leaseTable = new DataTable();
            MyDA.Fill(leaseTable);
            Lease objLease = new Lease();
            objLease.Id = Convert.ToInt32(leaseTable.Rows[0]["Id"]);
            objLease.CreatedDate = leaseTable.Rows[0]["CreatedDate"].ToString();
            objLease.OwnerName = leaseTable.Rows[0]["OwnerName"].ToString();
            objLease.OwnerPhoneNo = leaseTable.Rows[0]["OwnerPhoneNo"].ToString();
            objLease.OwnerEmail = leaseTable.Rows[0]["OwnerEmail"].ToString();
            objLease.OwnerPAN = leaseTable.Rows[0]["OwnerPAN"].ToString();
            objLease.OwnerAadharNo = leaseTable.Rows[0]["OwnerAadharNo"].ToString();
            objLease.OwnerAddress = leaseTable.Rows[0]["OwnerAddress"].ToString();

            objLease.TenantName = leaseTable.Rows[0]["TenantName"].ToString();
            objLease.TenantPhoneNo = leaseTable.Rows[0]["TenantPhoneNo"].ToString();
            objLease.TenantEmail = leaseTable.Rows[0]["TenantEmail"].ToString();
            objLease.TenantPAN = leaseTable.Rows[0]["TenantPAN"].ToString();
            objLease.TenantAadharNo = leaseTable.Rows[0]["TenantAadharNo"].ToString();
            objLease.TenantAddress = leaseTable.Rows[0]["TenantAddress"].ToString();

            objLease.PropertyUnitNo = leaseTable.Rows[0]["PropertyUnitNo"].ToString();
            objLease.PropertySociety = leaseTable.Rows[0]["PropertySociety"].ToString();
            objLease.PropertyLandmark = leaseTable.Rows[0]["PropertyLandmark"].ToString();
            objLease.PropertyLocation = leaseTable.Rows[0]["PropertyLocation"].ToString();
            objLease.PropertySurveyNo = leaseTable.Rows[0]["PropertySurveyNo"].ToString();
            objLease.PropertyCity = leaseTable.Rows[0]["PropertyCity"].ToString();
            objLease.PropertyPincode = leaseTable.Rows[0]["PropertyPincode"].ToString();
            objLease.PropertyAddressOther = leaseTable.Rows[0]["PropertyAddressOther"].ToString();
            objLease.PropertyType = leaseTable.Rows[0]["PropertyType"].ToString();
            objLease.PropertySubType = leaseTable.Rows[0]["PropertySubType"].ToString();
            objLease.PropertyBedrooms = leaseTable.Rows[0]["PropertyBedrooms"].ToString();
            objLease.TokenNo = leaseTable.Rows[0]["TokenNo"].ToString();
            objLease.GRNNo = leaseTable.Rows[0]["GRNNo"].ToString();
            objLease.DurationInMonths = Convert.ToInt32(leaseTable.Rows[0]["Duration"]);
            objLease.StartDate = leaseTable.Rows[0]["StartDate"].ToString();
            objLease.EndDate = leaseTable.Rows[0]["EndDate"].ToString();
            objLease.LockinPeriodInMonths = Convert.ToInt32(leaseTable.Rows[0]["LockinPeriod"]);
            objLease.NoticePeriodInMonths = leaseTable.Rows[0]["NoticePeriod"] is DBNull ? 0 : Convert.ToInt32(leaseTable.Rows[0]["NoticePeriod"]);
            objLease.Escalation1 = leaseTable.Rows[0]["Escalation1"].ToString();
            objLease.Escalation2 = leaseTable.Rows[0]["Escalation2"].ToString();
            objLease.Escalation3 = leaseTable.Rows[0]["Escalation3"].ToString();
            objLease.Remark = leaseTable.Rows[0]["Remark"].ToString();
            objLease.Rent = Convert.ToInt32(leaseTable.Rows[0]["Rent"]);
            objLease.Deposit = Convert.ToInt32(leaseTable.Rows[0]["Deposit"]);
            objLease.BrokerageDetail = leaseTable.Rows[0]["Brokerage"].ToString();
            objLease.Source = leaseTable.Rows[0]["Source"].ToString();
            objLease.IsActive = Convert.ToBoolean(leaseTable.Rows[0]["IsActive"]);

            return objLease;
        }

        public int Insert(Lease lease)
        {
            string sql = "INSERT INTO Lease (OwnerName,OwnerPhoneNo,OwnerEmail,OwnerPAN,OwnerAadharNo,OwnerAddress,TenantName,TenantPhoneNo,TenantEmail,TenantPAN," +
                "TenantAadharNo,TenantAddress,PropertyUnitNo,PropertySociety,PropertyLandmark,PropertySurveyNo,PropertyLocation,PropertyCity,PropertyPincode," +
                "PropertyAddressOther,PropertyType,PropertySubType,PropertyBedrooms,TokenNo,GRNNo,Duration,StartDate,EndDate,LockinPeriod,Escalation1,Escalation2," +
                "Escalation3,Remark,Rent,Deposit,Brokerage,Source, IsActive, CreatedDate,NoticePeriod) " +
                "VALUES (@OwnerName,@OwnerPhoneNo,@OwnerEmail,@OwnerPAN,@OwnerAadharNo,@OwnerAddress,@TenantName,@TenantPhoneNo,@TenantEmail,@TenantPAN,@TenantAadharNo," +
                "@TenantAddress,@PropertyUnitNo,@PropertySociety,@PropertyLandmark,@PropertySurveyNo,@PropertyLocation,@PropertyCity,@PropertyPincode,@PropertyAddressOther," +
                "@PropertyType,@PropertySubType,@PropertyBedrooms,@TokenNo,@GRNNo,@Duration,@StartDate,@EndDate,@LockinPeriod,@Escalation1,@Escalation2,@Escalation3," +
                "@Remark,@Rent,@Deposit,@Brokerage,@Source,@IsActive,@CreatedDate,@NoticePeriod)";

            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@OwnerName", lease.OwnerName);
            cmd.Parameters.AddWithValue("@OwnerPhoneNo", lease.OwnerPhoneNo);
            cmd.Parameters.AddWithValue("@OwnerEmail", lease.OwnerEmail);
            cmd.Parameters.AddWithValue("@OwnerPAN", lease.OwnerPAN);
            cmd.Parameters.AddWithValue("@OwnerAadharNo", lease.OwnerAadharNo);
            cmd.Parameters.AddWithValue("@OwnerAddress", lease.OwnerAddress);
            cmd.Parameters.AddWithValue("@TenantName", lease.TenantName);
            cmd.Parameters.AddWithValue("@TenantPhoneNo", lease.TenantPhoneNo);
            cmd.Parameters.AddWithValue("@TenantEmail", lease.TenantEmail);
            cmd.Parameters.AddWithValue("@TenantPAN", lease.TenantPAN);
            cmd.Parameters.AddWithValue("@TenantAadharNo", lease.TenantAadharNo);
            cmd.Parameters.AddWithValue("@TenantAddress", lease.TenantAddress);
            cmd.Parameters.AddWithValue("@PropertyUnitNo", lease.PropertyUnitNo);
            cmd.Parameters.AddWithValue("@PropertySociety", lease.PropertySociety);
            cmd.Parameters.AddWithValue("@PropertyLandmark", lease.PropertyLandmark);
            cmd.Parameters.AddWithValue("@PropertySurveyNo", lease.PropertySurveyNo);
            cmd.Parameters.AddWithValue("@PropertyLocation", lease.PropertyLocation);
            cmd.Parameters.AddWithValue("@PropertyCity", lease.PropertyCity);
            cmd.Parameters.AddWithValue("@PropertyPincode", lease.PropertyPincode);
            cmd.Parameters.AddWithValue("@PropertyAddressOther", lease.PropertyAddressOther);
            cmd.Parameters.AddWithValue("@PropertyType", lease.PropertyType);
            cmd.Parameters.AddWithValue("@PropertySubType", lease.PropertySubType);
            cmd.Parameters.AddWithValue("@PropertyBedrooms", lease.PropertyBedrooms);
            cmd.Parameters.AddWithValue("@TokenNo", lease.TokenNo);
            cmd.Parameters.AddWithValue("@GRNNo", lease.GRNNo);
            cmd.Parameters.AddWithValue("@Duration", lease.DurationInMonths);
            cmd.Parameters.AddWithValue("@StartDate", lease.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", lease.EndDate);
            cmd.Parameters.AddWithValue("@LockinPeriod", lease.LockinPeriodInMonths);
            cmd.Parameters.AddWithValue("@NoticePeriod", lease.NoticePeriodInMonths);
            cmd.Parameters.AddWithValue("@Escalation1", lease.Escalation1);
            cmd.Parameters.AddWithValue("@Escalation2", lease.Escalation2);
            cmd.Parameters.AddWithValue("@Escalation3", lease.Escalation3);
            cmd.Parameters.AddWithValue("@Remark", lease.Remark);
            cmd.Parameters.AddWithValue("@Rent", lease.Rent);
            cmd.Parameters.AddWithValue("@Deposit", lease.Deposit);
            cmd.Parameters.AddWithValue("@Brokerage", lease.BrokerageDetail);
            cmd.Parameters.AddWithValue("@Source", lease.Source);
            cmd.Parameters.AddWithValue("@IsActive", lease.IsActive);
            cmd.Parameters.AddWithValue("@CreatedDate", lease.CreatedDate); 

            cmd.ExecuteNonQuery();

            return Convert.ToInt32(cmd.LastInsertedId);
        }

        public int GetLatestLeaseId()
        {
            MySqlCommand cmd = new MySqlCommand("select MAX(Id) from lease", Connection);
            object objLeaseId = cmd.ExecuteScalar();
            int maxleaseId = 0;
            if (objLeaseId != null && objLeaseId != DBNull.Value)
            {
                maxleaseId = Convert.ToInt32(objLeaseId);
            }
            return maxleaseId;
        }

        public DataTable GetLease(LeaseSearch leaseSearch = null)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string searchQuery = "select * from lease where IsActive=" + (leaseSearch != null && !leaseSearch.Active ? 0 : 1);

            if (leaseSearch != null)
            {
                if (leaseSearch.OwnerName != null && !string.IsNullOrWhiteSpace(leaseSearch.OwnerName))
                {
                    searchQuery = searchQuery + " and OwnerName like '%";
                    searchQuery = searchQuery + leaseSearch.OwnerName + "%'";
                }

                if (leaseSearch.OwnerPhoneNo != null && !string.IsNullOrWhiteSpace(leaseSearch.OwnerPhoneNo))
                {
                    searchQuery = searchQuery + " and OwnerPhoneNo like '%";
                    searchQuery = searchQuery + leaseSearch.OwnerPhoneNo + "%'";
                }

                if (leaseSearch.TenantName != null && !string.IsNullOrWhiteSpace(leaseSearch.TenantName))
                {
                    searchQuery = searchQuery + " and TenantName like '%";
                    searchQuery = searchQuery + leaseSearch.TenantName + "%'";
                }

                if (leaseSearch.TenantPhoneNo != null && !string.IsNullOrWhiteSpace(leaseSearch.TenantPhoneNo))
                {
                    searchQuery = searchQuery + " and TenantPhoneNo like '%";
                    searchQuery = searchQuery + leaseSearch.TenantPhoneNo + "%'";
                }

                if (leaseSearch.TokenNo != null && !string.IsNullOrWhiteSpace(leaseSearch.TokenNo))
                {
                    searchQuery = searchQuery + " and TokenNo like '%";
                    searchQuery = searchQuery + leaseSearch.TokenNo + "%'";
                }

                if (leaseSearch.GRNNo != null && !string.IsNullOrWhiteSpace(leaseSearch.GRNNo))
                {
                    searchQuery = searchQuery + " and GRNNo like '%";
                    searchQuery = searchQuery + leaseSearch.GRNNo + "%'";
                }

                if (leaseSearch.Locations != null && leaseSearch.Locations.Count > 0)
                {
                    searchQuery = searchQuery + " and ";
                    string locationFilter = string.Empty;
                    foreach (string loc in leaseSearch.Locations)
                    {
                        locationFilter = locationFilter + (string.IsNullOrEmpty(locationFilter) ? (" PropertyLocation like '%" + loc + "%'") : (" or PropertyLocation like '%" + loc + "%'"));
                    }

                    searchQuery = searchQuery + "(" + locationFilter + ")";
                }

                if (!string.IsNullOrEmpty(leaseSearch.RegistrationDateFrom) && !string.IsNullOrEmpty(leaseSearch.RegistrationDateTo))
                {
                    searchQuery = searchQuery + " and STR_TO_DATE(createdDate, '%d/%m/%Y') between STR_TO_DATE('" + leaseSearch.RegistrationDateFrom + "', '%d/%m/%Y') and " +
                        "STR_TO_DATE('" + leaseSearch.RegistrationDateTo + "', '%d/%m/%Y')";
                }


                if (!string.IsNullOrEmpty(leaseSearch.LeaseEndDateFrom) && !string.IsNullOrEmpty(leaseSearch.LeaseEndDateTo))
                {
                    searchQuery = searchQuery + " and STR_TO_DATE(EndDate, '%d/%m/%Y') between STR_TO_DATE('" + leaseSearch.LeaseEndDateFrom + "', '%d/%m/%Y') and " +
                        "STR_TO_DATE('" + leaseSearch.LeaseEndDateTo + "', '%d/%m/%Y')";
                }

                if (leaseSearch.Societies != null && leaseSearch.Societies.Count > 0)
                {
                    searchQuery = searchQuery + " and ";
                    string societyFilter = string.Empty;
                    foreach (string soc in leaseSearch.Societies)
                    {
                        societyFilter = societyFilter + (string.IsNullOrEmpty(societyFilter) ? (" PropertySociety like '%" + soc + "%'") : (" or PropertySociety like '%" + soc + "%'"));
                    }

                    searchQuery = searchQuery + "(" + societyFilter + ")";
                }
            }

            MyDA.SelectCommand = new MySqlCommand(searchQuery, Connection);
            DataTable leaseTable = new DataTable();
            MyDA.Fill(leaseTable);
            return leaseTable;
        }

        public int Update(Lease lease)
        {
            string sql = "UPDATE Lease SET OwnerName=@OwnerName,OwnerPhoneNo=@OwnerPhoneNo,OwnerEmail=@OwnerEmail,OwnerPAN=@OwnerPAN,OwnerAadharNo=@OwnerAadharNo," +
                "OwnerAddress=@OwnerAddress,TenantName=@TenantName,TenantPhoneNo=@TenantPhoneNo,TenantEmail=@TenantEmail,TenantPAN=@TenantPAN," +
                "TenantAadharNo=@TenantAadharNo,TenantAddress=@TenantAddress,PropertyUnitNo=@PropertyUnitNo,PropertySociety=@PropertySociety,PropertyLandmark=@PropertyLandmark," +
                "PropertySurveyNo=@PropertySurveyNo,PropertyLocation=@PropertyLocation,PropertyCity=@PropertyCity,PropertyPincode=@PropertyPincode," +
                "PropertyAddressOther=@PropertyAddressOther,PropertyType=@PropertyType,PropertySubType=@PropertySubType,PropertyBedrooms=@PropertyBedrooms," +
                "TokenNo=@TokenNo,GRNNo=@GRNNo,Duration=@Duration,StartDate=@StartDate,EndDate=@EndDate,LockinPeriod=@LockinPeriod,Escalation1=@Escalation1," +
                "Escalation2=@Escalation2,Escalation3=@Escalation3,Remark=@Remark,Rent=@Rent,Deposit=@Deposit,Brokerage=@Brokerage,Source=@Source, IsActive=@IsActive," +
                "CreatedDate=@CreatedDate,NoticePeriod=@NoticePeriod where id=@id";

            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@OwnerName", lease.OwnerName);
            cmd.Parameters.AddWithValue("@OwnerPhoneNo", lease.OwnerPhoneNo);
            cmd.Parameters.AddWithValue("@OwnerEmail", lease.OwnerEmail);
            cmd.Parameters.AddWithValue("@OwnerPAN", lease.OwnerPAN);
            cmd.Parameters.AddWithValue("@OwnerAadharNo", lease.OwnerAadharNo);
            cmd.Parameters.AddWithValue("@OwnerAddress", lease.OwnerAddress);
            cmd.Parameters.AddWithValue("@TenantName", lease.TenantName);
            cmd.Parameters.AddWithValue("@TenantPhoneNo", lease.TenantPhoneNo);
            cmd.Parameters.AddWithValue("@TenantEmail", lease.TenantEmail);
            cmd.Parameters.AddWithValue("@TenantPAN", lease.TenantPAN);
            cmd.Parameters.AddWithValue("@TenantAadharNo", lease.TenantAadharNo);
            cmd.Parameters.AddWithValue("@TenantAddress", lease.TenantAddress);
            cmd.Parameters.AddWithValue("@PropertyUnitNo", lease.PropertyUnitNo);
            cmd.Parameters.AddWithValue("@PropertySociety", lease.PropertySociety);
            cmd.Parameters.AddWithValue("@PropertyLandmark", lease.PropertyLandmark);
            cmd.Parameters.AddWithValue("@PropertySurveyNo", lease.PropertySurveyNo);
            cmd.Parameters.AddWithValue("@PropertyLocation", lease.PropertyLocation);
            cmd.Parameters.AddWithValue("@PropertyCity", lease.PropertyCity);
            cmd.Parameters.AddWithValue("@PropertyPincode", lease.PropertyPincode);
            cmd.Parameters.AddWithValue("@PropertyAddressOther", lease.PropertyAddressOther);
            cmd.Parameters.AddWithValue("@PropertyType", lease.PropertyType);
            cmd.Parameters.AddWithValue("@PropertySubType", lease.PropertySubType);
            cmd.Parameters.AddWithValue("@PropertyBedrooms", lease.PropertyBedrooms);
            cmd.Parameters.AddWithValue("@TokenNo", lease.TokenNo);
            cmd.Parameters.AddWithValue("@GRNNo", lease.GRNNo);
            cmd.Parameters.AddWithValue("@StartDate", lease.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", lease.EndDate);
            cmd.Parameters.AddWithValue("@LockinPeriod", lease.LockinPeriodInMonths);
            cmd.Parameters.AddWithValue("@NoticePeriod", lease.NoticePeriodInMonths);
            cmd.Parameters.AddWithValue("@Duration", lease.DurationInMonths);
            cmd.Parameters.AddWithValue("@Escalation1", lease.Escalation1);
            cmd.Parameters.AddWithValue("@Escalation2", lease.Escalation2);
            cmd.Parameters.AddWithValue("@Escalation3", lease.Escalation3);
            cmd.Parameters.AddWithValue("@Remark", lease.Remark);
            cmd.Parameters.AddWithValue("@Rent", lease.Rent);
            cmd.Parameters.AddWithValue("@Deposit", lease.Deposit);
            cmd.Parameters.AddWithValue("@Brokerage", lease.BrokerageDetail);
            cmd.Parameters.AddWithValue("@Source", lease.Source);
            cmd.Parameters.AddWithValue("@IsActive", lease.IsActive);
            cmd.Parameters.AddWithValue("@CreatedDate", lease.CreatedDate); 
            cmd.Parameters.AddWithValue("@id", lease.Id);

            cmd.ExecuteNonQuery();

            return Convert.ToInt32(cmd.LastInsertedId);
        }
    }
}
