using System;
using Microsoft.Extensions.DependencyInjection;
using Texnomic.Blazor.hCaptcha.Configurations;

namespace Texnomic.Blazor.hCaptcha.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHCaptcha(this IServiceCollection Services, Action<HCaptchaConfiguration> Configuration)
        {
            Services.Configure<HCaptchaConfiguration>("hCaptcha", Configuration);

            return Services;
        }

    }
}
