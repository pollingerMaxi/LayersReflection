using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepository
    {
        List<User> GetUsers();
    }
}