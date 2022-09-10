using ItemService.Common.Enums;

namespace ItemService.Infrastructure.Models;

public class StatDto
{
    public double Value { get; }
    public double Quality { get; }
    public StatType Type { get; }
    public string TypeName => Type.ToString();
    
    public StatDto(StatType type, double quality, double value)
    {
        Type = type;
        Quality = quality;
        Value = value;
    }
}