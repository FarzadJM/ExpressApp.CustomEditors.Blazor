using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;

namespace ExpressApp.Blazor.CustomEditors.Adapters;

public class DxMemoAdapterCustom : DxMemoAdapter
{
    public DxMemoAdapterCustom(DxMemoModel componentModel) : base(componentModel)
    {
    }

    public override object GetValue()
    {
        if (base.GetValue() is string value)
        {
            if (!string.IsNullOrWhiteSpace(value) && !value.StartsWith('‫'))
            {
                return $"‫{value}";
            }
            else if (value == "‫")
            {
                return string.Empty;
            }
        }

        return base.GetValue();
    }

    public override void SetValue(object value)
    {
        if (value is string valueStr)
        {
            if (!valueStr.StartsWith('‫'))
            {
                value = $"‫{valueStr}";
            }
        }

        base.SetValue(value);
    }
}
