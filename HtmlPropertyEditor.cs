using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.Blazor.CustomEditors.HtmlEditor;

namespace ExpressApp.Blazor.CustomEditors;

/// <summary>
/// Requirements:
/// 
/// services.AddServerSideBlazor().AddHubOptions(options => options.MaximumReceiveMessageSize = long.MaxValue);
/// 
/// </summary>
public class HtmlPropertyEditor : BlazorPropertyEditorBase
{
    public HtmlPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new HtmlEditorAdapter(new HtmlEditorModel());
    public override HtmlEditorModel ComponentModel => (Control as HtmlEditorAdapter)?.ComponentModel;
}
