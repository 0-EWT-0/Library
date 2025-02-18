using Library.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Context
{
    public class ApplicationDBContext : DbContext
    {

        //Add-migration Example

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData
                (
                 new User
                 {
                     Pk_user_id = 1,
                     Name = "EWT",
                     User_name = "admin",
                     Password = "root123",
                     Fk_rol_id = 1
                 },
                 new User
                 {
                     Pk_user_id = 2,
                     Name = "User",
                     User_name = "username",
                     Password = "123",
                     Fk_rol_id = 2
                 });
            modelBuilder.Entity<Rol>()
                .HasData
                (

                new Rol
                {
                 Pk_rol_id = 1,
                 Pk_rol_name = "Admin"
                },
                new Rol
                {
                 Pk_rol_id = 2,
                 Pk_rol_name = "User"
                });
        }

    }
}
