using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using ExpressApp.Blazor.CustomEditors.Models;
using ExpressApp.Blazor.CustomEditors.Renderers;
using Microsoft.AspNetCore.Components;
using System;

namespace ExpressApp.Blazor.CustomEditors.Adapters;

public class SfPdfViewerComponentAdapter : ComponentAdapterBase
{
    public SfPdfViewerComponentAdapter(SfPdfViewerComponentModel componentModel)
    {
        ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
        ComponentModel.ValueChanged += ComponentModel_ValueChanged;
    }

    private void ComponentModel_ValueChanged(object sender, EventArgs e) => RaiseValueChanged();

    public SfPdfViewerComponentModel ComponentModel { get; }

    public override object GetValue()
    {
        return ComponentModel.Value;
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
        ComponentModel.Value = (byte[])value ?? Array.Empty<byte>();
    }

    protected override RenderFragment CreateComponent()
    {
        return ComponentModelObserver.Create(ComponentModel, SfPdfViewerComponentRenderer.Create(ComponentModel));
    }
}