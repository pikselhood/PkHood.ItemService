namespace ItemService.Common.Enums;

public enum ItemTier
{
    Common = 0,
    Rare = 1,
    Epic = 2,
    Legendary = 3 
}

public static class ItemTiers
{
    public static double GetEfficiency(ItemTier tier)
    {
        return tier switch
        {
            ItemTier.Common => 0.4,
            ItemTier.Rare => 0.6,
            ItemTier.Epic => 0.8,
            ItemTier.Legendary => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(tier), tier, null)
        };
    }
}