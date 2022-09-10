using ItemService.Common.Enums;
using ItemService.Infrastructure.Mongo;

namespace ItemService.Infrastructure.Models;

public class ItemBaseDto : SoftDeleteDocument
{ 
    public ItemType Type { get; set; }
    public string Name { get; set; }
    public ItemTier Tier { get; set; }
    public int Upgrade { get; set; }
    public double Quality { get; set; }
    public StatDto Stat1 { get; set; }
    public StatDto Stat2 { get; set; }
    public StatDto Stat3 { get; set; }
    public List<StatDto> ExtraStatList { get; }
}