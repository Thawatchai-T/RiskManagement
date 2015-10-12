using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Com.Ktbl.RiskManagement.Map.Repository;
using Quartz;

namespace Com.Ktbl.RiskManagement.Process
{
    public class BatchJobs: IJob
    {
        public IBatchTBRepository BatchTBRepository { get; set; }
        public MainProcess MainProcess { get; set; }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                  
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
