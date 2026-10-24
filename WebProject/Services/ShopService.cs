using WebProject.Data.Models;

namespace WebProject.Services
{
    public class ShopService
    {

        private readonly WebProjectDbContext dbContext;
        public ShopService(WebProjectDbContext context)
        {
            this.dbContext = context;
        }

        public void BuyDamageUpgrade()
        {
            int playerId = dbContext.Players.First().Id;

            Player currentPlayer = dbContext.Players.First(p => p.Id == playerId);

            currentPlayer.Gold -= 100;
            currentPlayer.Strength += 1;
            dbContext.SaveChanges();
            

        }

        public void BuyHealthUpgrade()
        {
            int playerId = dbContext.Players.First().Id;

            Player currentPlayer = dbContext.Players.First(p => p.Id == playerId);

            currentPlayer.Gold -= 50;
            currentPlayer.Hitpoints += 20;
            dbContext.SaveChanges();


        }
        public void CraftWeapon()
        {
            int playerId = dbContext.Players.First().Id;

            Player currentPlayer = dbContext.Players.First(p => p.Id == playerId);

            //Create item logic here

            //Player stat update here
            

        }
        public void CraftArmor()
        {
            int playerId = dbContext.Players.First().Id;

            Player currentPlayer = dbContext.Players.First(p => p.Id == playerId);

            //Create item logic here

            //Player stat update here

        }


    }
}
