using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;
using System.Diagnostics;
using System.Reflection;

namespace ExpressApp.Blazor.CustomEditors.Models;

public class SfPdfViewerComponentModel : ComponentModelBase
{
    private string id = Guid.NewGuid().ToString();

    public byte[] Value
    {
        get
        {
            //if (GetValueFromUI is not null)
            //{
            //    var newValue = GetValueFromUI.Invoke();
            //    var currentValue = GetPropertyValue<byte[]>();

            //    if (!currentValue.Equals(newValue))
            //    {
            //        SetPropertyValue(newValue, notify: false, nameof(Value));
            //        ValueChanged?.Invoke(this, EventArgs.Empty);
            //    }
            //}

            return GetPropertyValue<byte[]>();
        }
        set
        {
            if (!value.Equals(GetPropertyValue<byte[]>()))
            {
                SetPropertyValue(value);

                id = Guid.NewGuid().ToString();
            }
        }
    }

    public string DocumentPath
    {
        get
        {
            if (Value is not null && Value.Length > 0)
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "temps");
                var name = $"{id}.pdf";
                var fileName = Path.Combine(path, name);

                if (!File.Exists(fileName))
                {
                    Directory.CreateDirectory(path);
                    File.WriteAllBytes(fileName, Value);
                }

                //return "data:application/pdf;base64," + Convert.ToBase64String(Value);

                var a = Path.GetRelativePath(Directory.GetCurrentDirectory(), fileName);
                return a.Replace('\\', '/');
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public void SetValueFromUI(byte[] value)
    {
        if (!value.Equals(GetPropertyValue<byte[]>()))
        {
            SetPropertyValue(value);

            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    //public Func<byte[]>? GetValueFromUI { get; set; }

    public event EventHandler? ValueChanged;
}