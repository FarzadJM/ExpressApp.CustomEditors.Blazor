using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.CustomEditors.Blazor.RtlMemo;

namespace ExpressApp.CustomEditors.Blazor;

public class RtlMemoPropertyEditor : StringPropertyEditor
{
    public RtlMemoPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
    {
    }

    protected override IComponentAdapter CreateComponentAdapter()
    {
        var componentAdapter = base.CreateComponentAdapter();

        if (componentAdapter is DxMemoAdapter)
        {
            return new DxMemoAdapterCustom(new DxMemoModel
            {
                Rows = Model.RowCount
            });
        }

        return componentAdapter;
    }
}
