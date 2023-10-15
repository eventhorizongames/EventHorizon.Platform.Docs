namespace Website.Shared.Components.NavTreeView;

using Website.Shared.Components.NavTreeView.Model;

using Microsoft.AspNetCore.Components;

public class NavTreeViewModel : ComponentBase
{
    [Parameter]
    public NavTreeViewNodeData Root { get; set; } = null!;

    [Parameter]
    public EventCallback OnChanged { get; set; }

    [Parameter]
    public EventCallback<NavTreeViewNodeData> OnNodeClicked { get; set; }
}
