
using System;

namespace FX850P.Infrastructure.Options;

public class AppOptions
{
    public string ProductName { get; set; } = default!;
    public string PublicKey { get; set; } = default!;
    public Guid Guid { get; set; }

    public AppOptions()
    {
    }

    public AppOptions(string productName, string publicKey, string guid)
    {
        ProductName = productName;
        PublicKey = publicKey;
        Guid = Guid.Parse(guid);
    }

    public void Inject(AppOptions other)
    {
        ProductName = other.ProductName;
        PublicKey = other.PublicKey;
        Guid = other.Guid;
    }

    public static AppOptions Clone(AppOptions other)
    {
        if (other != null)
            return new AppOptions(other.ProductName, other.PublicKey, other.Guid.ToString());

        return null;
    }
}
