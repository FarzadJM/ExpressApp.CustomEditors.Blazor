using DevExpress.ExpressApp.Blazor.Components.Models;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.DxPdfViewer;

public class DxPdfViewerModel : DxComponentModelBase
{
    public byte[] DocumentContent
    {
        get => GetPropertyValue<byte[]>();
        set => SetPropertyValue(value);
    }

    public bool AllowDownload
    {
        get => GetPropertyValue<bool>();
        set => SetPropertyValue(value);
    }

    public bool AllowPrint
    {
        get => GetPropertyValue<bool>();
        set => SetPropertyValue(value);
    }
}
