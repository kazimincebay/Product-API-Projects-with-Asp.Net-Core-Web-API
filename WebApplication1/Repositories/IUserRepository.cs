using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IUserRepository
    {
        Task<User> LoginAsync(string userName,string userPw);
    }
}
