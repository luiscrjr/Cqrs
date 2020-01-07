using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Configurations
{
    public class MongoDbSettings
    {
        public string Host{ get; set; }
        public string Database { get; set; }
        public bool IsSSL { get; set; }
    }
}
