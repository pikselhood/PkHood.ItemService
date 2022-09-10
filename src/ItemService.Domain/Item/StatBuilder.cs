using ItemService.Common.Enums;
using ItemService.Common.PkRandom;

namespace ItemService.Domain.Item;

public class StatBuilder
{
    public double? Value { get; private set; }
    public double? Quality { get; private set; }
    public StatType? Type { get; private set; }
    public int DropRate { get; }
    public double Efficiency { get; }
    public ItemTier Tier { get; }

    private StatBuilder(int dropRate, double efficiency, ItemTier tier)
    {
        DropRate = dropRate;
        Efficiency = efficiency;
        Tier = tier;
    }

    public static StatBuilder CreateInstance(int dropRate, double efficiency, ItemTier tier)
    {
        return new StatBuilder(dropRate, efficiency, tier);
    }
    
    public StatBuilder WithType(StatType type)
    {
        Type = type;
        return this;
    }
    
    public StatBuilder WithQuality(double quality)
    {
        Quality = quality;
        return this;
    }

    public Stat Build()
    {
        if (Type == null)
        {
            var statTypeCount = Enum.GetNames(typeof(StatType)).Length;
            var statTypeNumber = PkRandom.Get(1, statTypeCount);
            Type = (StatType)statTypeNumber;
        }

        if (Quality == null)
        {
            Quality = PkRandom.GetWithActivation(DropRate);
        }
        
        if (Value == null)
        {
            var value = StatTypes.GetValue((StatType) Type) * ItemTiers.GetEfficiency(Tier) * Efficiency * Quality ?? 0;
            Value = Math.Round(value, 2);
        }
        
        return new Stat((StatType) Type, (double) Quality, (double) Value);
    }
}