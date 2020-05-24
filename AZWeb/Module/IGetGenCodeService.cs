namespace AZWeb.Module
{
    public interface IGetGenCodeService {
        string GetGenCode(object Key, long? TenantId = null, bool isTran = true);
    }
    public interface IGetGenCodeService<TEnum>: IGetGenCodeService
    {
        string GetGenCode(TEnum Key, long? TenantId = null, bool isTran = true);
    }
}
