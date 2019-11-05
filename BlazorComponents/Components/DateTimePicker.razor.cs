using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponents.Components
{
    public class DateTimePickerBase : ComponentBase
    {
        #region Properties
        private string _title { get; set; }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                this.StateHasChanged();
            }
        }
        #endregion
    }
}
