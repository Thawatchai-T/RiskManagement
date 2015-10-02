using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class CorporationDomain: CommonDomain
    {
        public virtual int Id { get; set; }
        public virtual int Nationality { get; set; }
        public virtual bool IsRegistrationThai { get; set; }
        public virtual string RegistrationId { get; set; }
        public virtual int RegistrationType { get; set; }
        public virtual string CompanyName { get; set; }

        public virtual string OccupationCategoryId { get; set; }
        public virtual string OccupationGroupId { get; set; }
        public virtual string OccupationTypeId { get; set; }
        public virtual string PositionId { get; set; }
        public virtual int BusinessId { get; set; }

        public virtual int SourceOfIncome { get; set; }
        public virtual int LocationOfIncome { get; set; }
        public virtual int LiveInCountry { get; set; }
        public virtual int PoliticianRelationship { get; set; }
        
        public virtual int ISicId { get; set; }
        public virtual string PathFile { get; set; }
        public virtual string PathFile1 { get; set; }
        public virtual string Result { get; set; }
        public virtual string Extension1 { get; set; }
        public virtual string Extension2 { get; set; }
             
    }
}
