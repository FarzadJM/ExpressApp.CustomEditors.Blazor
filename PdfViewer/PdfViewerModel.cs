using DevExpress.ExpressApp.Blazor.Components.Models;

namespace ExpressApp.Blazor.CustomEditors.PdfViewer;

public class PdfViewerModel : DxComponentModelBase
{
    public byte[] DocumentContent
    {
        get => GetPropertyValue<byte[]>([], nameof(DocumentContent));
        set => SetPropertyValue(value, notify: true, nameof(DocumentContent));
    }
}
