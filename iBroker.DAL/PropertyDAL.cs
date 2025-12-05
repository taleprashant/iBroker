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
    public class PropertyDAL : IDisposable
    {
        private MySqlConnection Connection;
        private String ConnectionString;

        public PropertyDAL()
        {
            this.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            Connection = new MySqlConnection(this.ConnectionString);
            Connection.Open();
        }

        ~PropertyDAL()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public Property GetProperty(int propertyId)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select * from property where id=" + propertyId, Connection);

            DataTable propTable = new DataTable();
            MyDA.Fill(propTable);
            return new Property
            {
                Id = Convert.ToInt32(propTable.Rows[0]["Id"]),
                FlatNo = propTable.Rows[0]["FlatNo"].ToString(),
                Society = propTable.Rows[0]["Society"].ToString(),
                Landmark = propTable.Rows[0]["Landmark"].ToString(),
                City = propTable.Rows[0]["City"].ToString(),
                //State = propTable.Rows[0]["State"].ToString(),
                Pincode = propTable.Rows[0]["Pincode"].ToString(),
                //Country = propTable.Rows[0]["Country"].ToString(),
                OtherAddress = propTable.Rows[0]["OtherAddress"].ToString(),
                Location = propTable.Rows[0]["Location"].ToString(),

                TransactionType = propTable.Rows[0]["TransactionType"].ToString(),
                PropertyType = propTable.Rows[0]["PropertyType"].ToString(),
                PropertySubType = propTable.Rows[0]["PropertySubType"].ToString(),
                Bedrooms = propTable.Rows[0]["BedroomCount"].ToString(),
                BalconyCount = Convert.ToInt32(propTable.Rows[0]["BalconyCount"]),
                BathroomCount = Convert.ToInt32(propTable.Rows[0]["BathroomCount"]),
                CoveredParkingCount = Convert.ToInt32(propTable.Rows[0]["CoveredParkingCount"]),
                OpenParkingCount = Convert.ToInt32(propTable.Rows[0]["OpenParkingCount"]),
                TotalFloor = Convert.ToInt32(propTable.Rows[0]["TotalFloor"]),
                PropertyFloor = Convert.ToInt32(propTable.Rows[0]["PropertyFloor"]),
                PropertyAgeYear = Convert.ToInt32(propTable.Rows[0]["PropertyAge"]),
                CarpetArea = Convert.ToInt32(propTable.Rows[0]["CarpetArea"]),
                CarpetAreaUnit = propTable.Rows[0]["CarpetAreaUnit"].ToString(),
                BuiltUpArea = Convert.ToInt32(propTable.Rows[0]["BuiltUpArea"]),
                BuiltUpAreaUnit = propTable.Rows[0]["BuiltUpAreaUnit"].ToString(),
                SuperBuiltUpArea = Convert.ToInt32(propTable.Rows[0]["SuperBuiltUpArea"]),
                SuperBuiltUpAreaUnit = propTable.Rows[0]["SuperBuiltUpAreaUnit"].ToString(),
                AvailableRentFrom = propTable.Rows[0]["AvailableRentFrom"].ToString(),
                ConstructionStatus = propTable.Rows[0]["ConstructionStatus"].ToString(),
                PossessionInYears = Convert.ToInt32(propTable.Rows[0]["PossessionInYears"]),
                KeyPlacedAt = propTable.Rows[0]["KeyPlacedAt"].ToString(),
                Source = propTable.Rows[0]["Source"].ToString(),
                //SocietyPreference = propTable.Rows[0]["SocietyPreference"].ToString(),
                Remark = propTable.Rows[0]["Remark"].ToString(),
                FurnitureStatus = propTable.Rows[0]["FurnitureStatus"].ToString(),
                WillingRentFor = propTable.Rows[0]["WillingRentFor"].ToString(),
                OnlinePublished = Convert.ToBoolean(propTable.Rows[0]["OnlinePublished"].ToString()),
                CommercialUse = propTable.Rows[0]["CommercialUse"] is DBNull ? false : Convert.ToBoolean(propTable.Rows[0]["CommercialUse"]),
                BrokerageAgreed = propTable.Rows[0]["BrokerageAgreed"] is DBNull ? false : Convert.ToBoolean(propTable.Rows[0]["BrokerageAgreed"]),
                BrokerageDetail = propTable.Rows[0]["BrokerageDetail"].ToString(),
                BalconyFacing = propTable.Rows[0]["BalconyFacing"].ToString(),
                MainDoorDirection = propTable.Rows[0]["MainDoorDirection"].ToString(),

                OwnerId = Convert.ToInt32(propTable.Rows[0]["OwnerId"]),
                IsActive = Convert.ToBoolean(propTable.Rows[0]["IsActive"]),                
                CreatedDate = propTable.Rows[0]["CreatedDate"].ToString(),

                RentPerMonth = Convert.ToInt32(propTable.Rows[0]["RentPerMonth"]),
                Deposit = Convert.ToInt32(propTable.Rows[0]["Deposit"]),
                SellingPrice = Convert.ToInt32(propTable.Rows[0]["SellingPrice"]),
            };
        }

        public int Insert(Property property)
        {
            string sql = "INSERT INTO Property (OwnerId,FlatNo,Society,Landmark,Location,Pincode,OtherAddress,City,TransactionType,PropertyType,PropertySubType," +
                "BathroomCount,BalconyCount,BedroomCount,CoveredParkingCount,OpenParkingCount,FurnitureStatus,TotalFloor,PropertyFloor,CarpetArea," +
                "CarpetAreaUnit,BuiltUpArea,BuiltUpAreaUnit,SuperBuiltUpArea,SuperBuiltUpAreaUnit,PropertyAge,AvailableRentFrom,WillingRentFor,ConstructionStatus," +
                "PossessionInYears,KeyPlacedAt,OnlinePublished,IsActive,Source,Remark,RentPerMonth,Deposit,SellingPrice,CreatedDate,CommercialUse," +
                "BalconyFacing,MainDoorDirection,BrokerageAgreed,BrokerageDetail) " +
                "VALUES (@OwnerId,@FlatNo,@Society,@Landmark,@Location,@Pincode,@OtherAddress,@City,@TransactionType,@PropertyType,@PropertySubType," +
                "@BathroomCount,@BalconyCount,@BedroomCount,@CoveredParkingCount,@OpenParkingCount,@FurnitureStatus,@TotalFloor,@PropertyFloor,@CarpetArea," +
                "@CarpetAreaUnit,@BuiltUpArea,@BuiltUpAreaUnit,@SuperBuiltUpArea,@SuperBuiltUpAreaUnit,@PropertyAge,@AvailableRentFrom,@WillingRentFor," +
                "@ConstructionStatus,@PossessionInYears,@KeyPlacedAt,@OnlinePublished,@IsActive,@Source,@Remark,@RentPerMonth,@Deposit,@SellingPrice,@CreatedDate," +
                "@CommercialUse,@BalconyFacing,@MainDoorDirection,@BrokerageAgreed,@BrokerageDetail)";

            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@OwnerId", property.OwnerId);
            cmd.Parameters.AddWithValue("@FlatNo", property.FlatNo);
            cmd.Parameters.AddWithValue("@Society", property.Society);
            cmd.Parameters.AddWithValue("@Landmark", property.Landmark);
            cmd.Parameters.AddWithValue("@Location", property.Location);
            cmd.Parameters.AddWithValue("@Pincode", property.Pincode);
            cmd.Parameters.AddWithValue("@OtherAddress", property.OtherAddress);
            cmd.Parameters.AddWithValue("@City", property.City);
            cmd.Parameters.AddWithValue("@TransactionType", property.TransactionType);
            cmd.Parameters.AddWithValue("@PropertyType", property.PropertyType);
            cmd.Parameters.AddWithValue("@PropertySubType", property.PropertySubType);
            cmd.Parameters.AddWithValue("@BathroomCount", property.BathroomCount);
            cmd.Parameters.AddWithValue("@BalconyCount", property.BalconyCount);
            cmd.Parameters.AddWithValue("@BedroomCount", property.Bedrooms);
            cmd.Parameters.AddWithValue("@CoveredParkingCount", property.CoveredParkingCount);
            cmd.Parameters.AddWithValue("@OpenParkingCount", property.OpenParkingCount);
            cmd.Parameters.AddWithValue("@FurnitureStatus", property.FurnitureStatus);
            cmd.Parameters.AddWithValue("@TotalFloor", property.TotalFloor);
            cmd.Parameters.AddWithValue("@PropertyFloor", property.PropertyFloor);
            cmd.Parameters.AddWithValue("@CarpetArea", property.CarpetArea);
            cmd.Parameters.AddWithValue("@CarpetAreaUnit", property.CarpetAreaUnit);
            cmd.Parameters.AddWithValue("@BuiltUpArea", property.BuiltUpArea);
            cmd.Parameters.AddWithValue("@BuiltUpAreaUnit", property.BuiltUpAreaUnit);
            cmd.Parameters.AddWithValue("@SuperBuiltUpArea", property.SuperBuiltUpArea);
            cmd.Parameters.AddWithValue("@SuperBuiltUpAreaUnit", property.SuperBuiltUpAreaUnit);
            cmd.Parameters.AddWithValue("@PropertyAge", property.PropertyAgeYear);
            cmd.Parameters.AddWithValue("@AvailableRentFrom", property.AvailableRentFrom);
            cmd.Parameters.AddWithValue("@WillingRentFor", property.WillingRentFor);
            cmd.Parameters.AddWithValue("@ConstructionStatus", property.ConstructionStatus);
            cmd.Parameters.AddWithValue("@PossessionInYears", property.PossessionInYears);
            cmd.Parameters.AddWithValue("@KeyPlacedAt", property.KeyPlacedAt);
            cmd.Parameters.AddWithValue("@OnlinePublished", property.OnlinePublished);
            cmd.Parameters.AddWithValue("@IsActive", property.IsActive);
            cmd.Parameters.AddWithValue("@Source", property.Source);
            cmd.Parameters.AddWithValue("@Remark", property.Remark);
            cmd.Parameters.AddWithValue("@RentPerMonth", property.RentPerMonth);
            cmd.Parameters.AddWithValue("@Deposit", property.Deposit);
            cmd.Parameters.AddWithValue("@SellingPrice", property.SellingPrice);
            cmd.Parameters.AddWithValue("@CreatedDate",Convert.ToDateTime(property.CreatedDate));
            cmd.Parameters.AddWithValue("@CommercialUse", property.CommercialUse);
            cmd.Parameters.AddWithValue("@BalconyFacing", property.BalconyFacing);
            cmd.Parameters.AddWithValue("@MainDoorDirection", property.MainDoorDirection);
            cmd.Parameters.AddWithValue("@BrokerageAgreed", property.BrokerageAgreed);
            cmd.Parameters.AddWithValue("@BrokerageDetail", property.BrokerageDetail);

            cmd.ExecuteNonQuery();

            return Convert.ToInt32(cmd.LastInsertedId);
        }

        public int GetLatestPropId()
        {
            MySqlCommand cmd = new MySqlCommand("select MAX(Id) from property", Connection);
            object objPropId = cmd.ExecuteScalar();
            int maxPropId = 0;
            if(objPropId != null && objPropId != DBNull.Value)
            {
                maxPropId = Convert.ToInt32(objPropId);
            }
            return maxPropId;
        }

        public DataTable GetProperties(PropertySearch propTable = null)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string searchQuery = "select * from property where IsActive=" + (propTable != null && !propTable.Active ? 0 : 1);

            if (propTable != null)
            {
                //if (!string.IsNullOrEmpty(propTable.ReminderDateFrom) && !string.IsNullOrEmpty(propTable.ReminderDateTo))
                //{
                //    string followUpQuery = string.Empty;
                //    List<int> leadIds = new List<int>();
                //    followUpQuery = "select distinct LeadId from leadfollowup where reminderdate between '{0}' and '{1}'";
                //    followUpQuery = string.Format(followUpQuery, propTable.ReminderDateFrom, propTable.ReminderDateTo);

                //    MyDA.SelectCommand = new MySqlCommand(followUpQuery, Connection);
                //    DataTable followUpTable = new DataTable();
                //    MyDA.Fill(followUpTable);
                //    leadIds = (from DataRow dr in followUpTable.Rows
                //               select Convert.ToInt32(dr["leadid"])).ToList();

                //    if (leadIds.Count > 0)
                //    {
                //        searchQuery = searchQuery + " and Id in (" + string.Join(",", leadIds) + ")";
                //    }
                //    else
                //    {
                //        searchQuery = searchQuery + " and 1 = 2";
                //    }
                //}

                string customerQuery = string.Empty;
                List<int> clientIds = new List<int>();
                if (propTable.ClientName != null && !string.IsNullOrEmpty(propTable.ClientName))
                {
                    customerQuery = "select id from `owner` where ";
                    customerQuery = customerQuery + " (name like '%" + propTable.ClientName + "%')";
                }
                if (propTable.ClientPhoneNo != null && !string.IsNullOrEmpty(propTable.ClientPhoneNo))
                {
                    customerQuery = customerQuery + (string.IsNullOrEmpty(customerQuery) ? "select id from `owner` where " : " and ");
                    customerQuery = customerQuery + " (phoneno1 like '%" + propTable.ClientPhoneNo + "%' or phoneno2 like '%" + propTable.ClientPhoneNo + "%')";
                }
                if (propTable.ClientEmail != null && !string.IsNullOrEmpty(propTable.ClientEmail))
                {
                    customerQuery = customerQuery + (string.IsNullOrEmpty(customerQuery) ? "select id from `owner` where " : " and ");
                    customerQuery = customerQuery + " email like '%" + propTable.ClientEmail + "%'";
                }

                if (!String.IsNullOrEmpty(customerQuery))
                {
                    MyDA.SelectCommand = new MySqlCommand(customerQuery, Connection);

                    DataTable custTable = new DataTable();
                    MyDA.Fill(custTable);
                    clientIds = (from DataRow dr in custTable.Rows
                                 select Convert.ToInt32(dr["id"])).ToList();
                }
                if (clientIds.Count > 0)
                {
                    searchQuery = searchQuery + " and OwnerId in (" + string.Join(",", clientIds) + ")";
                }

                if (propTable.TransactionType != null && !string.IsNullOrWhiteSpace(propTable.TransactionType) && propTable.TransactionType != "ALL")
                {
                    searchQuery = searchQuery + " and transactiontype = '";
                    searchQuery = searchQuery + propTable.TransactionType + "'";
                }

                if (propTable.PropertyType != null && !string.IsNullOrWhiteSpace(propTable.PropertyType) && propTable.PropertyType != "ALL")
                {
                    searchQuery = searchQuery + " and propertytype = '";
                    searchQuery = searchQuery + propTable.PropertyType + "'";
                }

                string bedroomsFilter = string.Empty;
                if (propTable.Bedrooms != null && propTable.Bedrooms.Count > 0)
                {
                    foreach (string bedroom in propTable.Bedrooms)
                    {
                        if (bedroom == "") continue;
                        bedroomsFilter = bedroomsFilter + (string.IsNullOrEmpty(bedroomsFilter) ? "(bedroomcount like '%" + bedroom + "%'" : "or bedroomcount like '%" + bedroom + "%'");
                    }
                    bedroomsFilter = bedroomsFilter + (string.IsNullOrEmpty(bedroomsFilter) ? string.Empty : ")");

                    if (!string.IsNullOrEmpty(bedroomsFilter))
                    {
                        searchQuery = searchQuery + " and " + bedroomsFilter;
                    }
                }

                if (propTable.BudgetMin != 0 && propTable.BudgetMax != 0)
                {
                    searchQuery = searchQuery + " and (sellingprice between ";
                    searchQuery = searchQuery + propTable.BudgetMin + " and " + propTable.BudgetMax;
                    searchQuery = searchQuery + " or rentpermonth between ";
                    searchQuery = searchQuery + propTable.BudgetMin + " and " + propTable.BudgetMax + ")";
                }else if(propTable.BudgetMin == 0 && propTable.BudgetMax != 0)
                {
                    //((sellingprice <= 12000 and rentpermonth = 0) or (rentpermonth <= 12000 and sellingprice = 0))
                    searchQuery = searchQuery + " and ((sellingprice <= " + propTable.BudgetMax + " and rentpermonth = 0)";
                    //searchQuery = searchQuery + propTable.BudgetMax;
                    searchQuery = searchQuery + " or (rentpermonth <= " + propTable.BudgetMax + " and sellingprice = 0)) ";
                    //searchQuery = searchQuery + propTable.BudgetMax + ")";
                }

                //if(propTable.BudgetMax != 0)
                //{
                //    searchQuery = searchQuery + " and MaxBudget between ";
                //    searchQuery = searchQuery + propTable.BudgetMin + " and " + propTable.BudgetMax;
                //}

                if (propTable.FurnitureStatus != null && propTable.FurnitureStatus.Count > 0)
                {
                    string furStatusQuery = string.Empty;
                    if (propTable.FurnitureStatus.Contains("FullyFurnished"))
                    {
                        furStatusQuery = "furnitureStatus like '%FullyFurnished%'";
                    }
                    if (propTable.FurnitureStatus.Contains("SemiFurnished"))
                    {
                        furStatusQuery = furStatusQuery + (string.IsNullOrEmpty(furStatusQuery) ? " furnitureStatus like '%SemiFurnished%'" : " Or furnitureStatus like '%SemiFurnished%'");
                    }
                    if (propTable.FurnitureStatus.Contains("NonFurnished"))
                    {
                        furStatusQuery = furStatusQuery + (string.IsNullOrEmpty(furStatusQuery) ? " furnitureStatus like '%NonFurnished%'" : " Or furnitureStatus like '%NonFurnished%'");
                    }

                    if (!string.IsNullOrEmpty(furStatusQuery))
                    {
                        searchQuery = searchQuery + " and (" + furStatusQuery + ") ";
                    }
                }

                if (propTable.Locations != null && propTable.Locations.Count > 0)
                {
                    searchQuery = searchQuery + " and ";
                    string locationFilter = string.Empty;
                    foreach (string loc in propTable.Locations)
                    {
                        locationFilter = locationFilter + (string.IsNullOrEmpty(locationFilter) ? (" location like '%" + loc + "%'") : (" or location like '%" + loc + "%'"));
                    }

                    searchQuery = searchQuery + "(" + locationFilter + ")";
                }

                if (!string.IsNullOrEmpty(propTable.RegistrationDateFrom) && !string.IsNullOrEmpty(propTable.RegistrationDateTo))
                {
                    searchQuery = searchQuery + " and createdDate between STR_TO_DATE('" + propTable.RegistrationDateFrom + "', '%d/%m/%Y') and STR_TO_DATE('" + propTable.RegistrationDateTo + "', '%d/%m/%Y')";
                }

                if (!string.IsNullOrEmpty(propTable.Source) && propTable.Source != "ALL")
                {
                    searchQuery = searchQuery + " and source like '%" + propTable.Source + "'";
                }

                if (propTable.CommercialUse)
                {
                    searchQuery = searchQuery + " and commercialUse=" + propTable.CommercialUse;
                }

                if (propTable.PropertyAge != 0)
                {
                    searchQuery = searchQuery + " and propertyage <= " + propTable.PropertyAge;
                }

                if (propTable.PropertyFloor != -1)
                {
                    searchQuery = searchQuery + " and propertyfloor = " + propTable.PropertyFloor;
                }

                if (propTable.Societies != null && propTable.Societies.Count > 0)
                {
                    searchQuery = searchQuery + " and ";
                    string societyFilter = string.Empty;
                    foreach (string soc in propTable.Societies)
                    {
                        societyFilter = societyFilter + (string.IsNullOrEmpty(societyFilter) ? (" society like '%" + soc + "%'") : (" or society like '%" + soc + "%'"));
                    }

                    searchQuery = searchQuery + "(" + societyFilter + ")";
                }

                if (propTable.AvailableForRent != null && propTable.AvailableForRent.Count > 0)
                {
                    string furStatusQuery = string.Empty;
                    if (propTable.AvailableForRent.Contains("Family"))
                    {
                        furStatusQuery = "WillingRentFor like '%FullyFurnished%'";
                    }
                    if (propTable.AvailableForRent.Contains("Bachelor"))
                    {
                        furStatusQuery = furStatusQuery + (string.IsNullOrEmpty(furStatusQuery) ? " WillingRentFor like '%Bachelor%'" : " Or WillingRentFor like '%Bachelor%'");
                    }
                    if (propTable.AvailableForRent.Contains("Student"))
                    {
                        furStatusQuery = furStatusQuery + (string.IsNullOrEmpty(furStatusQuery) ? " WillingRentFor like '%Student%'" : " Or WillingRentFor like '%Student%'");
                    }

                    if (!string.IsNullOrEmpty(furStatusQuery))
                    {
                        searchQuery = searchQuery + " and (" + furStatusQuery + ") ";
                    }
                }

                if (propTable.KeyWithUs)
                {
                    searchQuery = searchQuery + " and keyplacedat = 'With Us'";
                }
            }

            MyDA.SelectCommand = new MySqlCommand(searchQuery, Connection);
            DataTable propertyTable = new DataTable();
            MyDA.Fill(propertyTable);
            //DataColumn workCol = propTable.Columns.Add("CustID", typeof(Int32));
            propertyTable.Columns.Add("Owner Name", typeof(String));
            propertyTable.Columns.Add("Owner PhoneNo", typeof(String));

            DataTable clientTable;
            foreach (DataRow row in propertyTable.Rows)
            {
                clientTable = new DataTable();
                var ownerId = row["OwnerId"];
                MyDA.SelectCommand = new MySqlCommand("select * from `owner` where id=" + ownerId, Connection);
                MyDA.Fill(clientTable);
                if (clientTable.Rows.Count > 0)
                {
                    row["Owner Name"] = clientTable.Rows[0]["Name"];
                    row["Owner PhoneNo"] = clientTable.Rows[0]["phoneno1"];
                }
            }

            return propertyTable;
        }

        public int Update(Property property)
        {
            string sql = "UPDATE Property SET OwnerId=@OwnerId,FlatNo=@FlatNo,Society=@Society,Landmark=@Landmark,Location=@Location,Pincode=@Pincode," +
                "OtherAddress=@OtherAddress,City=@City,TransactionType=@TransactionType,PropertyType=@PropertyType,PropertySubType=@PropertySubType," +
                "BathroomCount=@BathroomCount,BalconyCount=@BalconyCount,BedroomCount=@BedroomCount,CoveredParkingCount=@CoveredParkingCount," +
                "OpenParkingCount=@OpenParkingCount,FurnitureStatus=@FurnitureStatus,TotalFloor=@TotalFloor,PropertyFloor=@PropertyFloor,CarpetArea=@CarpetArea," +
                "CarpetAreaUnit=@CarpetAreaUnit,BuiltUpArea=@BuiltUpArea,BuiltUpAreaUnit=@BuiltUpAreaUnit,SuperBuiltUpArea=@SuperBuiltUpArea," +
                "SuperBuiltUpAreaUnit=@SuperBuiltUpAreaUnit,PropertyAge=@PropertyAge,AvailableRentFrom=@AvailableRentFrom,WillingRentFor=@WillingRentFor," +
                "ConstructionStatus=@ConstructionStatus," +
                "PossessionInYears=@PossessionInYears,KeyPlacedAt=@KeyPlacedAt,OnlinePublished=@OnlinePublished,IsActive=@IsActive,Source=@Source,Remark=@Remark," +
                "RentPerMonth=@RentPerMonth,Deposit=@Deposit,SellingPrice=@SellingPrice,CreatedDate=@CreatedDate,CommercialUse=@CommercialUse,BalconyFacing=@BalconyFacing," +
                "MainDoorDirection=@MainDoorDirection,BrokerageAgreed=@BrokerageAgreed,BrokerageDetail=@BrokerageDetail where id=@id";

            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@OwnerId", property.OwnerId);
            cmd.Parameters.AddWithValue("@FlatNo", property.FlatNo);
            cmd.Parameters.AddWithValue("@Society", property.Society);
            cmd.Parameters.AddWithValue("@Landmark", property.Landmark);
            cmd.Parameters.AddWithValue("@Location", property.Location);
            cmd.Parameters.AddWithValue("@Pincode", property.Pincode);
            cmd.Parameters.AddWithValue("@OtherAddress", property.OtherAddress);
            cmd.Parameters.AddWithValue("@City", property.City);
            cmd.Parameters.AddWithValue("@TransactionType", property.TransactionType);
            cmd.Parameters.AddWithValue("@PropertyType", property.PropertyType);
            cmd.Parameters.AddWithValue("@PropertySubType", property.PropertySubType);
            cmd.Parameters.AddWithValue("@BathroomCount", property.BathroomCount);
            cmd.Parameters.AddWithValue("@BalconyCount", property.BalconyCount);
            cmd.Parameters.AddWithValue("@BedroomCount", property.Bedrooms);
            cmd.Parameters.AddWithValue("@CoveredParkingCount", property.CoveredParkingCount);
            cmd.Parameters.AddWithValue("@OpenParkingCount", property.OpenParkingCount);
            cmd.Parameters.AddWithValue("@FurnitureStatus", property.FurnitureStatus);
            cmd.Parameters.AddWithValue("@TotalFloor", property.TotalFloor);
            cmd.Parameters.AddWithValue("@PropertyFloor", property.PropertyFloor);
            cmd.Parameters.AddWithValue("@CarpetArea", property.CarpetArea);
            cmd.Parameters.AddWithValue("@CarpetAreaUnit", property.CarpetAreaUnit);
            cmd.Parameters.AddWithValue("@BuiltUpArea", property.BuiltUpArea);
            cmd.Parameters.AddWithValue("@BuiltUpAreaUnit", property.BuiltUpAreaUnit);
            cmd.Parameters.AddWithValue("@SuperBuiltUpArea", property.SuperBuiltUpArea);
            cmd.Parameters.AddWithValue("@SuperBuiltUpAreaUnit", property.SuperBuiltUpAreaUnit);
            cmd.Parameters.AddWithValue("@PropertyAge", property.PropertyAgeYear);
            cmd.Parameters.AddWithValue("@AvailableRentFrom", property.AvailableRentFrom);
            cmd.Parameters.AddWithValue("@WillingRentFor", property.WillingRentFor);
            cmd.Parameters.AddWithValue("@ConstructionStatus", property.ConstructionStatus);
            cmd.Parameters.AddWithValue("@PossessionInYears", property.PossessionInYears);
            cmd.Parameters.AddWithValue("@KeyPlacedAt", property.KeyPlacedAt);
            cmd.Parameters.AddWithValue("@OnlinePublished", property.OnlinePublished);
            cmd.Parameters.AddWithValue("@IsActive", property.IsActive);
            cmd.Parameters.AddWithValue("@Source", property.Source);
            cmd.Parameters.AddWithValue("@Remark", property.Remark);
            cmd.Parameters.AddWithValue("@RentPerMonth", property.RentPerMonth);
            cmd.Parameters.AddWithValue("@Deposit", property.Deposit);
            cmd.Parameters.AddWithValue("@SellingPrice", property.SellingPrice);
            cmd.Parameters.AddWithValue("@CreatedDate", Convert.ToDateTime(property.CreatedDate));
            cmd.Parameters.AddWithValue("@CommercialUse", property.CommercialUse);
            cmd.Parameters.AddWithValue("@BalconyFacing", property.BalconyFacing);
            cmd.Parameters.AddWithValue("@MainDoorDirection", property.MainDoorDirection);
            cmd.Parameters.AddWithValue("@BrokerageAgreed", property.BrokerageAgreed);
            cmd.Parameters.AddWithValue("@BrokerageDetail", property.BrokerageDetail);

            cmd.Parameters.AddWithValue("@id", property.Id);

            cmd.ExecuteNonQuery();

            return Convert.ToInt32(cmd.LastInsertedId);
        }
    }
}
