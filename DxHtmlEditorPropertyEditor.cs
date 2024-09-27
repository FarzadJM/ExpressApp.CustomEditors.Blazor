using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.CustomEditors.Blazor.BaseImpl.DxHtmlEditor;

namespace ExpressApp.CustomEditors.Blazor;

/// <summary>
/// Requirements:
/// 
/// services.AddServerSideBlazor().AddHubOptions(options => options.MaximumReceiveMessageSize = long.MaxValue);
/// 
/// </summary>
public class DxHtmlEditorPropertyEditor : BlazorPropertyEditorBase
{
    public DxHtmlEditorPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new DxHtmlEditorAdapter(new DxHtmlEditorModel());
    public override DxHtmlEditorModel? ComponentModel => (Control as DxHtmlEditorAdapter)?.ComponentModel;
}
