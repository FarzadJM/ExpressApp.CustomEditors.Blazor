using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.CustomEditors.Blazor.PdfViewer;

namespace ExpressApp.CustomEditors.Blazor;

public class PdfViewerEditor: BlazorPropertyEditorBase
{
    public PdfViewerEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new PdfViewerAdapter(new PdfViewerModel());
    public override PdfViewerModel? ComponentModel => (Control as PdfViewerAdapter)?.ComponentModel;
}
