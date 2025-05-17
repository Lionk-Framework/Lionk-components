namespace Lionk.Components.FlowMeter;

public enum FlowRateType
{
    SpeedMin,
    SpeedMax,
    SpeedAverage,
    FlowRateMin,
    FlowRateMax,
    FlowRateAverage,
}

public static class FlowRateTypeExtensions
{
    public static string ToString(this FlowRateType type)
    {
        return type switch
        {
            FlowRateType.SpeedMin => "Speed Min",
            FlowRateType.SpeedMax => "Speed Max",
            FlowRateType.SpeedAverage => "Speed Average",
            FlowRateType.FlowRateMin => "Flow Rate Min",
            FlowRateType.FlowRateMax => "Flow Rate Max",
            FlowRateType.FlowRateAverage => "Flow Rate Average",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    public static string GetUnit(this FlowRateType type)
    {
        return type switch
        {
            FlowRateType.SpeedMin => "m/s",
            FlowRateType.SpeedMax => "m/s",
            FlowRateType.SpeedAverage => "m/s",
            FlowRateType.FlowRateMin => "L/s",
            FlowRateType.FlowRateMax => "L/s",
            FlowRateType.FlowRateAverage => "L/s",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}