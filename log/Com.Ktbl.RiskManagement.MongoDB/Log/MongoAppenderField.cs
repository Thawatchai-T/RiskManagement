using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Layout;

namespace Com.Ktbl.RiskManagement.MongoDB.Log
{
    public class MongoAppenderField
    {
        /// <summary>
        /// Gets or sets the name of the log field
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the log layout type that will format the final log entry
        /// </summary>
        public IRawLayout Layout { get; set; }

        /// <summary>
        /// Gets or sets the log format value
        /// </summary>
        public String Value { get; set; }
    }
}
