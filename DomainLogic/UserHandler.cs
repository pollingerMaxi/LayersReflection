using Entities;
using Interfaces;
using LibraryCache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic
{
    public class UserHandler
    {
        private IRepository repository { get; set; }
        public UserHandler()
        {
            this.repository = Cache.GetInstance<IRepository>();
        }

        public List<User> GetUsers()
        {
            return repository.GetUsers();
        }
    }
}
