using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;

namespace XAF_PDF_PropertyEditor;

public class PDFPropertyEditor : BlazorPropertyEditorBase
{
    public PDFPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new PDFAdapter(new PDFModel());
}