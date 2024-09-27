using DevExpress.ExpressApp.Blazor.Components.Models;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.DxMemoRtl;

public class DxMemoAdapter : DevExpress.ExpressApp.Blazor.Editors.Adapters.DxMemoAdapter
{
    public DxMemoAdapter(DxMemoModel componentModel) : base(componentModel)
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
        else value ??= "‫";

        base.SetValue(value);
    }
}
