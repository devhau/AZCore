namespace AZWeb.Common.Module.View
{
    public class JsonView : IView
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
