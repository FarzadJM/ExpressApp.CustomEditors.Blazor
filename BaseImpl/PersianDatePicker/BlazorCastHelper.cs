using DevExpress.Blazor;

namespace ExpressApp.CustomEditors.Blazor.BaseImpl.PersianDatePicker;

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
}