using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadListApp
{
    class ReadListContext : DbContext
    {
        public ReadListContext() : base("ConnectionStringReadListDB") {}

        public DbSet<ReadList> ReadLists { get; set; }
    }
}
