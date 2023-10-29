using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;
using ExpressApp.Blazor.CustomEditors.Adapters;

namespace ExpressApp.Blazor.CustomEditors;

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
                Rows = base.Model.RowCount
            });
        }

        return componentAdapter;
    }
}
