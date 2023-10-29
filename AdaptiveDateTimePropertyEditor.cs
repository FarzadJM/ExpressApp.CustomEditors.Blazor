using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Blazor.Services;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Utils;
using DevExpress.Utils;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace ExpressApp.Blazor.CustomEditors;

public class AdaptiveDateTimePropertyEditor : StringPropertyEditor
{
    public AdaptiveDateTimePropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
    {
        if (model.Application is ModelApplicationBase modelApplicationBase)
        {
            if (modelApplicationBase.CurrentAspectProvider.CurrentAspect == "fa-IR")
            {
                EditMask = string.Empty;
                EditMaskType = EditMaskType.Default;
            }
        }
    }

    protected override IComponentAdapter CreateComponentAdapter()
    {
        if (Model.Application is ModelApplicationBase modelApplicationBase)
        {
            if (modelApplicationBase.CurrentAspectProvider.CurrentAspect == "fa-IR")
            {
                return new AutoDateTimeMaskedInputAdapter<string>(new DxMaskedInputModel<string>
                {
                    Id = Id
                });
            }
        }

        if (AllowNull)
        {
            return new DxDateEditAdapter<System.DateTime?>(new DxDateEditModel<System.DateTime?>());
        }

        return new DxDateEditAdapter<System.DateTime>(new DxDateEditModel<System.DateTime>());
    }

    protected override void OnControlCreated()
    {
        if (Model.Application is ModelApplicationBase modelApplicationBase)
        {
            if (modelApplicationBase.CurrentAspectProvider.CurrentAspect != "fa-IR")
            {
                DxDateEditAdapter<System.DateTime> dxDateEditAdapter = Control as DxDateEditAdapter<System.DateTime>;
                if (dxDateEditAdapter != null)
                {
                    dxDateEditAdapter.ComponentModel.NullValue = default;
                }
            }
        }

        base.OnControlCreated();
    }
}

public class AutoDateTimeMaskedInputAdapter<T> : DxMaskedInputAdapter<T>
{
    private object lastValidValue;

    public AutoDateTimeMaskedInputAdapter(DxMaskedInputModel<T> componentModel) : base(componentModel)
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
                SetValue(lastValidValue);
            }
        }

        return null;
    }

    public override void SetValue(object value)
    {
        if (value is System.DateTime dateTime)
        {
            lastValidValue = dateTime;

            var s = CultureInfo.CurrentCulture.GetDateSeparator();
            ComponentModel.Value = (T)(object)dateTime.ToString(@$"yyyy{s}M{s}d", CultureInfo.GetCultureInfo("fa"));
        }
        else if (value is null)
        {
            lastValidValue = value;

            ComponentModel.Value = (T)value;
        }
        else
        {
            ComponentModel.Value = (T)value;
        }
    }
}
