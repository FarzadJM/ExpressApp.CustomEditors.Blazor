using DevExpress.ExpressApp.Blazor.Components.Models;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.NativePdfViewer;

public class PdfComponentModel : ComponentModelBase
{
    public byte[] Value
    {
        get => GetPropertyValue<byte[]>();
        set => SetPropertyValue(value);
    }
}