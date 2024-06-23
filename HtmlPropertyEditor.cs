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
/// <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-3.6.2.min.js"></script>
/// <script src="https://cdnjs.cloudflare.com/ajax/libs/knockout/3.5.0/knockout-min.js"></script>
/// <script src="https://cdn3.devexpress.com/jslib/23.2.6/js/dx-quill.min.js"></script>
/// <script src="https://cdn3.devexpress.com/jslib/23.2.6/js/dx.all.js"></script>
/// 
/// https://docs.devexpress.com/eXpressAppFramework/404346/analytics/dashboards/dashboards-test-troubleshooting-guide?utm_source=SupportCenter&utm_medium=website&utm_campaign=docs-feedback&utm_content=T1053650#the-your-xaf-application-contains-the-dashboards-module-and-devextreme-widget-error-message-is-displayed
/// 
/// </summary>
public class HtmlPropertyEditor : BlazorPropertyEditorBase
{
    public HtmlPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    protected override IComponentAdapter CreateComponentAdapter() => new HtmlEditorAdapter(new HtmlEditorModel());
    public override HtmlEditorModel ComponentModel => (Control as HtmlEditorAdapter)?.ComponentModel;

}