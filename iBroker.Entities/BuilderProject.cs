using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class BuilderProject
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string ProjectType { get; set; }
        public string Name { get; set; }
        public int BuilderId { get; set; }
        public string CurrentStatus { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Landmark { get; set; }
        public string SitePhoneNo1 { get; set; }
        public string SitePhoneNo2 { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public bool ReraApproved { get; set; }
        public string ReraID { get; set; }
        public string LaunchDate { get; set; }
        public string PossessionDate { get; set; }
        public int TotalLandArea { get; set; }
        public string LandAreaUnit { get; set; }
        public List<string> UnitTypes { get; set; }
        public int TotalUnits { get; set; }
        //public List<Phase> Phases { get; set; }
        public List<string> Amenities { get; set; }
        public string AmenitiesOther { get; set; }
        public string StartPrice { get; set; }
        public string MaxPrice { get; set; }
        public string Highlights { get; set; }
        public List<UnitConfiguration> UnitDetails { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
    }

    //public class Phase
    //{
    //    public string PhaseNo { get; set; }
    //    public string ReraNo { get; set; }
    //    public string LaunchDate { get; set; }
    //    public string PossessionDate { get; set; }
    //}

    public class UnitConfiguration
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string UnitName { get; set; }
        public string Area { get; set; }
        public string AreaUnit { get; set; }
        public string Price { get; set; }
    }
}
