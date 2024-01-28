using DevExpress.ExpressApp.Blazor.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressApp.Blazor.CustomEditors.NativePdfViewer;

public class PdfComponentModel : ComponentModelBase
{
    public byte[] Value
    {
        get => GetPropertyValue<byte[]>();
        set => SetPropertyValue(value);
    }
}