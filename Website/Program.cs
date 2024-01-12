namespace Website;

using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Website.Localization.Api;
using Website.Localization.Model;
using Website.Metadata.Api;
using Website.Metadata.State;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddMudServices();

        builder
            .Services.AddScoped<PageScopedState, InMemoryPageScopedState>()
            .AddSingleton(new PageMetadataSettings(new List<Assembly> { typeof(Program).Assembly }))
            .AddSingleton<PageMetadataRepository, StandardPageMetadataRepository>();

        // I18n Services
        builder
            .Services.AddScoped(typeof(Localizer<>), typeof(StringBasedLocalizer<>))
            .AddLocalization(options => options.ResourcesPath = "Resources")
            .Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    // Set Supported Locales
                    new("en-US"),
                };

                opts.DefaultRequestCulture = new RequestCulture("en-US");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });

        await builder.Build().RunAsync();
    }
}
