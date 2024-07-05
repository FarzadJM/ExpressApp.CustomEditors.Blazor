using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using Microsoft.AspNetCore.Components;

namespace ExpressApp.Blazor.CustomEditors.PersianDatePicker;

public class PersianDateEditAdapter<T> : DxDateEditAdapter
{
    private Notifier notifier;

    public override DxDateEditModel<T> ComponentModel { get; }

    protected override IComponentModel ObservableModel => notifier;

    public PersianDateEditAdapter(DxDateEditModel<T> componentModel)
    {
        if (componentModel == null)
        {
            throw new ArgumentNullException("componentModel");
        }

        ComponentModel = componentModel;
        ComponentModel.DateChanged = EventCallback.Factory.Create((object)this, (Action<T>)ComponentModel_DateChanged);
        notifier = new Notifier(componentModel);
        notifier.Subscribe(base.MaskProperties);
        ComponentModel.MaskProperties = base.MaskProperties.GetComponentContent();
    }

    private void ComponentModel_DateChanged(T date)
    {
        ComponentModel.Date = date;
        RaiseValueChanged();
    }

    public override void SetAllowEdit(bool allowEdit)
    {
        base.SetAllowEdit(allowEdit);
        ComponentModel.Enabled = allowEdit;
    }

    public override void SetAllowNull(bool allowNull)
    {
        ComponentModel.ClearButtonDisplayMode = BlazorCastHelper.GetEditorClearButtonDisplayMode(allowNull);
    }

    public override void SetDisplayFormat(string displayFormat)
    {
        ComponentModel.DisplayFormat = displayFormat;
    }

    public override void SetEditMask(string editMask)
    {
        ComponentModel.Format = editMask;
    }

    public override void SetNullText(string nullText)
    {
        ComponentModel.NullText = nullText;
    }

    public override object GetValue()
    {
        return ComponentModel.Date;
    }

    public override void SetValue(object value)
    {
        ComponentModel.Date = ((value == null) ? default(T) : ((T)value));
    }

    protected override RenderFragment CreateComponent()
    {
        //return ComponentModelObserver.Create(ComponentModel, PersianDateEditRenderer<T>.Create(ComponentModel));
        return ComponentModelObserver.Create(notifier, ComponentModelObserver.Create(base.ConditionalAppearanceModel, ConditionalAppearanceContainer.Create(base.ConditionalAppearanceModel, GetConditionalAppearanceSelector(), XafValidationMessageContainer.Create(ValidationModel, PersianDateEditRenderer<T>.Create(ComponentModel)))));
    }
}
