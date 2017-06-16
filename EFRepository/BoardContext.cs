using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    public class BoardContext : DbContext
    {
        public BoardContext(): base("Board") { }
        public DbSet<User> Users { get; set; }
    }
}
