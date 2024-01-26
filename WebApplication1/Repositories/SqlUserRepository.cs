using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly modelContext context;
        public SqlUserRepository(modelContext context)
        {
            this.context = context;
        }

        public async Task<User> LoginAsync(string userName, string userPw)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.userName == userName && x.userPw == userPw);
        }

       
    }
}
