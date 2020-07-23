using System.Linq;

namespace AZWeb.Module.Html.Grid
{
    public interface IGridProcessor<T>
    {
        GridProcessorType ProcessorType { get; set; }

        IQueryable<T> Process(IQueryable<T> items);
    }
}
