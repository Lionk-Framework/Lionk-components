namespace Lionk.Components.FlowMeter;

public enum FlowRateType
{
    SpeedMin,
    SpeedMax,
    SpeedAverage,
    FlowMin,
    FlowMax,
    FlowAvg,
    Consumption
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
            FlowRateType.FlowMin => "Flow Rate Min",
            FlowRateType.FlowMax => "Flow Rate Max",
            FlowRateType.FlowAvg => "Flow Rate Average",
            FlowRateType.Consumption => "Consumption",
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
            FlowRateType.FlowMin => "L/m",
            FlowRateType.FlowMax => "L/m",
            FlowRateType.FlowAvg => "L/m",
            FlowRateType.Consumption => "m3",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}