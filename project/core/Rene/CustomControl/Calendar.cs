using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Rene.Util;
using Rene.Collections;

namespace Rene.CustomControl
{
    /// <summary>
    /// This is a custom calendar control.
    /// The goal of this calendar control is to contain all of the 
    /// logic and output to one property (Calendar.DateTimeContainer). That
    /// should be the only property needed during implementation
    /// <example>
    /// <code>
    /// <cc:Calendar x:Name="startDate" />
    /// </code>          
    /// </example>
    /// </summary>
    public class Calendar : ComboBox
    {
        public Calendar()
        {
			//this.DateTimeContainer = DateTimeContainer.Now;
			//this.UpdateDate();
        }

        #region DateTimeContainer property
        /// <summary>
        /// The DateTimeContainer object of the selected day/month/year
        /// </summary>
        public DateTimeContainer DateTimeContainer
        {
            get{return (DateTimeContainer)GetValue(DateTimeContainerProperty);}
            set{SetValue(DateTimeContainerProperty, value);}
        }
        public static DependencyProperty DateTimeContainerProperty = DependencyProperty.Register(
                "DateTimeContainer",
                typeof(DateTimeContainer),
                typeof(Calendar),
                new PropertyMetadata(new DateTimeContainer(), new PropertyChangedCallback(OnDateTimeContainerInvalidated)));
        private static void OnDateTimeContainerInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Calendar c = (Calendar)d;
            Console.WriteLine("OnDateTimeContainerInvalidated");
            c.UpdateDate();
        }
        #endregion


        #region Day property
        /// <summary>
        /// The string value of the selected day
        /// </summary>
        public string Day
        {
            get
            {
                return GetValue(DayProperty).ToString();
            }
            private set
            {
                SetValue(DayProperty, value);
            }
        }
        public static DependencyProperty DayProperty = DependencyProperty.Register(
                "Day",
                typeof(string),
                typeof(Calendar),
                new PropertyMetadata("1", new PropertyChangedCallback(OnDayInvalidated)));

        private static void OnDayInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("OnDayInvalidated");
            Calendar c = (Calendar)d;
            c.OnInvalidated(d, e);
        }
        #endregion


        #region Month property
        /// <summary>
        /// The string value of the selected month
        /// </summary>
        public string Month
        {
            get
            {
                return GetValue(MonthProperty).ToString();
            }
            private set
            {
                SetValue(MonthProperty, value);
            }
        }
        public static DependencyProperty MonthProperty = DependencyProperty.Register(
                "Month",
                typeof(string),
                typeof(Calendar),
                new PropertyMetadata("1", new PropertyChangedCallback(OnMonthInvalidated)));
        private static void OnMonthInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("OnMonthInvalidated");
            Calendar c = (Calendar)d;
            c.OnInvalidated(d, e);
        }
        #endregion

        #region Year property
        /// <summary>
        /// The string value of the selected year
        /// </summary>
        public string Year
        {
            get
            {
                return GetValue(YearProperty).ToString();
            }
            private set
            {
                SetValue(YearProperty, value);
            }
        }
        public static DependencyProperty YearProperty = DependencyProperty.Register(
                "Year",
                typeof(string),
                typeof(Calendar),
                new PropertyMetadata("1999", new PropertyChangedCallback(OnYearInvalidated)));

        private static void OnYearInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("OnYearInvalidated");
            Calendar c = (Calendar)d;
            c.OnInvalidated(d, e);
        }
        #endregion

        /// <summary>
        /// Event when the calendar value has been changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private void OnInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
            Calendar c = (Calendar)d;

            if (c.Month == "" || c.Day == "" || c.Year == "")
            {
                return;
            }
            int Month = int.Parse(c.Month);
            c.DateTimeContainer.DateTime = c.DateTimeContainer.DateTime.AddMonths(Month - c.DateTimeContainer.DateTime.Month);

            int Day = int.Parse(c.Day);
            c.DateTimeContainer.DateTime = c.DateTimeContainer.DateTime.AddDays(Day - c.DateTimeContainer.DateTime.Day);

            int Year = int.Parse(c.Year);
            c.DateTimeContainer.DateTime = c.DateTimeContainer.DateTime.AddYears(Year - c.DateTimeContainer.DateTime.Year);

            Console.WriteLine(c.DateTimeContainer.DateTime + " FINAL");

            this.UpdateDate();
        }


        /// <summary>
        /// Updates the date list with new dates
        /// </summary>
        public void UpdateDate()
        {

            this.Days = new AdvancedObservableCollection<CalendarDay>();
            //current day
            DateTime currentDay = this.DateTimeContainer.DateTime;
            Console.WriteLine(currentDay);
            currentDay = new DateTime(currentDay.Year, currentDay.Month, currentDay.Day);

            //last month 
            DateTime lastMonth = new DateTime(currentDay.Year, currentDay.Month, 1);
            lastMonth = lastMonth.AddMonths(-1);
            Console.WriteLine(lastMonth);
            Console.WriteLine(currentDay.Month);

            //this month
            DateTime currentMonth = new DateTime(currentDay.Year, currentDay.Month, 1);

            //next month
            DateTime nextMonth = new DateTime(currentDay.Year, currentDay.Month, 1);
            nextMonth = nextMonth.AddMonths(1);

            for (int i = (int)currentMonth.DayOfWeek - 1; i >= 0; i--)
            {
                CalendarDay cd = new CalendarDay();
                cd.IsLastMonth = true;
                cd.DateTime = new DateTime(lastMonth.Year, lastMonth.Month, (DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month) - i));
                cd.IsStartOfWeek = cd.DateTime.DayOfWeek == DayOfWeek.Sunday;
                cd.IsEndOfWeek = cd.DateTime.DayOfWeek == DayOfWeek.Saturday;
                cd.IsCurrentDay = (cd.DateTime.Day == DateTime.Now.Day && cd.DateTime.Month == DateTime.Now.Month && cd.DateTime.Year == DateTime.Now.Year);
                this.Days.Add(cd);

            }

            for (int i = 1; i <= DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month); i++)
            {
                CalendarDay cd = new CalendarDay();
                cd.IsSelectedMonth = true;
                cd.DateTime = new DateTime(currentMonth.Year, currentMonth.Month, i);
                cd.IsStartOfWeek = cd.DateTime.DayOfWeek == DayOfWeek.Sunday;
                cd.IsEndOfWeek = cd.DateTime.DayOfWeek == DayOfWeek.Saturday;
                cd.IsCurrentDay = (cd.DateTime.Day == DateTime.Now.Day && cd.DateTime.Month == DateTime.Now.Month && cd.DateTime.Year == DateTime.Now.Year);
                this.Days.Add(cd);
            }

            int counter = 0;
            for (int i = (int)nextMonth.DayOfWeek; i <= (int)DayOfWeek.Saturday; i++)
            {
                counter++;
                CalendarDay cd = new CalendarDay();
                cd.IsNextMonth = true;
                cd.DateTime = new DateTime(nextMonth.Year, nextMonth.Month, counter);
                cd.IsStartOfWeek = cd.DateTime.DayOfWeek == DayOfWeek.Sunday;
                cd.IsEndOfWeek = cd.DateTime.DayOfWeek == DayOfWeek.Saturday;
                cd.IsCurrentDay = (cd.DateTime.Day == DateTime.Now.Day && cd.DateTime.Month == DateTime.Now.Month && cd.DateTime.Year == DateTime.Now.Year);
                this.Days.Add(cd);
            }
            this.Day = currentDay.Day.ToString();
            this.Month = currentDay.Month.ToString();
            this.Year = currentDay.Year.ToString();

        }


        #region Days property
        /// <summary>
        /// The total list of days in the month. The few days of last month and the few
        /// days of next month to create a full set of weeks
        /// </summary>
        public AdvancedObservableCollection<CalendarDay> Days
        {
            get
            {
                return GetValue(DaysProperty) as AdvancedObservableCollection<CalendarDay>;
            }
            private set
            {
                SetValue(DaysProperty, value);
            }
        }
        public static DependencyProperty DaysProperty = DependencyProperty.Register(
                "Days",
                typeof(AdvancedObservableCollection<CalendarDay>),
                typeof(Calendar),
                new PropertyMetadata());

        #endregion



        /*
        #region DateTimeContainer property
        /// <summary>
        /// The DateTimeContainer object of the selected day/month/year
        /// </summary>
        public DateTimeContainer DateTimeContainer
        {
            get
            {
                return (DateTimeContainer)GetValue(DateTimeContainerProperty);
            }
            set
            {
                SetValue(DateTimeContainerProperty, value);
            }
        }

        public static DependencyProperty DateTimeContainerProperty = DependencyProperty.Register(
                "DateTimeContainer",
                typeof(DateTimeContainer),
                typeof(Calendar),
                new PropertyMetadata(DateTimeContainer.Now, new PropertyChangedCallback(OnDateTimeContainerInvalidated)));

        public static readonly RoutedEvent DateTimeContainerChangedEvent =
            EventManager.RegisterRoutedEvent("DateTimeContainerChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTimeContainer>), typeof(Calendar));



        private static void OnDateTimeContainerInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Calendar c = (Calendar)d;

            //DateTimeContainer oldValue = (DateTimeContainer)e.OldValue;
            //DateTimeContainer newValue = (DateTimeContainer)e.NewValue;

            //c.OnDateTimeContainerChanged(oldValue, newValue);

            Console.WriteLine("OnDateTimeContainerInvalidated " + newValue);
            c.UpdateDate();
        }



        #endregion


        /// <summary>
        /// Event when the calendar value has been changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private void OnInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Calendar c = (Calendar)d;

            if (c.Month == "" || c.Day == "" || c.Year == "")
            {
                return;
            }
            int Month = int.Parse(c.Month);
            c.DateTimeContainer = c.DateTimeContainer.AddMonths(Month - c.DateTimeContainer.Month);

            int Day = int.Parse(c.Day);
            c.DateTimeContainer = c.DateTimeContainer.AddDays(Day - c.DateTimeContainer.Day);

            int Year = int.Parse(c.Year);
            c.DateTimeContainer = c.DateTimeContainer.AddYears(Year - c.DateTimeContainer.Year);

            Console.WriteLine(c.DateTimeContainer + " FINAL");
            //c.UpdateDate();
        }
         * */

    }
}
