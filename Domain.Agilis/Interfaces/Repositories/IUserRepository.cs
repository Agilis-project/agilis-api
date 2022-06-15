﻿using Domain.Agilis.Entities;

namespace Domain.Agilis.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        bool ExistEmailEquals(string email, int id);
    }
}
