using Library.Context;
using Library.Models.Domain;
using Library.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDBContext _context;
        public UserServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            try
            {
                List<User> result = _context.User.Include(x => x.Rol).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("an error has ocurred" + ex.Message);
            }
        }

        public bool UpdateUser(User request)
        {
            try
            {
                User user = _context.User.FirstOrDefault(x => x.Pk_user_id == request.Pk_user_id);
                user.Name = request.Name;
                user.User_name = request.User_name;
                user.Password = request.Password;
                user.Fk_rol_id = request.Fk_rol_id;

                _context.User.Update(user);

                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("an error has ocurred" + ex.Message);
            }
        }

        public bool CreateUser(User request)
        {
            try
            {
                User user = new User()
                {
                    Name = request.Name,
                    User_name = request.User_name,
                    Password = request.Password,
                    Fk_rol_id = request.Fk_rol_id

                };

                _context.User.Add(user);
                var result = _context.SaveChanges();

                if (result > 0 )
                {
                    return true;
                } else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("an error has ocurred" + ex.Message);
                
            }
        }

        public User GetById(int id)
        {
            try
            {
                User user = _context.User.FirstOrDefault(x => x.Pk_user_id == id);
                return user;
            }
            catch (Exception ex) {
                throw new Exception("an error has ocurred" + ex.Message);
            }
        }
        }
}
