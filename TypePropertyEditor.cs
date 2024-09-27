using DevExpress.Blazor;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace ExpressApp.CustomEditors.Blazor;

public class TypePropertyEditor : DevExpress.ExpressApp.Blazor.Editors.TypePropertyEditor
{
    private readonly TypeConverter typeConverter;

    public TypePropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
    {
        typeConverter = new CustomLocalizedClassInfoTypeConverter();
    }

    protected override DevExpress.ExpressApp.Blazor.Editors.Adapters.IComponentAdapter CreateComponentAdapter()
    {
        var dxComboBoxModel = new DxComboBoxModel<DataItem<Type>, Type>();
        var list = new List<DataItem<Type>>();
        foreach (Type item in typeConverter.GetStandardValues()!)
        {
            if (IsSuitableType(item))
            {
                list.Add(new DataItem<Type>(item, typeConverter.ConvertToString(item)));
            }
        }

        dxComboBoxModel.Data = list;
        dxComboBoxModel.ValueFieldName = "Value";
        dxComboBoxModel.TextFieldName = "Text";
        dxComboBoxModel.FilteringMode = DataGridFilteringMode.Contains;
        return new DevExpress.ExpressApp.Blazor.Editors.Adapters.DxComboBoxAdapter<DataItem<Type>, Type>(dxComboBoxModel);
    }
}

public class CustomLocalizedClassInfoTypeConverter : LocalizedClassInfoTypeConverter
{
    protected override string GetClassCaption(string fullName)
    {
        return $"{base.GetClassCaption(fullName)} ({fullName})";
    }
}
