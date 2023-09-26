using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MinCosmos.Captcha.Core;

public static class CaptchaExtensions
{
    public static CaptchaBuilder AddMineCosmosCaptCha(this IServiceCollection services)
    {
        var builder = new CaptchaBuilder();
        builder.Build();
        services.AddSingleton(builder);
        return builder;
    }

    public static CaptchaBuilder ReplaceService<T1, T2>(this CaptchaBuilder builder) where T1 : class where T2 : class, T1
    {
        builder.ServiceCollection.AddSingleton<T1, T2>();
        builder.Build();

        return builder;
    }
}
