

namespace AZWeb.Module.Page.Manager
{
    public interface IPagination: IUrlVirtual
    {
        public int PageIndex { get; set; }
        public int PageMax { get; set; }
        public int PageSize { get; set; }
        public long PageTotal { get; set; }
        public long PageTotalAll { get; set; }
    }
}
