using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.CustomEditors.Blazor.BaseImpl.NativePdfViewer;

namespace ExpressApp.CustomEditors.Blazor;

public class NativePdfViewerPropertyEditor : BlazorPropertyEditorBase
{
    public NativePdfViewerPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new PdfComponentAdapter(new PdfComponentModel());
}
