using DevExpress.ExpressApp.Blazor.Components.Models;
using ExpressApp.CustomEditors.Blazor.BaseImpl.StepProgressBar;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.StepProgress;

public class StepProgressBarModel : ComponentModelBase
{
    public int Value
    {
        get => GetPropertyValue<int>(0);
        set => SetPropertyValue(value);
    }

    public List<string> Steps
    {
        get => GetPropertyValue<List<string>>([]);
        set => SetPropertyValue(value);
    }

    public override Type ComponentType => typeof(StepProgressBarRenderer);
}
