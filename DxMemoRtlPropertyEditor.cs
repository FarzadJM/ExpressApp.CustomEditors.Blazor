using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Model;

namespace ExpressApp.CustomEditors.Blazor;

public class DxMemoRtlPropertyEditor : StringPropertyEditor
{
    public DxMemoRtlPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
    {
    }

    protected override IComponentAdapter CreateComponentAdapter()
    {
        var componentAdapter = base.CreateComponentAdapter();

        if (componentAdapter is DxMemoAdapter)
        {
            return new BaseImpl.DxMemoRtl.DxMemoAdapter(new DxMemoModel
            {
                Rows = Model.RowCount
            });
        }

        return componentAdapter;
    }
}
