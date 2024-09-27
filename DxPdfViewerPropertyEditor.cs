using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.CustomEditors.Blazor.BaseImpl.DxPdfViewer;

namespace ExpressApp.CustomEditors.Blazor;

public class DxPdfViewerPropertyEditor: BlazorPropertyEditorBase
{
    public DxPdfViewerPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new DxPdfViewerAdapter(new DxPdfViewerModel());
    public override DxPdfViewerModel? ComponentModel => (Control as DxPdfViewerAdapter)?.ComponentModel;
}
