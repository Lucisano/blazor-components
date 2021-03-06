﻿using Microsoft.AspNetCore.Components;

namespace TestBlazorApp.Components
{
    public class TabPageBase : ComponentBase
    {
        [CascadingParameter]
        public TabControl Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Text { get; set; }
    }
}