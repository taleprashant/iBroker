using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class BuilderProjectSearch
    {
        public bool Active { get; set; }
        public string ProjectName { get; set; }
        public string BuilderName { get; set; }
        public List<string> Locations { get; set; }
        public string PossessionFrom { get; set; }
        public string PossessionTo { get; set; }
        public List<string> UnitTypes { get; set; }
    }
}
