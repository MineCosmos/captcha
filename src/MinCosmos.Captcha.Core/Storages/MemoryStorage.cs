
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MinCosmos.Captcha.Core.Abstracts;

namespace MinCosmos.Captcha.Core.Storages;

public class MemoryStorage : IStorage
{
    private readonly IMemoryCache _cache;
    private readonly OptionsMonitor<CaptchaOption> _options;

    public MemoryStorage(IMemoryCache cache, OptionsMonitor<CaptchaOption> options)
    {
        _cache = cache;
        _options = options;
    }

    private string GetWrapKey(string key)
    {
        return $"{_options.CurrentValue.StoragePrefix}_{key}";
    }
    
    public T? Get<T>(string key) where T: ICaptcha
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key));
        }        
        
        return _cache.Get<T>(GetWrapKey((key)));
    }

    public void Remove(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key));
        }    
        
        _cache.Remove(GetWrapKey(key));
    }

    public void Set<T>(string key, T value, TimeSpan expiry) where T: ICaptcha
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key));
        }    
        
        _cache.Set(GetWrapKey(key), value, expiry);
    }
}
