using Microsoft.AspNetCore.Components;

namespace BlazorComponents.Cards
{
    public class CollapsableCardBase : ComponentBase
    {

        [Parameter]
        public EventCallback<bool> ExpandChanged { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Header { get; set; }

        [Parameter]
        public bool Expanded { get; set; }

        public string _expanded { get { return (Expanded) ? "true" : "false"; } }

        public string HeaderClass { get { return (Expanded) ? "d-block card-header py-3" : "d-block card-header py-3 collapsed"; } }

        public string ContentClass { get { return (Expanded) ? "collapse show" : "collapse"; } }

        public void ToggleExpand()
        {
            Expanded = !Expanded;
            ExpandChanged.InvokeAsync(Expanded);
        }
    }
}
