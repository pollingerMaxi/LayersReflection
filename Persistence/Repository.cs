using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class Repository : IRepository
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Name = "Juan"
                },
                new User()
                {
                    Name = "Luis"
                }
            };
        }
    }
}
