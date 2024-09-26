using DevExpress.ExpressApp.Blazor.Components.Models;

namespace ExpressApp.CustomEditors.Blazor.PersianDatePicker;

internal class Notifier : IComponentModel
{
    private bool needRaiseChanged = true;

    public event EventHandler Changed;

    public Notifier()
    {
    }

    public Notifier(IComponentModel componentModel)
    {
        Subscribe(componentModel);
    }

    public void Subscribe(IComponentModel componentModel)
    {
        componentModel.Changed += ComponentModel_Changed;
    }

    public void Unsubscribe(IComponentModel componentModel)
    {
        componentModel.Changed -= ComponentModel_Changed;
    }

    private void ComponentModel_Changed(object sender, EventArgs e)
    {
        if (needRaiseChanged)
        {
            RaiseChanged();
        }
    }

    public void ExecuteNoiseless(Action action)
    {
        needRaiseChanged = false;
        try
        {
            action?.Invoke();
        }
        finally
        {
            needRaiseChanged = true;
        }
    }

    public void RaiseChanged()
    {
        this.Changed?.Invoke(this, EventArgs.Empty);
    }
}