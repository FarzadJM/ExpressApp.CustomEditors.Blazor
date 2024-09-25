using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.Blazor.CustomEditors.SfPdfViewer2;

namespace ExpressApp.Blazor.CustomEditors;

public class SfPdfViewer2Editor : BlazorPropertyEditorBase
{
    public SfPdfViewer2Editor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new SfPdfViewer2Adapter(new SfPdfViewer2Model());
    public override SfPdfViewer2Model? ComponentModel => (Control as SfPdfViewer2Adapter)?.ComponentModel;
}