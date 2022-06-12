using Domain.Agilis.Entities;
using Domain.Agilis.Enums;
using Microsoft.EntityFrameworkCore;

namespace Repository.Agilis.Seeds
{
    public static class UserSeed
    {
        public static void Users(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity()
                {
                    Id = 1,
                    Email = "admin@agilis.com",
                    Password = "e10adc3949ba59abbe56e057f20f883e", //123456
                    Role = ERoleUser.Administrator,
                    Active = true
                }
            );
        }
    }
}
