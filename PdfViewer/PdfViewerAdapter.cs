using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;

namespace ExpressApp.CustomEditors.Blazor.PdfViewer;

public class PdfViewerAdapter : ComponentAdapterBase
{
    public PdfViewerAdapter(PdfViewerModel componentModel)
    {
        ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
    }

    public override PdfViewerModel ComponentModel { get; }

    public override object GetValue()
    {
        return ComponentModel.DocumentContent;
    }

    public override void SetAllowEdit(bool allowEdit)
    {
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
    }

    public override void SetValue(object value)
    {
        ComponentModel.DocumentContent = ((byte[])value) ?? [];
    }

    protected override RenderFragment CreateComponent()
    {
        return ComponentModelObserver.Create(ComponentModel, PdfViewerRenderer.Create(ComponentModel));
    }
}
