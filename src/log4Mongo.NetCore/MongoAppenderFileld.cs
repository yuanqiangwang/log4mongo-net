using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace log4Mongo.NetCore
{
    public class MongoAppenderFileld
    {
        public string Name { get; set; }
        public IRawLayout Layout { get; set; }
    }
}
