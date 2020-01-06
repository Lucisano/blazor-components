using Microsoft.AspNetCore.Components;

namespace TestBlazorApp.Components
{
    public class DropdownBase : ComponentBase
    {
        [Parameter]
        public string SelectedText { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
