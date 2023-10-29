using DevExpress.Data.Mask.Internal;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Utils;
using System;
using System.Globalization;

namespace ExpressApp.Blazor.CustomEditors;

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
    private object lastValidValue;

    public PerisanDateTimeMaskedInputAdapter(DxMaskedInputModel<T> componentModel) : base(componentModel)
    {

    }

    public override object GetValue()
    {
        if (ComponentModel.Value is string value)
        {
            if (System.DateTime.TryParse(value, CultureInfo.GetCultureInfo("fa"), DateTimeStyles.AssumeLocal, out System.DateTime dateTime))
            {
                return dateTime;
            }
            else
            {
                return lastValidValue;
            }
        }

        return new PersianCalendar().MinSupportedDateTime;
    }

    public override void SetValue(object value)
    {
        if (value is System.DateTime dateTime)
        {
            lastValidValue = dateTime;
            var s = CultureInfo.CurrentCulture.GetDateSeparator();

            try
            {
                ComponentModel.Value = (T)(object)dateTime.ToString(@$"yyyy{s}M{s}d", CultureInfo.GetCultureInfo("fa"));
            }
            catch (Exception)
            {
                ComponentModel.Value = (T)(object)string.Empty;
            }
        }
    }

    private DateTime? GetDate(string input)
    {
        if (DateTime.TryParse(input, CultureInfo.GetCultureInfo("fa"), DateTimeStyles.AssumeLocal, out DateTime dateTime))
            return dateTime;
        else return null;
    }
}
