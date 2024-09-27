using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.DxHtmlEditor;

public sealed class DxHtmlEditorAdapter : ComponentAdapterBase
{
    public DxHtmlEditorAdapter(DxHtmlEditorModel componentModel)
    {
        ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
        ComponentModel.MarkupChanged = EventCallback.Factory.Create<string>(this, (markup) =>
        {
            if (!EqualityComparer<string>.Default.Equals(componentModel.Markup, markup))
            {
                componentModel.Markup = markup;
                RaiseValueChanged();
            }
        });
    }

    public override DxHtmlEditorModel ComponentModel { get; }

    public override object GetValue()
    {
        return ComponentModel.Markup;
    }

    public override void SetAllowEdit(bool allowEdit)
    {
        ComponentModel.ReadOnly = !allowEdit;
    }

    public override void SetAllowNull(bool allowNull)
    {
    }

    public override void SetDisplayFormat(string displayFormat)
    {
    }

    public override void SetEditMask(string editMask)
    {
    }

    public override void SetEditMaskType(EditMaskType editMaskType)
    {
    }

    public override void SetErrorIcon(ImageInfo errorIcon)
    {
    }

    public override void SetErrorMessage(string errorMessage)
    {
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

    public override void SetValue(object value)
    {
        ComponentModel.Markup = (string)value ?? string.Empty;
    }

    protected override RenderFragment CreateComponent()
    {
        return ComponentModelObserver.Create(ComponentModel, DxHtmlEditorRenderer.Create(ComponentModel));
    }
}
