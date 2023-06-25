using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;

namespace ExpressApp.Blazor.Server.Editors.PdfPropertyEditor;

public class PropertyEditor : BlazorPropertyEditorBase
{
    public PropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new ComponentAdapter(new ComponentModel());
}