using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace ExpressApp.Blazor.CustomEditors.HtmlEditor;

public sealed class HtmlEditorModel : DxComponentModelBase, IHandleValueComponentModel
{
    private event EventHandler<HandleValueEventArgs> valueChanged;

    public HtmlEditorModel()
    {
        MarkupChanged = EventCallback.Factory.Create(this, delegate (string value)
        {
            this.valueChanged?.Invoke(this, new HandleValueEventArgs(value));
        });
    }

    public bool SetPropertyValue<T>(T newValue, string propertyName) => SetPropertyValue(newValue, notify: true, propertyName);

    public string Markup
    {
        get
        {
            return GetPropertyValue(string.Empty, nameof(Markup));
        }
        set
        {
            SetPropertyValue(value, notify: true, nameof(Markup));
        }
    }

    public EventCallback<string> MarkupChanged
    {
        get
        {
            return GetPropertyValue(default(EventCallback<string>), nameof(MarkupChanged));
        }
        set
        {
            SetPropertyValue(value, notify: true, nameof(MarkupChanged));
        }
    }

    public string NullText
    {
        get
        {
            return GetPropertyValue(string.Empty, nameof(NullText));
        }
        set
        {
            SetPropertyValue(value, notify: true, nameof(NullText));
        }
    }

    public bool Enabled
    {
        get
        {
            return GetPropertyValue(defaultValue: true, nameof(Enabled));
        }
        set
        {
            SetPropertyValue(value, notify: true, nameof(Enabled));
        }
    }

    object IHandleValueComponentModel.Value
    {
        get
        {
            return Markup;
        }
        set
        {
            Markup = ((string)value) ?? string.Empty;
        }
    }

    event EventHandler<HandleValueEventArgs> IHandleValueComponentModel.ValueChanged
    {
        add
        {
            valueChanged += value;
        }
        remove
        {
            valueChanged -= value;
        }
    }
}
