namespace ExpressApp.CustomEditors.Blazor.SfPdfViewer2;

public interface ISfPdfViewer2Obj
{
    public string DownloadFileName { get; }
    public byte[] DocumentContent { get; }
    public Dictionary<string, string> FormFields { get; set; }
}
