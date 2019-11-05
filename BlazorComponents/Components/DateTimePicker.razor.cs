using BlazorComponents.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorComponents.Components
{
    public class DateTimePickerBase : ComponentBase
    {
        #region Properties

        [Parameter]
        public string DateTimeStringFormat { get; set; } = "dd/MM/yyyy";

        [Parameter]
        public bool CloseDateTileWindow { get; set; } = true;

        [Parameter]
        public Action<DateTime> DateChanged { get; set; }

        public bool Expanded { get; set; }

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

        public string CurrentMonth { get { return _dateSelected.ToString("MMMM"); } }

        protected static DateTime _dateSelected { get; set; } = DateTime.Now;
        public string DateSelected { get { return _dateSelected.ToString(DateTimeStringFormat); } set { _dateSelected = value.ToDate(); this.StateHasChanged(); } }

        public static List<DateTime> TileDates
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

        public static DateTime MonthTileStartDate
        {
            get
            {
                var startOfMonth = new DateTime(_dateSelected.Year, _dateSelected.Month, 1);
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
            _dateSelected = date;
            Expanded = (CloseTilePickerOnSelection) ? false : true;
            DateUpdated();
        }

        public void DateInputClick()
        {
            Expanded = true;
            this.StateHasChanged();
        }

        public void MoveBack()
        {
            _dateSelected = _dateSelected.AddDays(-1);
            DateUpdated();
        }

        public void MoveForward()
        {
            _dateSelected = _dateSelected.AddDays(1);
            DateUpdated();
        }

        public void MoveBackMonth()
        {
            _dateSelected = _dateSelected.AddMonths(-1);
            DateUpdated();
        }

        public void MoveForwardMonth()
        {
            _dateSelected = _dateSelected.AddMonths(1);
            DateUpdated();
        }

        private void DateUpdated()
        {
            TimeChanged?.Invoke(_dateSelected);
            this.StateHasChanged();
        }
    }
}
