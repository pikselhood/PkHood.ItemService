using ItemService.Common.Enums;

namespace ItemService.Domain.Item;

public class Stat
{
    public double Value { get; }
    public double Quality { get; }
    public StatType Type { get; }
    public string TypeName => Type.ToString();
    
    public Stat(StatType type, double quality, double value)
    {
        Type = type;
        Quality = quality;
        Value = value;
    }
}