using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.CustomEditors.Blazor.BaseImpl.SfPdfViewer2;

namespace ExpressApp.CustomEditors.Blazor;

public class SfPdfViewer2PropertyEditor : BlazorPropertyEditorBase
{
    public SfPdfViewer2PropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new SfPdfViewer2Adapter(new SfPdfViewer2Model());
    public override SfPdfViewer2Model? ComponentModel => (Control as SfPdfViewer2Adapter)?.ComponentModel;
}