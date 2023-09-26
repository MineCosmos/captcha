using MinCosmos.Captcha.Core.ExtensionsTypes;

namespace MinCosmos.Captcha.Core;

public class CaptchaOption
{
    public Expiry Expiry { get; set; }
    public string? StoragePrefix { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}
