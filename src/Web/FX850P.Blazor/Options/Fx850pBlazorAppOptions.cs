using System;
using FX850P.Infrastructure.Options;

namespace FX850P.Blazor.Options;

public class Fx850pBlazorAppOptions : AppOptions
{
    public Fx850pBlazorAppOptions()
    {
        ProductName = "FX850P Blazor";
        PublicKey = @"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAESC/ht79tMthyr+BJygrSaXVoxsyx2PTCZKtLKh0KkHvdgpPv4ZMyr8iBGAUTdknj22WRQUDffYNQi1Yxwx6IbQ==";
        Guid = Guid.Parse("61501fca-4abd-4428-b62a-8549771e1cfd");

    }
}
