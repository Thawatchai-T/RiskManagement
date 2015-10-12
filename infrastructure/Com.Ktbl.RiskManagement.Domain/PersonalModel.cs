using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class PersonalModel
    {
       public virtual int Id {get; set;}
       public virtual string CitizenId { get; set; }
       public virtual int TitleId { get; set; }
       public virtual string FirstName { get; set; }
       public virtual string LastName { get; set; }
       public virtual string OccupationCategoryId { get; set; }
       public virtual string OccupationGroupId { get; set; }
       public virtual string OccupationTypeId { get; set; }
       public virtual string PositionId { get; set; }
       public virtual int BusinessId { get; set; }
       public virtual int SourceOfIncome { get; set; }
       public virtual int LocationOfIncome {get; set;}
       public virtual int LiveInCountry { get; set; }
       public virtual int PoliticianRelationship { get; set; }
       public virtual string PathFile { get; set; }
       public virtual string PathFile1 { get; set; }
       public virtual string Result { get; set; }
       public virtual string Extension1 { get; set; }
       public virtual string Extension2 { get; set; }
       public virtual string AppKey { get; set; }
       public virtual string UserId { get; set; }
       public virtual string RequestNo { get; set; }



       public virtual string CreateBy { get; set; }

       public virtual DateTime CreateDate { get; set; }

       public virtual string UpdateBy { get; set; }

       public virtual DateTime UpdateDate { get;
           set;
       }
    }
}

