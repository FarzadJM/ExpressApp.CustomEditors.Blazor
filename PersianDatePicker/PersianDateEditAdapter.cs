using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Components.Models.Renderers;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace ExpressApp.Blazor.CustomEditors.PersianDatePicker;

public class PersianDateEditAdapter<T> : DxDateEditAdapter
{
    private Notifier notifier;

    private TooltipContainer _tooltip = new TooltipContainer();

    public override DxDateEditModel<T> ComponentModel { get; }

    protected XafValidationMessageContainerModel ValidationModel { get; }

    public PersianDateEditAdapter(DxDateEditModel<T> componentModel)
    {
        if (componentModel == null)
        {
            throw new ArgumentNullException("componentModel");
        }

        ComponentModel = componentModel;
        ComponentModel.SetAttribute("data-xaf-" + base.ConditionalAppearanceModel.Id, true);
        ComponentModel.DateChanged = EventCallback.Factory.Create((object)this, (Action<T>)ComponentModel_DateChanged);
        notifier = new Notifier(componentModel);
        notifier.Subscribe(base.MaskProperties);
        ComponentModel.MaskProperties = base.MaskProperties.GetComponentContent();
        ValidationModel = new XafValidationMessageContainerModel();
    }

    private void ComponentModel_DateChanged(T date)
    {
        ComponentModel.Date = date;
        RaiseValueChanged();
    }

    public override void SetTooltip(string tooltip)
    {
        _tooltip.SetTooltip(tooltip);
        ComponentModel.SetAttribute("title", _tooltip.ToString());
    }

    public override void SetAllowEdit(bool allowEdit)
    {
        ComponentModel.ReadOnly = !allowEdit;
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

    public override void SetEditMaskType(EditMaskType editMaskType)
    {
    }

    public override void SetErrorIcon(ImageInfo errorIcon)
    {
        ValidationModel.ValidationResultType = ComponentAdapterBase.GetValidationResultType(errorIcon);
        ComponentModel.CssClass = ComponentAdapterBase.GetValidationCssClass(ComponentModel.CssClass, errorIcon);
    }

    public override void SetErrorMessage(string errorMessage)
    {
        ValidationModel.Message = errorMessage;
        _tooltip.SetErrorMessage(errorMessage);
        ComponentModel.SetAttribute("title", _tooltip.ToString());
    }

    public override void SetIsPassword(bool isPassword)
    {
    }

    public override void SetMaxLength(int maxLength)
    {
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
