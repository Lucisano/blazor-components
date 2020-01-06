using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace TestBlazorApp.Components
{
    public class TabControlBase : ComponentBase
    {
        public TabPage ActivePage { get; set; }
        public List<TabPage> Pages = new List<TabPage>();

        [Parameter]
        public List<Dropdown> ExtraDropdowns { get; set; }

        public void AddPage(TabPage tabPage)
        {
            Pages.Add(tabPage);
            if (Pages.Count == 1)
                ActivePage = tabPage;
            this.StateHasChanged();
        }
        protected string GetButtonClass(TabPage page) => page == ActivePage ? "btn btn-primary" : "btn";

        protected void ActivatePage(TabPage page) => ActivePage = page;

        protected void SelectionChanged(ChangeEventArgs e)
        {
            if (Pages.Any(x => x.Text == e.Value.ToString()))
            {
                ActivatePage(Pages.Where(x => x.Text == e.Value.ToString()).FirstOrDefault());
            }
        }
    }
}
