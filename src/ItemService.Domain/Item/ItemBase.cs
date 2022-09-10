using ItemService.Common;
using ItemService.Common.Enums;
using ItemService.Common.PkRandom;

namespace ItemService.Domain.Item;

public class ItemBase
{
    public Guid Id { get; set; }
    public ItemType Type { get; set; }
    public string TypeName => Type.ToString();
    public string Name { get; set; }
    public ItemTier Tier { get; set; }
    public string TierName => Tier.ToString();
    public int Upgrade { get; set; }
    public double Quality { get; set; }
    public Stat Stat1 { get; set; }
    public Stat Stat2 { get; set; }
    public Stat Stat3 { get; set; }
    public List<Stat> ExtraStatList { get; }

    public ItemBase(int dropRate, string name, ItemType type, double efficiency, StatType stat1Type, StatType stat2Type, StatType stat3Type)
    {
        Id = Guid.NewGuid();
        Type = type;
        Upgrade = 0;
        Name = name;
        Tier = CalculateTier(dropRate); 
        Quality = PkRandom.GetWithActivation(dropRate);
        Stat1 = StatBuilder.CreateInstance(dropRate, efficiency, Tier).WithType(stat1Type).WithQuality(Quality).Build();
        Stat2 = StatBuilder.CreateInstance(dropRate, efficiency, Tier).WithType(stat2Type).WithQuality(Quality).Build();
        Stat3 = StatBuilder.CreateInstance(dropRate, efficiency, Tier).WithType(stat3Type).Build();
        ExtraStatList = CalculateRandomStats(dropRate, efficiency);
    }

    private ItemTier CalculateTier(int dropRate)
    {
        var itemTierCount = Enum.GetNames(typeof(ItemTier)).Length;
        return (ItemTier) PkRandom.SelectWithActivation(dropRate, itemTierCount);
    }

    private List<Stat> CalculateRandomStats(int dropRate, double efficiency)
    {
        var randomStatList = new List<Stat>
        {
            StatBuilder.CreateInstance(dropRate, efficiency, Tier).Build()
        };
        
        if (Quality > 0.5)
        {
            randomStatList.Add(StatBuilder.CreateInstance(dropRate, efficiency, Tier).Build());
        }
        if (Quality > 0.7)
        {
            randomStatList.Add(StatBuilder.CreateInstance(dropRate, efficiency, Tier).Build());
        }

        return randomStatList;
    }
}