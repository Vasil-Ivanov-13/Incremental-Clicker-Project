namespace WebProject.Common
{
    public static class EntityValidations
    {
        //Player Validations

        public const int PlayerNameMaxLength = 15;
        public const int PlayerNameMinLength = 2;

        //Player Validations End

        //Class stat Validations Start

        public const int WarriorHealth = 100;
        public const int WarriorStrength = 2;
        public const int RogueHealth = 70;
        public const int RogueStrength = 3;
        public const int BasicHealth = 50;
        public const int BasicStrength = 2;
        //Class stat Validations End

        //Item Validations Start

        public const int ItemNameMaxLength = 15;
        public const int ItemNameMinLength = 2;

        public const int ItemMaxDamage = 10;

        public const int ItemMinDamage = -2;

        public const int ItemStrengthModifierMinValue = 0;
        public const int ItemStrengthModifierMaxValue = 3;


        public const int WeaponCost = 100;
        public const int ArmourCost = 100;

        public const int ItemMaxHealth = 30;

        public const int ItemMinHealth = 1;

        //Item Validations End

        //Stat Shop Validation Start

        public const int DamageCost = 100;
        public const int HealthCost = 70;
        public const int StrengthIncrement = 1;
        public const int HealthIncrement = 15;

        //Stat Shop Validation End


    }
}
