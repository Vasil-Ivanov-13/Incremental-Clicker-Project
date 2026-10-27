# Incremental-Clicker-Project



This is a browser based basic combat game with light character progression. For the time being at least. It's build with ASP.NET CORE MVC.
Players can register an account and create a character using one of (for now) three very basic templates. They can create basic items that increase their performance in combat and remove them, as there is a random number behind their properties. 
The player can enter the cave and start fighting enemies using a button and a simple combat log registers the battle.



# Main Features:



* **Accounts:** register and log in with ASP.NET Core Identity.
* **Character creation:** choose a name and a class (Basic, Warrior or Rogue). Each class starts with different health and strength.
* **Character page:** view stats, weapon and armour in separate cards. Rename or remove your character and remove your items.
* **Combat:** fight the current enemy and read a round-by-round combat log. Winning grants experience and gold, and experience levels the character up. Losing means a narrow escape with a small amount of gold. No way to soft lock for now.
* **Enemy Generation:** when all enemies are defeated, a new set of enemies is generated based on the player's level.
* **Shop:** buy strength or health upgrades with gold. 
* **Item crafting (Weapon Forge / Armour Forge):** name and craft one weapon and one armour piece. Their stats are rolled randomly, and they affect combat stats.
* **Validation:** server-side (data annotations and `ModelState`) and client-side (jQuery validation and HTML attributes), with feedback messages when an action fails (for example, not enough gold).
* 

## Technologies Used:



* ASP.NET Core MVC (.NET 8)
* Entity Framework Core with SQL Server Express
* ASP.NET Core Identity
* Razor views with a shared layout, partial views and sections
* Bootstrap 5
* Dependency Injection with service interfaces



## Project Structure


Controllers: MVC controllers (GameScreen, Player, Shop, Home)
Services: Business logic behind interfaces (IPlayerService, ICombatService, IShopService)
Data: DbContext, entity models, migrations
ViewModels: View models used by the views
Views: Razor views and partial views
Common: Shared constants (validation rules, costs)


## Entities:



* ApplicationUser (Identity user, one-to-one with `Player`)
* Player (name, class, hitpoints, strength, level, experience, gold)
* WeaponItem (one-to-one with Player, name, strength, damagepoints)
* ArmourItem (one-to-one with Player, name, healthpoints)
* Enemy (level, hitpoints, damage, alive state)



## Getting started:



* Clone the repository from GitHub (url: https://github.com/Vasil-Ivanov-13/Incremental-Clicker-Project.git)
* The connection string is set to "DefaultConnection": "Server=.\\\\SQLEXPRESS;Database=WebProject\_Oct2026;Trusted\_Connection=True;TrustServerCertificate=True", so it should run on any machine
* Update the database with the package manager console. (update-database)
* That would apply the migrations, and the app is ready to run.



### 5\. Try it out :



1. Register a new account (the password requirements are relaxed for testing, 4 characters minimum).
2. Open **Character Creator** and create a character.
3. Go to **Game Screen** and press **Fight**. The first fight generates enemies, as none are seeded.
4. Earn gold, then visit the **Shop Screen**, **Weapon Forge** and **Armour Forge**.
5. Open the character page to rename or remove your character and items and see your progression.(progression being number increases in this case.)

## Environment Variables and Credentials

No test accounts or requirements. Register your own account.

## Planned Improvements

* Split CombatService into smaller services (for example, progression and enemy generation).
* Add an inventory system with multiple item slots.

## Author

Vasil Ivanov

* email : vasilIvanovPersonal@gmail.com






