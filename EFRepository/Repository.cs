using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    public class Repository : IRepository
    {
        public List<User> GetUsers()
        {
            using(var db = new BoardContext())
            {
                return db.Users.ToList();
            }
        }
    }
}
