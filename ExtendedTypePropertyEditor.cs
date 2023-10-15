using DevExpress.Blazor;
using DevExpress.Data.Internal;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Utils.Reflection;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace ExpressApp.Blazor.CustomEditors
{
    public class ExtendedTypePropertyEditor : TypePropertyEditor
    {
        private readonly TypeConverter typeConverter;

        public ExtendedTypePropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
            typeConverter = new CustomLocalizedClassInfoTypeConverter();
        }

        protected override IComponentAdapter CreateComponentAdapter()
        {
            DxComboBoxModel<DataItem<Type>, Type> dxComboBoxModel = new DxComboBoxModel<DataItem<Type>, Type>();
            List<DataItem<Type>> list = new List<DataItem<Type>>();
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
            return new DxComboBoxAdapter<DataItem<Type>, Type>(dxComboBoxModel);
        }
    }
    public class CustomLocalizedClassInfoTypeConverter : LocalizedClassInfoTypeConverter
    {
        protected override string GetClassCaption(string fullName)
        {
            return $"{base.GetClassCaption(fullName)} ({fullName})";
        }
    }
}
