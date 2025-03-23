using DevExpress.Blazor;
using DevExpress.ExpressApp.Blazor.Components.Models;
using System.ComponentModel;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.DxProgressBar;

public class DxProgressBarModel : ComponentModelBase
{
    public bool Indeterminate
    {
        get => GetPropertyValue<bool>(false);
        set => SetPropertyValue(value);
    }

    public string Label
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }

    public ProgressBarLabelPosition LabelPosition
    {
        get => GetPropertyValue<ProgressBarLabelPosition>(ProgressBarLabelPosition.Bottom);
        set => SetPropertyValue(value);
    }

    public double MinValue
    {
        get => GetPropertyValue<double>(0);
        set => SetPropertyValue(value);
    }

    public double MaxValue
    {
        get => GetPropertyValue<double>(100);
        set => SetPropertyValue(value);
    }

    public bool ShowIcon
    {
        get => GetPropertyValue<bool>(false);
        set => SetPropertyValue(value);
    }

    public bool ShowLabel
    {
        get => GetPropertyValue<bool>(true);
        set => SetPropertyValue(value);
    }

    public string CssClass
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }

    public SizeMode? SizeMode
    {
        get => GetPropertyValue<SizeMode?>();
        set => SetPropertyValue(value);
    }

    public ProgressBarStatus Status
    {
        get => GetPropertyValue<ProgressBarStatus>(ProgressBarStatus.InProgress);
        set => SetPropertyValue(value);
    }

    public string Thickness
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }

    public ProgressBarType Type
    {
        get => GetPropertyValue<ProgressBarType>(ProgressBarType.Horizontal);
        set => SetPropertyValue(value);
    }

    public double Value
    {
        get => GetPropertyValue<double>(0);
        set => SetPropertyValue(value);
    }

    public bool Visible
    {
        get => GetPropertyValue<bool>(true);
        set => SetPropertyValue(value);
    }

    public override Type ComponentType => typeof(DevExpress.Blazor.DxProgressBar);
}
