using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class OccupationCatelogyDomain //: CommonDomain
    {
        public OccupationCatelogyDomain()
        {
            OccupationGroups = new List<OccupationGroupDomain>();
        }
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<OccupationGroupDomain> OccupationGroups { get; set; }
    }
}
