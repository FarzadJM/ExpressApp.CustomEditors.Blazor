using DevExpress.ExpressApp.Blazor.Components.Models;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.DxPdfViewer;

public class DxPdfViewerModel : DxComponentModelBase
{
    public byte[] DocumentContent
    {
        get => GetPropertyValue<byte[]>();
        set => SetPropertyValue(value);
    }
}
