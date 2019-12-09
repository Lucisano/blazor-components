using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorComponents.Cards
{
    public class DropDownCardBase : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Header { get; set; }

        [Parameter]
        public string DropDownHeader { get; set; }

        [Parameter]
        public List<Tuple<string, Action>> DropDownItems { get; set; }

        [Parameter]
        public bool Expanded { get; set; }

        public string _expanded { get { return (Expanded) ? "true" : "false"; } }

        public string DropDownDivClass { get { return (Expanded) ? "dropdown no-arrow show" : "dropdown no-arrow"; } }
        public string DropDownMenuLinkClass { get { return (Expanded) ? "dropdown-menu dropdown-menu-right shadow animated--fade-in show" : "dropdown-menu dropdown-menu-right shadow animated--fade-in"; } }
    }
}
