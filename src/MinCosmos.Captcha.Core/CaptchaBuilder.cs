using Microsoft.Extensions.DependencyInjection;

namespace MinCosmos.Captcha.Core;

public class CaptchaBuilder
{
    public IServiceCollection ServiceCollection { get; set; } = new ServiceCollection();

    public IServiceProvider Services { get; private set; } = null!;

    public void Build()
    {
        ServiceCollection.AddDistributedMemoryCache();
        
        Services = ServiceCollection.BuildServiceProvider();
    }
}