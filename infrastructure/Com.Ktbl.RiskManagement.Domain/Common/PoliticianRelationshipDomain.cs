using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain.Common
{
    public class PoliticianRelationshipDomain
    {
        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string SingleStringName { get; set; }
    }
}
