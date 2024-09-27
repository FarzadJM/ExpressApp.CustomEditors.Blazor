using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.DxHtmlEditor;

public sealed class DxHtmlEditorModel : DxComponentModelBase
{
    public string Markup
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }

    public EventCallback<string> MarkupChanged
    {
        get => GetPropertyValue<EventCallback<string>>();
        set => SetPropertyValue(value);
    }

    public string NullText
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }
}
