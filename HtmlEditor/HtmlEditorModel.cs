using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ExpressApp.Blazor.CustomEditors.HtmlEditor;

public sealed class HtmlEditorModel : ComponentModelBase
{
    public EventCallback<string> ValueChanged
    {
        get => GetPropertyValue<EventCallback<string>>();
        set => SetPropertyValue(value);
    }

    public event EventHandler? RefreshRequested;
    public event EventHandler<bool> AllowEditValueChanged;

    public string Value
    {
        get => GetPropertyValue<string>();
        set
        {
            if (SetPropertyValue(value))
            {
                RefreshRequested?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public bool SetValueFromUi(string value)
    {
        return SetPropertyValue(value, propertyName: nameof(Value));
    }

    public bool AllowEdit
    {
        get => GetPropertyValue<bool>();
        set
        {
            if (SetPropertyValue(value))
            {
                AllowEditValueChanged?.Invoke(this, value);
            }
        }
    }
}
