namespace AZWeb.Module
{
    public interface IGenCodeService {
        string GetGenCode(object Key, long? TenantId = null, bool isTran = true);
    }
    public interface IGenCodeService<TEnum>: IGenCodeService
    {
        string GetGenCode(TEnum Key, long? TenantId = null, bool isTran = true);
    }
}
