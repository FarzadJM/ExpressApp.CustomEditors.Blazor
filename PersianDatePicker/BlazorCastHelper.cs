using DevExpress.Blazor;
using DevExpress.Data;

namespace ExpressApp.CustomEditors.Blazor.PersianDatePicker;

public static class BlazorCastHelper
{
    public static DataEditorClearButtonDisplayMode GetEditorClearButtonDisplayMode(bool allowClear)
    {
        if (!allowClear)
        {
            return DataEditorClearButtonDisplayMode.Never;
        }

        return DataEditorClearButtonDisplayMode.Auto;
    }

    public static DataGridColumnSortOrder Cast(ColumnSortOrder val)
    {
        return (DataGridColumnSortOrder)Enum.Parse(typeof(DataGridColumnSortOrder), val.ToString());
    }

    public static ColumnSortOrder Cast(DataGridColumnSortOrder val)
    {
        return (ColumnSortOrder)Enum.Parse(typeof(ColumnSortOrder), val.ToString());
    }

    public static DevExpress.Data.SummaryItemType Cast(DevExpress.Blazor.SummaryItemType summaryItemType)
    {
        return summaryItemType switch
        {
            DevExpress.Blazor.SummaryItemType.None => DevExpress.Data.SummaryItemType.None,
            DevExpress.Blazor.SummaryItemType.Sum => DevExpress.Data.SummaryItemType.Sum,
            DevExpress.Blazor.SummaryItemType.Min => DevExpress.Data.SummaryItemType.Min,
            DevExpress.Blazor.SummaryItemType.Max => DevExpress.Data.SummaryItemType.Max,
            DevExpress.Blazor.SummaryItemType.Avg => DevExpress.Data.SummaryItemType.Average,
            DevExpress.Blazor.SummaryItemType.Count => DevExpress.Data.SummaryItemType.Count,
            _ => DevExpress.Data.SummaryItemType.None,
        };
    }

    public static DevExpress.Blazor.SummaryItemType Cast(DevExpress.Data.SummaryItemType summaryItemType)
    {
        return summaryItemType switch
        {
            DevExpress.Data.SummaryItemType.None => DevExpress.Blazor.SummaryItemType.None,
            DevExpress.Data.SummaryItemType.Sum => DevExpress.Blazor.SummaryItemType.Sum,
            DevExpress.Data.SummaryItemType.Min => DevExpress.Blazor.SummaryItemType.Min,
            DevExpress.Data.SummaryItemType.Max => DevExpress.Blazor.SummaryItemType.Max,
            DevExpress.Data.SummaryItemType.Average => DevExpress.Blazor.SummaryItemType.Avg,
            DevExpress.Data.SummaryItemType.Count => DevExpress.Blazor.SummaryItemType.Count,
            DevExpress.Data.SummaryItemType.Custom => DevExpress.Blazor.SummaryItemType.None,
            _ => DevExpress.Blazor.SummaryItemType.None,
        };
    }
}