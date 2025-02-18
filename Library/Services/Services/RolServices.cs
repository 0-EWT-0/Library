using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models.Domain;
using Library.Services.IServices;
using Library.Context;

namespace Library.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDBContext _context;

        public RolServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GettAll()
        {
            try
            {
                List<Rol> result = await _context.Rol.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("An error has ocurred" + ex.Message);

            }
        }
    }
}