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
public abstract class BaseFlowMeter : BaseComponent, IMeasurableComponent<float>
{

    /// <summary>
    /// Event raised when a new value is available.
    /// </summary>
    public event EventHandler<MeasureEventArgs<float>>? NewValueAvailable;

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
    public virtual List<Measure<float>> Measures { get; set; } = new()
    {
        new Measure<float>(FlowRateType.SpeedMin.ToString(), DateTime.UtcNow, FlowRateType.SpeedMin.GetUnit(), float.NaN),
        new Measure<float>(FlowRateType.SpeedMax.ToString(), DateTime.UtcNow, FlowRateType.SpeedMax.GetUnit(), float.NaN),
        new Measure<float>(FlowRateType.SpeedAverage.ToString(), DateTime.UtcNow, FlowRateType.SpeedAverage.GetUnit(), float.NaN),
        new Measure<float>(FlowRateType.FlowRateMin.ToString(), DateTime.UtcNow, FlowRateType.FlowRateMin.GetUnit(), float.NaN),
        new Measure<float>(FlowRateType.FlowRateMax.ToString(), DateTime.UtcNow, FlowRateType.FlowRateMax.GetUnit(), float.NaN),
        new Measure<float>(FlowRateType.FlowRateAverage.ToString(), DateTime.UtcNow, FlowRateType.FlowRateAverage.GetUnit(), float.NaN)

    };

    /// <summary>
    /// Method to get the value.
    /// </summary>
    public virtual void Measure()
    {
        var measureEventArgs = new MeasureEventArgs<float>(Measures);
        NewValueAvailable?.Invoke(this,measureEventArgs);
    }

}