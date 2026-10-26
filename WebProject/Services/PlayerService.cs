using System.Reflection.Metadata.Ecma335;
using WebProject.Data.Models;

namespace WebProject.Services
{
    public class PlayerService
    {
        private readonly WebProjectDbContext dbContext;
        public PlayerService(WebProjectDbContext context)
        {
            this.dbContext = context;
        }
        public bool UserHasCharacter(string userId)
        {
            bool result =
                dbContext
                .Players
                .Any(p => p.UserId == userId);

                return result;
        }
    }
}
