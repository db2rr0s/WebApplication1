using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
    }
}
