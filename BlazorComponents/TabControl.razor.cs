using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorComponents
{
    public class TabControlBase : ComponentBase
    {
        public TabPage ActivePage { get; set; }
        public List<TabPage> Pages = new List<TabPage>();


        public void AddPage(TabPage tabPage)
        {
            Pages.Add(tabPage);
            if (Pages.Count == 1)
                ActivePage = tabPage;
            this.StateHasChanged();
        }
        protected string GetButtonClass(TabPage page) => page == ActivePage ? "btn btn-primary" : "btn";

        protected void ActivatePage(TabPage page) => ActivePage = page;
    }
}
