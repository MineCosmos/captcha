using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using MinCosmos.Captcha.Core.Abstracts;
using MinCosmos.Captcha.Core.Extensions;

namespace MinCosmos.Captcha.Core.Storages;

public class DistributedStorage: IStorage
{
    private readonly IDistributedCache _cache;
    private readonly OptionsMonitor<CaptchaOption> _options;

    public DistributedStorage(IDistributedCache cache, OptionsMonitor<CaptchaOption> options)
    {
        _cache = cache;
        _options = options;
    }
    
    private string GetWrapKey(string key)
    {
        return $"{_options.CurrentValue.StoragePrefix}_{key}";
    }
    
    public T? Get<T>(string key) where T : ICaptcha
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key));
        }  
        
        return _cache.GetString(GetWrapKey(key)).ToObject<T>();
    }

    public void Set<T>(string key, T value, TimeSpan expiry) where T : ICaptcha
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        _cache.SetString(GetWrapKey(key), value.ToJson(), new DistributedCacheEntryOptions()
        {
            SlidingExpiration = expiry
        });
    }

    public void Remove(string key)
    {
        throw new NotImplementedException();
    }
}
