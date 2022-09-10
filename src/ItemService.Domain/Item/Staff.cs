using ItemService.Common.Enums;

namespace ItemService.Domain.Item;

public class Staff: ItemBase
{
    public Staff(int dropRate) 
        : base(dropRate, "StaffName", ItemType.Staff, 1,StatType.MinDamage, StatType.MaxDamage, StatType.Intelligent)
    {
    }
}