using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class ViewShareholdersDomain
    {
        public virtual int Id { get; set; }
        public virtual int CorporationId { get; set; }
        public virtual string CitizenId { get; set; }

        public virtual int CommitteeType { get; set; }
        public virtual string CommitteeTypeName { get; set; }
        
        public virtual int BusinessId { get; set; }
        public virtual string BusinessName { get; set; }

        public virtual int SourceOfIncome { get; set; }
        public virtual string SourceOfIncomeName { get; set; }

        public virtual int PoliticianRelationship { get; set; }
        public virtual string PoliticianRelationshipName { get; set; }
        public virtual string OccupationTypeId { get; set; }
        public virtual string OccupationTypeName { get; set; }
    }
}
