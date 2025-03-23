using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using Microsoft.AspNetCore.Components;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.PersianDatePicker;

public class PersianDateEditAdapter<T> : DxDateEditAdapter
{
    private Notifier notifier;

    public override DxDateEditModel<T> ComponentModel { get; }

    protected override IComponentModel ObservableModel => notifier;

    public PersianDateEditAdapter(DxDateEditModel<T> componentModel)
    {
        ArgumentNullException.ThrowIfNull(componentModel, "componentModel");
        ComponentModel = componentModel;
        ComponentModel.DateChanged = EventCallback.Factory.Create((object)this, (Action<T>)ComponentModel_DateChanged);
        Type type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        Type type2 = type;
        if ((object)type2 == null)
        {
            goto IL_00a1;
        }

        ComponentModelBase componentModelBase;
        if (type2 == typeof(DateOnly))
        {
            componentModelBase = base.DxDateEditMaskProperties.DateOnly;
        }
        else
        {
            Type type3 = type2;
            if (!(type3 == typeof(DateTime)))
            {
                goto IL_00a1;
            }

            componentModelBase = base.DxDateEditMaskProperties.DateTime;
        }

        goto IL_00ae;
    IL_00ae:
        ComponentModelBase componentModelBase2 = componentModelBase;
        notifier = new Notifier(componentModel);
        notifier.Subscribe(componentModelBase2);
        ComponentModel.MaskProperties = componentModelBase2.GetComponentContent();
        return;
    IL_00a1:
        componentModelBase = base.DxDateEditMaskProperties.DateTime;
        goto IL_00ae;
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
        return ComponentModelObserver.Create(notifier, ComponentModelObserver.Create(ConditionalAppearanceModel, ConditionalAppearanceContainer.Create(ConditionalAppearanceModel, GetConditionalAppearanceSelector(), XafValidationMessageContainer.Create(ValidationModel, PersianDateEditRenderer<T>.Create(ComponentModel)))));
    }
}
