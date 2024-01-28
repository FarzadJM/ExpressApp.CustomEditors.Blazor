using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using ExpressApp.Blazor.CustomEditors.PersianDatePicker;

namespace ExpressApp.Blazor.CustomEditors;

public class DateTimePropertyEditor : BlazorPropertyEditorBase
{
    public override bool CanFormatPropertyValue => true;

    public override DxDateEditModel ComponentModel => (base.Control as DxDateEditAdapter)?.ComponentModel;

    public DxDateTimeMaskPropertiesModel MaskProperties => (base.Control as DxDateEditAdapter)?.MaskProperties;

    public DateTimePropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
    {
    }

    protected override IComponentAdapter CreateComponentAdapter()
    {
        if (Model.Application is ModelApplicationBase modelApplicationBase && modelApplicationBase.CurrentAspectProvider.CurrentAspect == "fa-IR")
        {
            if (base.AllowNull)
            {
                return new PersianDatePicker.PersianDateEditAdapter<DateTime?>(new DxDateEditModel<DateTime?>());
            }

            return new PersianDatePicker.PersianDateEditAdapter<DateTime>(new DxDateEditModel<DateTime>());
        }

        if (base.AllowNull)
        {
            return new DxDateEditAdapter<DateTime?>(new DxDateEditModel<DateTime?>());
        }

        return new DxDateEditAdapter<DateTime>(new DxDateEditModel<DateTime>());
    }

    protected override void OnControlCreated()
    {
        if (base.Control is DxDateEditAdapter<DateTime> dxDateEditAdapter)
        {
            dxDateEditAdapter.ComponentModel.NullValue = default(DateTime);
        }
        else if (base.Control is PersianDateEditAdapter<DateTime> persianDateEditAdapter)
        {
            persianDateEditAdapter.ComponentModel.NullValue = default(DateTime);
        }

        base.OnControlCreated();
    }
}
