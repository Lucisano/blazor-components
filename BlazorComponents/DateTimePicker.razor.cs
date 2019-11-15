using BlazorComponents.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorComponents
{
    public class DateTimePickerBase : ComponentBase
    {
        #region Properties

        [Parameter]
        public string DateTimeStringFormat { get; set; } = "dd/MM/yyyy";

        [Parameter]
        public bool CloseDateTileWindow { get; set; }

        [Parameter]
        public Action<DateTime> DateChanged { get; set; }

        public bool Expanded { get; set; }

        private string _title { get; set; }
        [Parameter]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                this.StateHasChanged();
            }
        }

        public string CurrentMonth { get { return _dateValue.ToString("MMMM"); } }

        protected DateTime _dateValue { get; set; } = DateTime.Now;

        [Parameter]
        public DateTime DateValue { get { return _dateValue; } set { _dateValue = value; this.StateHasChanged(); } }

        public string DateString { get { return _dateValue.ToString(DateTimeStringFormat); } set { _dateValue = value.ToDate(); this.StateHasChanged(); } }

        public List<DateTime> TileDates
        {
            get
            {
                var dateList = new List<DateTime>();
                for (var i = 0; i < 43; i++)
                {
                    dateList.Add(MonthTileStartDate.AddDays(i));
                }
                return dateList;
            }
        }

        public DateTime MonthTileStartDate
        {
            get
            {
                var startOfMonth = new DateTime(_dateValue.Year, _dateValue.Month, 1);
                if (startOfMonth.DayOfWeek == DayOfWeek.Monday)
                {
                    return startOfMonth;
                }
                else
                {
                    while (startOfMonth.DayOfWeek != DayOfWeek.Monday)
                    {
                        startOfMonth = startOfMonth.AddDays(-1);
                    }
                    return startOfMonth;
                }
            }
        }

        #endregion

        public void DateTileClick(DateTime date)
        {
            _dateValue = date;
            Expanded = (CloseDateTileWindow) ? false : true;
            DateUpdated();
        }

        public void DateInputClick()
        {
            Expanded = true;
            this.StateHasChanged();
        }

        public void MoveBack()
        {
            _dateValue = _dateValue.AddDays(-1);
            DateUpdated();
        }

        public void MoveForward()
        {
            _dateValue = _dateValue.AddDays(1);
            DateUpdated();
        }

        public void MoveBackMonth()
        {
            _dateValue = _dateValue.AddMonths(-1);
            DateUpdated();
        }

        public void MoveForwardMonth()
        {
            _dateValue = _dateValue.AddMonths(1);
            DateUpdated();
        }

        private void DateUpdated()
        {
            DateChanged?.Invoke(_dateValue);
            this.StateHasChanged();
        }

        protected void DateInput_OnKeyPress(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                Expanded = (CloseDateTileWindow) ? false : true;
            }
        }
    }
}
