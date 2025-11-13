namespace FX850P.Infrastructure.Options;

public class AppOptions
{
    public string ProductName { get; set; } = default!;
    public string PublicKey { get; set; } = default!;
    public Guid AppGuid { get; set; }

    public AppOptions()
    {
    }

    public AppOptions(string productName, string publicKey, string appGuid)
    {
        ProductName = productName;
        PublicKey = publicKey;
        AppGuid = Guid.Parse(appGuid);
    }

    public void Inject(AppOptions other)
    {
        ProductName = other.ProductName;
        PublicKey = other.PublicKey;
        AppGuid = other.AppGuid;
    }

    public static AppOptions Clone(AppOptions other)
    {
        if (other != null)
        {
            return new AppOptions(other.ProductName, other.PublicKey, other.AppGuid.ToString());
        }

#pragma warning disable CS8603 // Possible null reference return.
        return null;
#pragma warning restore CS8603 // Possible null reference return.
    }
}
