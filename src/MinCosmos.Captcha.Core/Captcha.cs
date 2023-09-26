namespace MinCosmos.Captcha.Core;

public interface ICaptcha
{
    string Id { get; set; }
}

public abstract class Captcha<T> : ICaptcha
{
    public required string Id { get; set; }
    public required T Code { get; set; }
    public required byte[] Bytes { get; set; }
    public string Base64 => Convert.ToBase64String(Bytes);
}