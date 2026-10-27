using WebProject.ViewModels;

namespace WebProject.Services.Interfaces
{
    public interface IPlayerService
    {
        bool UserHasCharacter(string userId);
        void CreateCharacter(string userId, CreatePlayerViewModel model);
        void RemoveCharacter(string userId);
        void RenameCharacter(string userId, string rename);
        PlayerStatsViewModel GetStatusPage(string userId);



    }
}
