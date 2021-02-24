namespace EventHorizon.Platform.Docs
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using EventHorizon.Platform.Docs.Localization.Api;
    using EventHorizon.Platform.Docs.Localization.Model;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Localization;
    using System.Globalization;
    using EventHorizon.Platform.Docs.Metadata.State;
    using EventHorizon.Platform.Docs.Metadata.Api;
    using System.Reflection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            // builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(
                new PageMetadataSettings(
                    new List<Assembly>
                    {
                        typeof(Program).Assembly
                    }
                )
            ).AddSingleton<PageMetadataRepository, StandardPageMetadataRepository>();

            // I18n Services
            builder.Services
                .AddScoped(typeof(Localizer<>), typeof(StringBasedLocalizer<>))
                .AddLocalization(options => options.ResourcesPath = "Resources")
                .Configure<RequestLocalizationOptions>(
                    opts =>
                    {
                        var supportedCultures = new List<CultureInfo>
                        {
                            // Set Supported Locales
                            new CultureInfo("en-US"),
                        };

                        opts.DefaultRequestCulture = new RequestCulture("en-US");
                        // Formatting numbers, dates, etc.
                        opts.SupportedCultures = supportedCultures;
                        // UI strings that we have localized.
                        opts.SupportedUICultures = supportedCultures;
                    }
                );

            await builder.Build().RunAsync();
        }
    }
}
