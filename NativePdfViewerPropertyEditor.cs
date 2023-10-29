using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.Blazor.CustomEditors.Adapters;
using ExpressApp.Blazor.CustomEditors.Models;

namespace ExpressApp.Blazor.CustomEditors;

public class NativePdfViewerPropertyEditor : BlazorPropertyEditorBase
{
    public NativePdfViewerPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new PdfComponentAdapter(new PdfComponentModel());
}