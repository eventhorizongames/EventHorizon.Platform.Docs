namespace Website.Metadata.Model;

using System.Reflection;
using Microsoft.AspNetCore.Components;
using Website.Localization;
using Website.Localization.Api;
using Website.Metadata.Api;

public class PageMetadataBase : ComponentBase, PageMetadata
{
    [Inject]
    public Localizer<SharedResource> Localizer { get; set; } = null!;

    [Inject]
    public PageMetadataRepository Repository { get; set; } = null!;

    [Inject]
    public required PageScopedState ScopedState { get; set; }

    public PageMetadataModel PageMetadata { get; private set; } = new PageMetadataModel();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var route = GetType().GetCustomAttribute<RouteAttribute>()?.Template ?? "";
        if (string.IsNullOrEmpty(route))
        {
            return;
        }
        PageMetadata = Repository.Get(route);
        ScopedState.SetCurrentPage(PageMetadata);
    }
}
