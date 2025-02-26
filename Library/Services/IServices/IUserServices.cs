using Library.Context;
using Library.Models.Domain;

namespace Library.Services.IServices
{
    public interface IUserServices
    {
        public List<User> GetUsers();
        public bool CreateUser(User request);

        public User GetById(int id);

        public bool UpdateUser(User request);

        public User DeleteUser(int id);

    }
}
