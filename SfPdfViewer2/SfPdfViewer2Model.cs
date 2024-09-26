using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;

namespace ExpressApp.CustomEditors.Blazor.SfPdfViewer2;

public class SfPdfViewer2Model : DxComponentModelBase
{
    public byte[] DocumentContent
    {
        get => GetPropertyValue<byte[]>();
        set => SetPropertyValue(value);
    }

    public Dictionary<string, string> FormFields
    {
        get => GetPropertyValue<Dictionary<string, string>>();
        set => SetPropertyValue(value);
    }

    public string DownloadFileName
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }

    public string DocumentPath => DocumentContent is null ? string.Empty : "data:application/pdf;base64," + Convert.ToBase64String(DocumentContent);

    public EventCallback FormFieldChangedFromUI
    {
        get => GetPropertyValue(default(EventCallback), nameof(FormFieldChangedFromUI));
        set => SetPropertyValue(value, notify: true, nameof(FormFieldChangedFromUI));
    }

    public EventCallback FormFieldChangedFromDb
    {
        get => GetPropertyValue(default(EventCallback), nameof(FormFieldChangedFromDb));
        set => SetPropertyValue(value, notify: true, nameof(FormFieldChangedFromDb));
    }
}
