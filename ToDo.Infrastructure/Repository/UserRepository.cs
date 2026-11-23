using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;
using ToDo.Domain.RepositoryInterface;
using ToDo.Infrastructure.Persistence.Entities;

namespace ToDo.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<UserDomain, User>, IUserRepository
    {
        public UserRepository(
            ToDoAppDbContext toDoAppDbContext,
            IMapper mapper) : base(toDoAppDbContext, mapper)
        {

        }
    }
}
