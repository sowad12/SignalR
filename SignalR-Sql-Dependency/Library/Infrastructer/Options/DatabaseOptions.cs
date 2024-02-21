using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructer.Options
{
    public  class DatabaseOptions
    {
        public string ConnectionString { get; set; }
        public string SecretKey { get; set; }
    }
}
