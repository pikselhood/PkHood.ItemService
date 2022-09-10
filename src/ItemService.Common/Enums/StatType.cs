namespace ItemService.Common.Enums;

public enum StatType
{
    Health = 0,
    Mana = 1,
    HealthRegen = 2,
    ManaRegen = 3,
    Strength = 4,
    Vitality = 5,
    Dexterity = 6,
    Intelligent = 7,
    Wisdom = 8,
    Defense = 9,
    MinDamage = 10,
    MaxDamage = 11,
}

public static class StatTypes
{
    public static double GetValue(StatType type)
    {
        return type switch
        {
            StatType.Health => 500,
            StatType.Mana => 300,
            StatType.HealthRegen => 5,
            StatType.ManaRegen => 3,
            StatType.Strength => 20,
            StatType.Vitality => 20,
            StatType.Dexterity => 20,
            StatType.Intelligent => 20,
            StatType.Wisdom => 20,
            StatType.Defense => 20,
            StatType.MinDamage => 250,
            StatType.MaxDamage => 300,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}