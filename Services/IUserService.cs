using FirestoreUserDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreUserDemo.Services
{
    public interface IUserService
    {
        Task<User> Create(User user);

        Task<User> Update(User user);

        Task<User> GetById(string id);

        Task<IEnumerable<User>> GetAll();

        Task Delete(string id);
    }
}
