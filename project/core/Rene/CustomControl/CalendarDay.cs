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


namespace Rene.CustomControl
{
    /// <summary>
    /// A single calendar day object
    /// Used by the calendar to show the individual days
    /// Not directly accessed by any other means.
    /// 
    /// All of the properties in this class are Dependency Properties
    /// used by the styles to determine layout.
    /// </summary>
    public class CalendarDay : Button
    {
        public CalendarDay()
        {

        }

        /* IsLastMonth */
        #region IsLastMonth
        public bool IsLastMonth
        {
            get { return (bool)GetValue(IsLastMonthProperty); }
            set { SetValue(IsLastMonthProperty, value); }
        }
        public static readonly DependencyProperty IsLastMonthProperty =
          DependencyProperty.Register("IsLastMonth", typeof(bool),
		  typeof(CalendarDay), new UIPropertyMetadata());
        #endregion

        /* IsNextMonth */
        #region IsNextMonth
        public bool IsNextMonth
        {
            get { return (bool)GetValue(IsNextMonthProperty); }
            set { SetValue(IsNextMonthProperty, value); }
        }

        public static readonly DependencyProperty IsNextMonthProperty =
          DependencyProperty.Register("IsNextMonth", typeof(bool),
		  typeof(CalendarDay), new UIPropertyMetadata());
        #endregion

        /* IsSelectedMonth */
        #region IsSelectedMonth
        public bool IsSelectedMonth
        {
            get { return (bool)GetValue(IsSelectedMonthProperty); }
            set { SetValue(IsSelectedMonthProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedMonthProperty =
          DependencyProperty.Register("IsSelectedMonth", typeof(bool),
		  typeof(CalendarDay), new UIPropertyMetadata());
        #endregion

        /* IsCurrentDay */
        #region IsCurrentDay
        public bool IsCurrentDay
        {
            get { return (bool)GetValue(IsCurrentDayProperty); }
            set { SetValue(IsCurrentDayProperty, value); }
        }

        public static readonly DependencyProperty IsCurrentDayProperty =
          DependencyProperty.Register("IsCurrentDay", typeof(bool),
		  typeof(CalendarDay), new UIPropertyMetadata());
        #endregion

        /* IsSelectedDay */
        #region IsSelectedDay
        public bool IsSelectedDay
        {
            get { return (bool)GetValue(IsSelectedDayProperty); }
            set { SetValue(IsSelectedDayProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedDayProperty =
          DependencyProperty.Register("IsSelectedDay", typeof(bool),
		  typeof(CalendarDay), new UIPropertyMetadata());
        #endregion

        /* IsStartOfWeek */
        #region IsStartOfWeek
        public bool IsStartOfWeek
		{
			get { return (bool)GetValue(IsStartOfWeekProperty); }
			set { SetValue(IsStartOfWeekProperty, value); }
		}

		public static readonly DependencyProperty IsStartOfWeekProperty =
		  DependencyProperty.Register("IsStartOfWeek", typeof(bool),
		  typeof(CalendarDay), new UIPropertyMetadata());
        #endregion

        /* IsEndOfWeek */
        #region IsEndOfWeek
        public bool IsEndOfWeek
		{
			get { return (bool)GetValue(IsEndOfWeekProperty); }
			set { SetValue(IsEndOfWeekProperty, value); }
		}

		public static readonly DependencyProperty IsEndOfWeekProperty =
		  DependencyProperty.Register("IsEndOfWeek", typeof(bool),
		  typeof(CalendarDay), new UIPropertyMetadata());
        #endregion

        /* DateTime */
        #region DateTime property
        public DateTime DateTime
        {
            get{ return (DateTime)GetValue(DateTimeProperty);}
            set{ SetValue(DateTimeProperty, value);}
        }

        public static DependencyProperty DateTimeProperty = DependencyProperty.Register(
                "DateTime",
                typeof(DateTime),
                typeof(CalendarDay),
                new PropertyMetadata(DateTime.Now, new PropertyChangedCallback(OnDateTimeInvalidated)));

        public static readonly RoutedEvent DateTimeChangedEvent =
            EventManager.RegisterRoutedEvent("DateTimeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(CalendarDay));

        protected virtual void OnDateTimeChanged(DateTime oldValue, DateTime newValue)
        {
            RoutedPropertyChangedEventArgs<DateTime> args = new RoutedPropertyChangedEventArgs<DateTime>(oldValue, newValue);
            args.RoutedEvent = CalendarDay.DateTimeChangedEvent;
            RaiseEvent(args);
        }

        private static void OnDateTimeInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CalendarDay c = (CalendarDay)d;

            DateTime oldValue = (DateTime)e.OldValue;
            DateTime newValue = (DateTime)e.NewValue;

            c.OnDateTimeChanged(oldValue, newValue);
        }
        #endregion
    }
}
