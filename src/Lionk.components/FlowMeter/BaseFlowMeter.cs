// Copyright © 2024 Lionk Project

using Lionk.Core;
using Lionk.Core.Component;
using Lionk.Core.DataModel;
using Newtonsoft.Json;

namespace Lionk.Components.FlowMeter;

/// <summary>
/// This class is used to represent a flow meter.
/// </summary>
[NamedElement("Flow Meter", "This component is used to represent a flow meter")]
public abstract class BaseFlowMeter : BaseComponent, IMeasurableComponent<double>
{

    /// <summary>
    /// Event raised when a new value is available.
    /// </summary>
    public event EventHandler<MeasureEventArgs<double>>? NewValueAvailable;

    public string? Unit { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public double CurrentValue { get; set; } = 0;

    /// <summary>
    /// Gets or sets the initial value.
    /// </summary>
    public double InitialValue { get; set; } = 0;

    /// <summary>
    /// Method to get the value.
    /// </summary>
    /// <returns> The value. </returns>
    public double GetValue(int nbDecimal = 2) => Math.Round(InitialValue + CurrentValue, nbDecimal);

    /// <summary>
    /// Method to get the value as a string.
    /// </summary>
    /// <returns> The value as a string. </returns>
    public string GetValueString() => GetValue() + Unit;

    /// <summary>
    /// Gets or sets the measures of the component.
    /// </summary>
    public virtual List<Measure<double>> Measures { get; set; } = new()
    {
        new Measure<double>(FlowRateType.SpeedMin.ToString(), DateTime.UtcNow, FlowRateType.SpeedMin.GetUnit(), double.NaN),
        new Measure<double>(FlowRateType.SpeedMax.ToString(), DateTime.UtcNow, FlowRateType.SpeedMax.GetUnit(), double.NaN),
        new Measure<double>(FlowRateType.SpeedAverage.ToString(), DateTime.UtcNow, FlowRateType.SpeedAverage.GetUnit(), double.NaN),
        new Measure<double>(FlowRateType.FlowMin.ToString(), DateTime.UtcNow, FlowRateType.FlowMin.GetUnit(), double.NaN),
        new Measure<double>(FlowRateType.FlowMax.ToString(), DateTime.UtcNow, FlowRateType.FlowMax.GetUnit(), double.NaN),
        new Measure<double>(FlowRateType.FlowAvg.ToString(), DateTime.UtcNow, FlowRateType.FlowAvg.GetUnit(), double.NaN),
        new Measure<double>(FlowRateType.Consumption.ToString(), DateTime.UtcNow, FlowRateType.Consumption.GetUnit(), double.NaN)
    };

    /// <summary>
    /// Method to get the value.
    /// </summary>
    public virtual void Measure()
    {
        var measureEventArgs = new MeasureEventArgs<double>(Measures);
        NewValueAvailable?.Invoke(this,measureEventArgs);
    }

    /// <inheritdoc/>
    public TimeSpan HistoryDuration { get; set; } = TimeSpan.FromDays(30);
}