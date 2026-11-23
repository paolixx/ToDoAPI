using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;

namespace ToDo.Domain.RepositoryInterface
{
    public interface IUserRepository : IGenericRepository<UserDomain>
    {
    }
}
