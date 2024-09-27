using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using ExpressApp.CustomEditors.Base;
using Microsoft.AspNetCore.Components;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.SfPdfViewer2;

public class SfPdfViewer2Adapter : ComponentAdapterBase
{
    private ISfPdfViewer2Obj? iSfPdfViewer2Obj;

    public SfPdfViewer2Adapter(SfPdfViewer2Model componentModel)
    {
        ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
        ComponentModel.FormFieldChangedFromUI = EventCallback.Factory.Create(this, () =>
        {
            iSfPdfViewer2Obj!.FormFields = ComponentModel.FormFields;
            RaiseValueChanged();
        });
    }

    public override SfPdfViewer2Model ComponentModel { get; }

    public override ISfPdfViewer2Obj GetValue()
    {
        return iSfPdfViewer2Obj!;
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
    }

    public override async void SetValue(object iSfPdfViewer2Obj)
    {
        this.iSfPdfViewer2Obj = (ISfPdfViewer2Obj)iSfPdfViewer2Obj;
        ComponentModel.DocumentContent = this.iSfPdfViewer2Obj.DocumentContent;
        ComponentModel.DownloadFileName = this.iSfPdfViewer2Obj.DownloadFileName;
        ComponentModel.FormFields = this.iSfPdfViewer2Obj.FormFields.Select(x => new KeyValuePair<string, string>(x.Key, x.Value ?? string.Empty)).ToDictionary();
        await ComponentModel.FormFieldChangedFromDb.InvokeAsync();
    }

    protected override RenderFragment CreateComponent()
    {
        return ComponentModelObserver.Create(ComponentModel, SfPdfViewer2Renderer.Create(ComponentModel));
    }
}
