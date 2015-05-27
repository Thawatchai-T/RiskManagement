using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;
using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.Remoting;

namespace Com.Ktbl.RiskManagement.Aspect
{
    public class LoggingThrowsAdvice: IThrowsAdvice
    {
        public string MongoDBConnection { get; set; }

        public void AfterThrowing(Exception ex)
        {
            Console.Error.WriteLine(
                String.Format("Advised method threw this exception : {0}", ex.Message));
        }

        public void AfterThrowing(MethodInfo method, object[] args, object target, SqlException ex)
        {
            //Do something will all arguments
        }

        public void AfterThrowing(RemotingException ex)
        {
            // Do something with remoting exception
        }
    }
}
