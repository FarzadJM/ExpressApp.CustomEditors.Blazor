using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;

namespace ExpressApp.Blazor.CustomEditors.HtmlEditor;

public sealed class HtmlEditorAdapter : ComponentAdapterBase
{
    public HtmlEditorAdapter(HtmlEditorModel componentModel)
    {
        ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
        ComponentModel.ValueChanged = EventCallback.Factory.Create<string>(this, value =>
        {
            if (componentModel.SetValueFromUi(value))
            {
                RaiseValueChanged();
            }
        });
    }

    public override HtmlEditorModel ComponentModel { get; }

    public override object GetValue()
    {
        return ComponentModel.Value;
    }

    public override void SetAllowEdit(bool allowEdit)
    {
        ComponentModel.AllowEdit = allowEdit;
    }

    public override void SetAllowNull(bool allowNull)
    {
        //throw new NotImplementedException();
    }

    public override void SetDisplayFormat(string displayFormat)
    {
        //throw new NotImplementedException();
    }

    public override void SetEditMask(string editMask)
    {
        //throw new NotImplementedException();
    }

    public override void SetEditMaskType(EditMaskType editMaskType)
    {
        //throw new NotImplementedException();
    }

    public override void SetErrorIcon(ImageInfo errorIcon)
    {
        //throw new NotImplementedException();
    }

    public override void SetErrorMessage(string errorMessage)
    {
        //throw new NotImplementedException();
    }

    public override void SetIsPassword(bool isPassword)
    {
        //throw new NotImplementedException();
    }

    public override void SetMaxLength(int maxLength)
    {
        //throw new NotImplementedException();
    }

    public override void SetNullText(string nullText)
    {
        //throw new NotImplementedException();
    }

    public override void SetValue(object value)
    {
        ComponentModel.Value = (string)value;
    }

    protected override RenderFragment CreateComponent()
    {
        return ComponentModelObserver.Create(ComponentModel, HtmlEditorRenderer.Create(ComponentModel));
    }
}
