using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.Blazor.Server.CustomEditors.Adapters;
using ExpressApp.Blazor.Server.CustomEditors.Models;

namespace ExpressApp.Blazor.Server.CustomEditors;

public class PdfPropertyEditor : BlazorPropertyEditorBase
{
    public PdfPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new PdfComponentAdapter(new PdfComponentModel());
}