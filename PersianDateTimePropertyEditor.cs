using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Utils;
using System;
using System.Globalization;

namespace ExpressApp.Blazor.Server.CustomEditors;

public class PersianDateTimePropertyEditor : StringPropertyEditor
{
    public PersianDateTimePropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
    {
        EditMask = string.Empty;
        EditMaskType = EditMaskType.Default;
        DisplayFormat = string.Empty;
    }

    protected override IComponentAdapter CreateComponentAdapter()
    {
        return new PerisanDateTimeMaskedInputAdapter<string>(new DxMaskedInputModel<string>
        {
            Id = Id
        });
    }
}

public class PerisanDateTimeMaskedInputAdapter<T> : DxMaskedInputAdapter<T>
{
    private DateTime? lastValidValue;

    public PerisanDateTimeMaskedInputAdapter(DxMaskedInputModel<T> componentModel) : base(componentModel)
    {

    }

    public override object GetValue()
    {
        if (ComponentModel.Value is string value)
        {
            if (GetDate(value).HasValue)
            {
                return value;
            }
            else
            {
                var s = CultureInfo.CurrentCulture.GetDateSeparator();

                if (lastValidValue.HasValue)
                {
                    SetValue(lastValidValue.Value.AddDays(1).ToString(@$"yyyy{s}M{s}d", CultureInfo.GetCultureInfo("fa")));
                }
                else
                {
                    SetValue(DateTime.Now.ToString(@$"yyyy{s}M{s}d", CultureInfo.GetCultureInfo("fa")));
                }
            }
        }

        return null;
    }

    public override void SetValue(object value)
    {
        if (value is string valueStr)
        {
            var datetime = GetDate(valueStr);

            if (datetime.HasValue)
            {
                lastValidValue = datetime.Value;
            }

            ComponentModel.Value = (T)value;
        }
    }

    private DateTime? GetDate(string input)
    {
        if (DateTime.TryParse(input, CultureInfo.GetCultureInfo("fa"), DateTimeStyles.AssumeLocal, out DateTime dateTime))
            return dateTime;
        else return null;
    }
}
