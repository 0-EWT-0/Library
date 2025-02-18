using Library.Models.Domain;
namespace Library.Services.IServices
{
    public interface IRolServices
    {
        public Task<List<Rol>> GettAll();
    }
}
