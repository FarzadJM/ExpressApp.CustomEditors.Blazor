export async function createElement(element, dotNetHelper, _value, _readOnly, isRtlEnabled) {

    //var $customLink = $('link[custom-link]');
    //if ($customLink.length) {
    //    $('head').append($customLink);
    //}

    return $(element).dxHtmlEditor({
        height: 300,
        value: _value,
        valueType: "html",
        rtlEnabled: isRtlEnabled,
        imageUpload: {
            tabs: ['file', 'url'],
            fileUploadMode: 'base64',
        },
        readOnly: _readOnly,
        toolbar: {
            items: [
                'undo', 'redo', 'separator',
                {
                    name: 'size',
                    acceptedValues: ['8pt', '10pt', '12pt', '14pt', '18pt', '24pt', '36pt'],
                    options: { inputAttr: { 'aria-label': 'Font size' } },
                },
                {
                    name: 'font',
                    acceptedValues: ['Calibri', 'Tahoma', 'Wingdings', 'B Homa', 'B Traffic', 'B Nazanin'],
                    options: { inputAttr: { 'aria-label': 'Font family' } },
                },
                'separator', 'bold', 'italic', 'strike', 'underline', 'separator',
                'alignLeft', 'alignCenter', 'alignRight', 'alignJustify', 'separator',
                'orderedList', 'bulletList', 'separator',
                'color', 'background', 'separator',
                'link', 'image', 'separator',
                'clear', 'codeBlock', 'blockquote', 'separator',
                'insertTable', 'deleteTable',
                'insertRowAbove', 'insertRowBelow', 'deleteRow',
                'insertColumnLeft', 'insertColumnRight', 'deleteColumn',
            ],
        },
        mediaResizing: {
            enabled: true,
        },
        onValueChanged: function (e) {
            dotNetHelper.invokeMethodAsync('OnValueChanged', e.value);
        },
    }).dxHtmlEditor('instance');
}

export async function refresh(element, value) {
    $(element).dxHtmlEditor('instance').reset(value);
}

export async function allowEdit(element, value) {
    $(element).dxHtmlEditor('instance').option("readOnly", !value);
}

export async function dispose(element) {
    if (element) {
        $(element).dxHtmlEditor('dispose');
    }
}