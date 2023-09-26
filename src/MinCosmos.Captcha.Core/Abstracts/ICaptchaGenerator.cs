namespace MinCosmos.Captcha.Core.Abstracts;

public interface ICaptchaGenerator<in TCode, out TCaptcha> where TCaptcha : Captcha<TCode>
{
    TCaptcha Generate(TCode code);
}

public interface IStorage
{
    T? Get<T>(string key) where T: ICaptcha;
    void Set<T>(string key, T value, TimeSpan expiry) where T: ICaptcha;
    void Remove(string key);
}