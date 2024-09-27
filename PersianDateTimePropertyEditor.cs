using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.CustomEditors.Blazor.BaseImpl.PersianDatePicker;

namespace ExpressApp.CustomEditors.Blazor;

public class PersianDateTimePropertyEditor : BlazorPropertyEditorBase
{
    public override bool CanFormatPropertyValue => true;

    public override DxDateEditModel? ComponentModel => (Control as DxDateEditAdapter)?.ComponentModel;

    public DxDateTimeMaskPropertiesModel? MaskProperties => (Control as DxDateEditAdapter)?.MaskProperties;

    public PersianDateTimePropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
    {
    }

    protected override IComponentAdapter CreateComponentAdapter()
    {
        if (AllowNull)
        {
            return new PersianDateEditAdapter<DateTime?>(new DxDateEditModel<DateTime?>());
        }

        return new PersianDateEditAdapter<DateTime>(new DxDateEditModel<DateTime>());
    }

    protected override void OnControlCreated()
    {
        if (Control is PersianDateEditAdapter<DateTime> persianDateEditAdapter)
        {
            persianDateEditAdapter.ComponentModel.NullValue = default;
        }

        base.OnControlCreated();
    }
}