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
    public class BuilderProjectDAL : BaseDAL, IDisposable
    {
        ~BuilderProjectDAL()
        {
            Connection.Close();
        }

        public BuilderProjectDAL() : base()
        {
            //this.MyDA = new MySqlDataAdapter();
            //MyDA.SelectCommand = new MySqlCommand("select Id, Name, PhoneNo, email, headofficeaddress from builder", Connection);
            //commandBuilder = new MySqlCommandBuilder(MyDA);
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public int GetLatestBuilderProjectId()
        {
            MySqlCommand cmd = new MySqlCommand("select MAX(Id) from BuilderProject", Connection);
            object objBuilderProjectId = cmd.ExecuteScalar();
            int maxProjectId = 0;
            if (objBuilderProjectId != null && objBuilderProjectId != DBNull.Value)
            {
                maxProjectId = Convert.ToInt32(objBuilderProjectId);
            }
            return maxProjectId;
        }

        public BuilderProject GetBuilderProject(int projectId)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("select * from builderproject where id=" + projectId, Connection);

            DataTable projectTable = new DataTable();
            MyDA.Fill(projectTable);
            BuilderProject objProject = new BuilderProject();
            objProject.Id = Convert.ToInt32(projectTable.Rows[0]["Id"]);
            objProject.CreatedDate = projectTable.Rows[0]["CreatedDate"].ToString();
            objProject.Name = projectTable.Rows[0]["ProjectName"].ToString();
            objProject.ProjectType = projectTable.Rows[0]["ProjectType"].ToString();
            objProject.BuilderId = Convert.ToInt32(projectTable.Rows[0]["BuilderId"]);
            objProject.Location = projectTable.Rows[0]["Location"].ToString();
            objProject.Landmark = projectTable.Rows[0]["Landmark"].ToString();
            objProject.Address = projectTable.Rows[0]["Address"].ToString();
            objProject.Pincode = projectTable.Rows[0]["Pincode"].ToString();
            objProject.SitePhoneNo1 = projectTable.Rows[0]["PhoneNo1"].ToString();
            objProject.SitePhoneNo2 = projectTable.Rows[0]["PhoneNo2"].ToString();
            objProject.Website = projectTable.Rows[0]["Website"].ToString();
            objProject.Email = projectTable.Rows[0]["Email"].ToString();
            objProject.LaunchDate = projectTable.Rows[0]["LaunchDate"].ToString();
            objProject.CurrentStatus = projectTable.Rows[0]["Status"].ToString();
            objProject.PossessionDate = projectTable.Rows[0]["PossessionDate"].ToString();
            objProject.ReraApproved = Convert.ToBoolean(projectTable.Rows[0]["ReraApproved"]);
            objProject.ReraID = projectTable.Rows[0]["ReraID"].ToString();
            objProject.TotalUnits = Convert.ToInt32(projectTable.Rows[0]["TotalUnit"]);
            objProject.TotalLandArea = Convert.ToInt32(projectTable.Rows[0]["LandArea"]);
            objProject.LandAreaUnit = projectTable.Rows[0]["LandAreaUnit"].ToString();
            objProject.StartPrice = projectTable.Rows[0]["StartPrice"].ToString();
            objProject.MaxPrice = projectTable.Rows[0]["MaxPrice"].ToString();
            objProject.UnitTypes = projectTable.Rows[0]["UnitTypes"].ToString().Split(',').ToList();
            objProject.Amenities = projectTable.Rows[0]["Amenities"].ToString().Split(',').ToList();
            objProject.AmenitiesOther = projectTable.Rows[0]["AmenitiesOther"].ToString();
            objProject.Highlights = projectTable.Rows[0]["Highlights"].ToString();
            objProject.Remark = projectTable.Rows[0]["Remark"].ToString();
            objProject.IsActive = Convert.ToBoolean(projectTable.Rows[0]["IsActive"]);

            MyDA.SelectCommand = new MySqlCommand("select * from unitConfiguration where BuilderprojectId=" + objProject.Id, Connection);
            DataTable unitConfTable = new DataTable();
            MyDA.Fill(unitConfTable);
            if(unitConfTable != null && unitConfTable.Rows.Count > 0)
            {
                objProject.UnitDetails = new List<UnitConfiguration>();
                foreach (DataRow row in unitConfTable.Rows)
                {
                    UnitConfiguration objUnitConf = new UnitConfiguration();
                    objUnitConf.Id = Convert.ToInt32(row["Id"]);
                    objUnitConf.BuildingName = row["BuildingName"].ToString();
                    objUnitConf.UnitName = row["UnitType"].ToString();
                    objUnitConf.Area = row["Area"].ToString();
                    objUnitConf.AreaUnit = row["AreaUnit"].ToString();
                    objUnitConf.Price = row["Price"].ToString();
                    objProject.UnitDetails.Add(objUnitConf);
                }
            }

            return objProject;
        }

        public int Insert(BuilderProject builderProject)
        {
            string sql = "INSERT INTO BuilderProject (ProjectName,ProjectType,BuilderId,Location,Landmark,Address,Pincode,PhoneNo1,PhoneNo2,Website,Email," +
                "LaunchDate,Status,PossessionDate,ReraApproved,ReraID,TotalUnit,LandArea,LandAreaUnit,StartPrice,MaxPrice,UnitTypes,Amenities,AmenitiesOther," +
                "Highlights,Remark, IsActive, CreatedDate) " +
                    "VALUES (@ProjectName,@ProjectType,@BuilderId,@Location,@Landmark,@Address,@Pincode,@PhoneNo1,@PhoneNo2,@Website,@Email,@LaunchDate,@Status," +
                    "@PossessionDate,@ReraApproved,@ReraID,@TotalUnit,@LandArea,@LandAreaUnit,@StartPrice,@MaxPrice,@UnitTypes,@Amenities,@AmenitiesOther," +
                    "@Highlights,@Remark, @IsActive, @CreatedDate)";

            MySqlCommand cmdBuilderProject = Connection.CreateCommand();
            cmdBuilderProject.CommandText = sql;
            cmdBuilderProject.Parameters.AddWithValue("@ProjectName", builderProject.Name);
            cmdBuilderProject.Parameters.AddWithValue("@ProjectType", builderProject.ProjectType);
            cmdBuilderProject.Parameters.AddWithValue("@BuilderId", builderProject.BuilderId);
            cmdBuilderProject.Parameters.AddWithValue("@Location", builderProject.Location);
            cmdBuilderProject.Parameters.AddWithValue("@Landmark", builderProject.Landmark);
            cmdBuilderProject.Parameters.AddWithValue("@Address", builderProject.Address);
            cmdBuilderProject.Parameters.AddWithValue("@Pincode", builderProject.Pincode);
            cmdBuilderProject.Parameters.AddWithValue("@PhoneNo1", builderProject.SitePhoneNo1);
            cmdBuilderProject.Parameters.AddWithValue("@PhoneNo2", builderProject.SitePhoneNo2);
            cmdBuilderProject.Parameters.AddWithValue("@Website", builderProject.Website);
            cmdBuilderProject.Parameters.AddWithValue("@Email", builderProject.Email);
            cmdBuilderProject.Parameters.AddWithValue("@LaunchDate", builderProject.LaunchDate);
            cmdBuilderProject.Parameters.AddWithValue("@Status", builderProject.CurrentStatus);
            cmdBuilderProject.Parameters.AddWithValue("@PossessionDate", builderProject.PossessionDate);
            cmdBuilderProject.Parameters.AddWithValue("@ReraApproved", builderProject.ReraApproved);
            cmdBuilderProject.Parameters.AddWithValue("@ReraID", builderProject.ReraID);
            cmdBuilderProject.Parameters.AddWithValue("@TotalUnit", builderProject.TotalUnits);
            cmdBuilderProject.Parameters.AddWithValue("@LandArea", builderProject.TotalLandArea);
            cmdBuilderProject.Parameters.AddWithValue("@LandAreaUnit", builderProject.LandAreaUnit);
            cmdBuilderProject.Parameters.AddWithValue("@StartPrice", builderProject.StartPrice);
            cmdBuilderProject.Parameters.AddWithValue("@MaxPrice", builderProject.MaxPrice);
            cmdBuilderProject.Parameters.AddWithValue("@UnitTypes", String.Join(",", builderProject.UnitTypes));
            cmdBuilderProject.Parameters.AddWithValue("@Amenities", String.Join(",", builderProject.Amenities));
            cmdBuilderProject.Parameters.AddWithValue("@AmenitiesOther", builderProject.AmenitiesOther);
            cmdBuilderProject.Parameters.AddWithValue("@Highlights", builderProject.Highlights);
            cmdBuilderProject.Parameters.AddWithValue("@Remark", builderProject.Remark);
            cmdBuilderProject.Parameters.AddWithValue("@IsActive", builderProject.IsActive);
            cmdBuilderProject.Parameters.AddWithValue("@CreatedDate", builderProject.CreatedDate);

            cmdBuilderProject.ExecuteNonQuery();

            string insertSql;
            MySqlCommand cmd;
            foreach (var unitDetail in builderProject.UnitDetails)
            {
                insertSql = "INSERT INTO UnitConfiguration (BuilderProjectId,BuildingName,UnitType,Area,AreaUnit,Price) " +
                    "VALUES (@BuilderProjectId,@BuildingName,@UnitType,@Area,@AreaUnit,@Price)";

                cmd = Connection.CreateCommand();
                cmd.CommandText = insertSql;
                cmd.Parameters.AddWithValue("@BuilderProjectId", cmdBuilderProject.LastInsertedId);
                cmd.Parameters.AddWithValue("@BuildingName", unitDetail.BuildingName);
                cmd.Parameters.AddWithValue("@UnitType", unitDetail.UnitName);
                cmd.Parameters.AddWithValue("@Area", unitDetail.Area);
                cmd.Parameters.AddWithValue("@AreaUnit", unitDetail.AreaUnit);
                cmd.Parameters.AddWithValue("@Price", unitDetail.Price);

                cmd.ExecuteNonQuery();
            }

            return Convert.ToInt32(cmdBuilderProject.LastInsertedId);
        }

        public DataTable GetBuilderProjects(BuilderProjectSearch builderProjectSearch = null)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string searchQuery = "select bp.id as 'Sr No', bp.ProjectName, bp.ProjectType, b.Name as BuilderName, bp.Location, " +
                "bp.PhoneNo1,bp.Status,bp.Website,bp.Email, bp.Address,bp.ReraApproved, bp.ReraID, bp.StartPrice,bp.LandArea, bp.LandAreaUnit " + 
                "from builderproject bp join builder b on bp.BuilderId = b.id " +
                "where bp.IsActive=" + (builderProjectSearch != null && !builderProjectSearch.Active ? 0 : 1);

            if (builderProjectSearch != null)
            {
                if (builderProjectSearch.ProjectName != null && !string.IsNullOrEmpty(builderProjectSearch.ProjectName))
                {
                    searchQuery = searchQuery + " and (LOWER(bp.ProjectName) like '%" + builderProjectSearch.ProjectName.ToLower() + "%')";
                }

                if (builderProjectSearch.BuilderName != null && !string.IsNullOrEmpty(builderProjectSearch.BuilderName))
                {
                    searchQuery = searchQuery + " and (LOWER(b.Name) like '%" + builderProjectSearch.BuilderName.ToLower() + "%')";
                }

                    //if (builderProjectSearch.BuilderName != null && !string.IsNullOrEmpty(builderProjectSearch.BuilderName))
                    //{
                    //    List<int> builderIds = new List<int>();
                    //    string builderQuery = string.Empty;
                    //    builderQuery = "select id from builder where ";
                    //    builderQuery = builderQuery + " (LOWER(b.name) like '%" + builderProjectSearch.BuilderName.ToLower() + "%')";

                    //    if (!String.IsNullOrEmpty(builderQuery))
                    //    {
                    //        MyDA.SelectCommand = new MySqlCommand(builderQuery, Connection);

                    //        DataTable builderTable = new DataTable();
                    //        MyDA.Fill(builderTable);
                    //        builderIds = (from DataRow dr in builderTable.Rows
                    //                     select Convert.ToInt32(dr["id"])).ToList();
                    //    }
                    //    if (builderIds.Count > 0)
                    //    {
                    //        searchQuery = searchQuery + " and BuilderId in (" + string.Join(",", builderIds) + ")";
                    //    }
                    //}

                string unitTypeFilter = string.Empty;
                if (builderProjectSearch.UnitTypes != null && builderProjectSearch.UnitTypes.Count > 0)
                {
                    foreach (string unitType in builderProjectSearch.UnitTypes)
                    {
                        if (unitType == "") continue;
                        unitTypeFilter = unitTypeFilter + (string.IsNullOrEmpty(unitTypeFilter) ? "(bedroomcount like '%" + unitType + "%'" : "or bedroomcount like '%" + unitType + "%'");
                    }
                    unitTypeFilter = unitTypeFilter + (string.IsNullOrEmpty(unitTypeFilter) ? string.Empty : ")");

                    if (!string.IsNullOrEmpty(unitTypeFilter))
                    {
                        searchQuery = searchQuery + " and " + unitTypeFilter;
                    }
                }

                if (builderProjectSearch.Locations != null && builderProjectSearch.Locations.Count > 0)
                {
                    searchQuery = searchQuery + " and ";
                    string locationFilter = string.Empty;
                    foreach (string loc in builderProjectSearch.Locations)
                    {
                        locationFilter = locationFilter + (string.IsNullOrEmpty(locationFilter) ? (" location like '%" + loc + "%'") : (" or location like '%" + loc + "%'"));
                    }

                    searchQuery = searchQuery + "(" + locationFilter + ")";
                }

                if (!string.IsNullOrEmpty(builderProjectSearch.PossessionFrom) && !string.IsNullOrEmpty(builderProjectSearch.PossessionTo))
                {
                    searchQuery = searchQuery + " and possessionDate between STR_TO_DATE('" + builderProjectSearch.PossessionFrom + "', '%d/%m/%Y') and STR_TO_DATE('" + builderProjectSearch.PossessionTo + "', '%d/%m/%Y')";
                }
            }

            MyDA.SelectCommand = new MySqlCommand(searchQuery, Connection);
            DataTable projectTable = new DataTable();
            MyDA.Fill(projectTable);

            return projectTable;
        }

        public int Update(BuilderProject builderProject)
        {
            string sql = "UPDATE BuilderProject SET ProjectName=@ProjectName,ProjectType=@ProjectType,BuilderId=@BuilderId,Location=@Location,Landmark=@Landmark," +
                "Address=@Address,Pincode=@Pincode,PhoneNo1=@PhoneNo1,PhoneNo2=@PhoneNo2,Website=@Website,Email=@Email," +
                "LaunchDate=@LaunchDate,Status=@Status,PossessionDate=@PossessionDate,ReraApproved=@ReraApproved,ReraID=@ReraID,TotalUnit=@TotalUnit," +
                "LandArea=@LandArea,LandAreaUnit=@LandAreaUnit,StartPrice=@StartPrice,MaxPrice=@MaxPrice,UnitTypes=@UnitTypes,Amenities=@Amenities," +
                "AmenitiesOther=@AmenitiesOther,Highlights=@Highlights,Remark=@Remark, IsActive=@IsActive,CreatedDate=@CreatedDate where id=@id";
            
            MySqlCommand cmdBuilderProject = Connection.CreateCommand();
            cmdBuilderProject.CommandText = sql;
            cmdBuilderProject.Parameters.AddWithValue("@ProjectName", builderProject.Name);
            cmdBuilderProject.Parameters.AddWithValue("@ProjectType", builderProject.ProjectType);
            cmdBuilderProject.Parameters.AddWithValue("@BuilderId", builderProject.BuilderId);
            cmdBuilderProject.Parameters.AddWithValue("@Location", builderProject.Location);
            cmdBuilderProject.Parameters.AddWithValue("@Landmark", builderProject.Landmark);
            cmdBuilderProject.Parameters.AddWithValue("@Address", builderProject.Address);
            cmdBuilderProject.Parameters.AddWithValue("@Pincode", builderProject.Pincode);
            cmdBuilderProject.Parameters.AddWithValue("@PhoneNo1", builderProject.SitePhoneNo1);
            cmdBuilderProject.Parameters.AddWithValue("@PhoneNo2", builderProject.SitePhoneNo2);
            cmdBuilderProject.Parameters.AddWithValue("@Website", builderProject.Website);
            cmdBuilderProject.Parameters.AddWithValue("@Email", builderProject.Email);
            cmdBuilderProject.Parameters.AddWithValue("@LaunchDate", builderProject.LaunchDate);
            cmdBuilderProject.Parameters.AddWithValue("@Status", builderProject.CurrentStatus);
            cmdBuilderProject.Parameters.AddWithValue("@PossessionDate", builderProject.PossessionDate);
            cmdBuilderProject.Parameters.AddWithValue("@ReraApproved", builderProject.ReraApproved);
            cmdBuilderProject.Parameters.AddWithValue("@ReraID", builderProject.ReraID);
            cmdBuilderProject.Parameters.AddWithValue("@TotalUnit", builderProject.TotalUnits);
            cmdBuilderProject.Parameters.AddWithValue("@LandArea", builderProject.TotalLandArea);
            cmdBuilderProject.Parameters.AddWithValue("@LandAreaUnit", builderProject.LandAreaUnit);
            cmdBuilderProject.Parameters.AddWithValue("@StartPrice", builderProject.StartPrice);
            cmdBuilderProject.Parameters.AddWithValue("@MaxPrice", builderProject.MaxPrice);
            cmdBuilderProject.Parameters.AddWithValue("@UnitTypes", String.Join(",", builderProject.UnitTypes));
            cmdBuilderProject.Parameters.AddWithValue("@Amenities", String.Join(",", builderProject.Amenities));
            cmdBuilderProject.Parameters.AddWithValue("@AmenitiesOther", builderProject.AmenitiesOther);
            cmdBuilderProject.Parameters.AddWithValue("@Highlights", builderProject.Highlights);
            cmdBuilderProject.Parameters.AddWithValue("@Remark", builderProject.Remark);
            cmdBuilderProject.Parameters.AddWithValue("@IsActive", builderProject.IsActive);
            cmdBuilderProject.Parameters.AddWithValue("@CreatedDate", builderProject.CreatedDate);
            cmdBuilderProject.Parameters.AddWithValue("@id", builderProject.Id);

            cmdBuilderProject.ExecuteNonQuery();

            string unitConfSql;
            MySqlCommand cmd;
            foreach (var unitDetail in builderProject.UnitDetails)
            {
                if (unitDetail.Id != 0)
                {
                    unitConfSql = "UPDATE UnitConfiguration SET BuilderProjectId=@BuilderProjectId,BuildingName=@BuildingName," +
                        "UnitType=@UnitType,Area=@Area,AreaUnit=@AreaUnit,Price=@Price where id=@Id";
                }
                else
                {
                    unitConfSql = "INSERT INTO UnitConfiguration (BuilderProjectId,BuildingName,UnitType,Area,AreaUnit,Price) " +
                        "VALUES (@BuilderProjectId,@BuildingName,@UnitType,@Area,@AreaUnit,@Price)";
                }

                cmd = Connection.CreateCommand();
                cmd.CommandText = unitConfSql;
                cmd.Parameters.AddWithValue("@BuilderProjectId", builderProject.Id);
                cmd.Parameters.AddWithValue("@BuildingName", unitDetail.BuildingName);
                cmd.Parameters.AddWithValue("@UnitType", unitDetail.UnitName);
                cmd.Parameters.AddWithValue("@Area", unitDetail.Area);
                cmd.Parameters.AddWithValue("@AreaUnit", unitDetail.AreaUnit);
                cmd.Parameters.AddWithValue("@Price", unitDetail.Price);
                cmd.Parameters.AddWithValue("@Id", unitDetail.Id);
                cmd.ExecuteNonQuery();
            }

            return Convert.ToInt32(cmdBuilderProject.LastInsertedId);
        }
    }
}
