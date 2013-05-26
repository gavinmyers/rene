using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Runtime.InteropServices;
using WinInterop = System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Controls;

namespace Rene.View
{
    public class WindowView : Window
    {

        public WindowView()
        {

            //this.WindowStyle = WindowStyle.None;
            //this.AllowsTransparency = true;
            this.Background = null;

            this.MouseLeftButtonDown += new MouseButtonEventHandler(WindowView_MouseLeftButtonDown);
            this.SourceInitialized += new EventHandler(win_SourceInitialized);
            //this.PreviewMouseDoubleClick += new MouseButtonEventHandler(WindowView_MouseDoubleClick);
            this.Loaded += new RoutedEventHandler(WindowView_Loaded);
            this.StateChanged += new EventHandler(WindowView_StateChanged);

            this.Close += new RoutedEventHandler(WindowView_Close);
            this.Minimise += new RoutedEventHandler(WindowView_Minimise);
            this.Maximise += new RoutedEventHandler(WindowView_Maximise);
        }


        static WindowView()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowView), new FrameworkPropertyMetadata(typeof(WindowView)));
            _CloseCommand = new RoutedCommand("CloseCommand", typeof(WindowView));
            CommandManager.RegisterClassCommandBinding(typeof(WindowView), new CommandBinding(_CloseCommand, OnCloseCommand));

            CloseEvent = EventManager.RegisterRoutedEvent("Close", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(WindowView));

            _MinimiseCommand = new RoutedCommand("MinimiseCommand", typeof(WindowView));
            CommandManager.RegisterClassCommandBinding(typeof(WindowView), new CommandBinding(_MinimiseCommand, OnMinimiseCommand));

            MinimiseEvent = EventManager.RegisterRoutedEvent("Minimise", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(WindowView));

            _MaximiseCommand = new RoutedCommand("MaximiseCommand", typeof(WindowView));
            CommandManager.RegisterClassCommandBinding(typeof(WindowView), new CommandBinding(_MaximiseCommand, OnMaximiseCommand));

            MaximiseEvent = EventManager.RegisterRoutedEvent("Maximise", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(WindowView));

            _PreviousCommand = new RoutedCommand("PreviousCommand", typeof(WindowView));
            CommandManager.RegisterClassCommandBinding(typeof(WindowView), new CommandBinding(_PreviousCommand, OnPreviousCommand));

            PreviousEvent = EventManager.RegisterRoutedEvent("Previous", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(WindowView));

            _NextCommand = new RoutedCommand("NextCommand", typeof(WindowView));
            CommandManager.RegisterClassCommandBinding(typeof(WindowView), new CommandBinding(_NextCommand, OnNextCommand));

            NextEvent = EventManager.RegisterRoutedEvent("Next", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(WindowView));


            _SaveCommand = new RoutedCommand("SaveCommand", typeof(WindowView));
            CommandManager.RegisterClassCommandBinding(typeof(WindowView), new CommandBinding(_SaveCommand, OnSaveCommand));

            SaveEvent = EventManager.RegisterRoutedEvent("Save", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(WindowView));

        }


        void WindowView_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseLeftButtonDown += new MouseButtonEventHandler(BaseView_MouseLeftButtonDown);

            Window w = Window.GetWindow(this);
            w.StateChanged += new EventHandler(WindowView_StateChanged);
            this.IsMaximised = w.WindowState == WindowState.Maximized;
        }

        void WindowView_StateChanged(object sender, EventArgs e)
        {
            Window w = sender as Window;
            this.IsMaximised = w.WindowState == WindowState.Maximized;
        }


        void BaseView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Window.GetWindow(this).DragMove();
            }
            catch (Exception ex)
            {
            }
        }

        #region Previous
        public static RoutedEvent PreviousEvent;
        public event RoutedEventHandler Previous
        {
            add { AddHandler(PreviousEvent, value); }
            remove { RemoveHandler(PreviousEvent, value); }
        }
        private static RoutedCommand _PreviousCommand;
        public static RoutedCommand PreviousCommand
        {
            get { return _PreviousCommand; }

        }
        private static void OnPreviousCommand(object sender, ExecutedRoutedEventArgs e)
        {
            WindowView mw = sender as WindowView;
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = PreviousEvent;
            mw.RaiseEvent(args);
        }
        #endregion

        #region Next
        public static RoutedEvent NextEvent;
        public event RoutedEventHandler Next
        {
            add { AddHandler(NextEvent, value); }
            remove { RemoveHandler(NextEvent, value); }
        }
        private static RoutedCommand _NextCommand;
        public static RoutedCommand NextCommand
        {
            get { return _NextCommand; }

        }
        private static void OnNextCommand(object sender, ExecutedRoutedEventArgs e)
        {
            WindowView mw = sender as WindowView;
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = NextEvent;
            mw.RaiseEvent(args);
        }
        #endregion

        #region Close
        public static RoutedEvent CloseEvent;
        public event RoutedEventHandler Close
        {
            add { AddHandler(CloseEvent, value); }
            remove { RemoveHandler(CloseEvent, value); }
        }
        private static RoutedCommand _CloseCommand;
        public static RoutedCommand CloseCommand
        {
            get { return _CloseCommand; }

        }
        private static void OnCloseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            WindowView mw = sender as WindowView;
            mw.DoClose();
        }
        public virtual void DoClose()
        {
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = CloseEvent;
            this.RaiseEvent(args);
        }
        #endregion


        #region Minimise
        public static RoutedEvent MinimiseEvent;
        public event RoutedEventHandler Minimise
        {
            add { AddHandler(MinimiseEvent, value); }
            remove { RemoveHandler(MinimiseEvent, value); }
        }
        private static RoutedCommand _MinimiseCommand;
        public static RoutedCommand MinimiseCommand
        {
            get { return _MinimiseCommand; }

        }
        private static void OnMinimiseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            WindowView mw = sender as WindowView;
            mw.DoMinimise();
        }
        public virtual void DoMinimise()
        {
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = MinimiseEvent;
            this.RaiseEvent(args);
        }
        #endregion


        #region Maximise
        public static RoutedEvent MaximiseEvent;
        public event RoutedEventHandler Maximise
        {
            add { AddHandler(MaximiseEvent, value); }
            remove { RemoveHandler(MaximiseEvent, value); }
        }
        private static RoutedCommand _MaximiseCommand;
        public static RoutedCommand MaximiseCommand
        {
            get { return _MaximiseCommand; }

        }
        private static void OnMaximiseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            WindowView mw = sender as WindowView;
            mw.DoMaximise();
        }
        public virtual void DoMaximise()
        {
            RoutedEventArgs args = new RoutedEventArgs();

            args.RoutedEvent = MaximiseEvent;
            this.RaiseEvent(args);
        }

        public bool IsMaximised
        {
            get { return (bool)GetValue(IsMaximisedProperty); }
            set { SetValue(IsMaximisedProperty, value); }
        }
        public static readonly DependencyProperty IsMaximisedProperty =
          DependencyProperty.Register("IsMaximised", typeof(bool),
          typeof(WindowView), new UIPropertyMetadata());

        #endregion


        #region Save
        public static RoutedEvent SaveEvent;
        public event RoutedEventHandler Save
        {
            add { AddHandler(SaveEvent, value); }
            remove { RemoveHandler(SaveEvent, value); }
        }
        private static RoutedCommand _SaveCommand;
        public static RoutedCommand SaveCommand
        {
            get { return _SaveCommand; }

        }
        private static void OnSaveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            WindowView mw = sender as WindowView;
            mw.DoSave();
        }
        public virtual void DoSave()
        {
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = SaveEvent;
            this.RaiseEvent(args);
        }
        #endregion





        void win_SourceInitialized(object sender, EventArgs e)
        {
            System.IntPtr handle = (new WinInterop.WindowInteropHelper(this)).Handle;
            WinInterop.HwndSource.FromHwnd(handle).AddHook(new WinInterop.HwndSourceHook(WindowProc));
        }

        void WindowView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception ex) { }
        }


        void WindowView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowView mw = sender as WindowView;
            Window w = Window.GetWindow(mw);

            if (w.WindowState == WindowState.Maximized)
            {
                w.WindowState = WindowState.Normal;
            }
            else
            {
                w.WindowState = WindowState.Maximized;
            }
        }


        void WindowView_Maximise(object sender, RoutedEventArgs e)
        {

            WindowView mw = sender as WindowView;
            Window w = Window.GetWindow(mw);
            if (w.WindowState == WindowState.Maximized)
            {
                w.WindowState = WindowState.Normal;
                ////w.Topmost = true;
            }
            else
            {
                w.WindowState = WindowState.Maximized;
                w.Topmost = false;
            }

        }

        void WindowView_Minimise(object sender, RoutedEventArgs e)
        {

            WindowView mw = sender as WindowView;
            Window w = Window.GetWindow(mw);
            w.WindowState = WindowState.Minimized;

        }


        public virtual void ShowContent(ControlView cv)
        {
            Grid g = this.Template.FindName("PART_Modal", this) as Grid;
            if (g != null)
            {
                g.Children.Add(cv);
            }
        }


        public virtual void HideContent(ControlView cv)
        {
            Grid g = this.Template.FindName("PART_Modal", this) as Grid;
            if (g != null)
            {
                g.Children.Remove(cv);
            }
        }

        public virtual void ShowDetached()
        {
            //w.Topmost = true;
            this.Show();
        }



        public virtual void ShowTaskBar()
        {
        }

        //TODO: This shouldn't be based on Mouse Move... too resource intensive
        void TaskBarModal_MouseMove(object sender, MouseEventArgs e)
        {
            Window w = sender as Window;
            double CloseLeft = SystemParameters.WorkArea.Width - w.Width;
            double CloseTop = SystemParameters.WorkArea.Height - w.Height;

            if (w.Left > (CloseLeft - 50) && w.Left < (CloseLeft + 50))
            {
                w.Left = CloseLeft;
            }

            if (w.Top > (CloseTop - 50) && w.Top < (CloseTop + 50))
            {
                w.Top = CloseTop;
            }
        }



        void WindowView_Close(object sender, RoutedEventArgs e)
        {

            WindowView mw = sender as WindowView;
            Window.GetWindow(mw).Close();

        }


        #region max bug

        private static System.IntPtr WindowProc(
              System.IntPtr hwnd,
              int msg,
              System.IntPtr wParam,
              System.IntPtr lParam,
              ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (System.IntPtr)0;
        }

        private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {

            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            System.IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }


        /// <summary>
        /// POINT aka POINTAPI
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// x coordinate of point.
            /// </summary>
            public int x;
            /// <summary>
            /// y coordinate of point.
            /// </summary>
            public int y;

            /// <summary>
            /// Construct a point of coordinates (x,y).
            /// </summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        void win_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }


        /// <summary>
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            /// <summary>
            /// </summary>            
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

            /// <summary>
            /// </summary>            
            public RECT rcMonitor = new RECT();

            /// <summary>
            /// </summary>            
            public RECT rcWork = new RECT();

            /// <summary>
            /// </summary>            
            public int dwFlags = 0;
        }


        /// <summary> Win32 </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            /// <summary> Win32 </summary>
            public int left;
            /// <summary> Win32 </summary>
            public int top;
            /// <summary> Win32 </summary>
            public int right;
            /// <summary> Win32 </summary>
            public int bottom;

            /// <summary> Win32 </summary>
            public static readonly RECT Empty = new RECT();

            /// <summary> Win32 </summary>
            public int Width
            {
                get { return Math.Abs(right - left); }  // Abs needed for BIDI OS
            }
            /// <summary> Win32 </summary>
            public int Height
            {
                get { return bottom - top; }
            }

            /// <summary> Win32 </summary>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }


            /// <summary> Win32 </summary>
            public RECT(RECT rcSrc)
            {
                this.left = rcSrc.left;
                this.top = rcSrc.top;
                this.right = rcSrc.right;
                this.bottom = rcSrc.bottom;
            }

            /// <summary> Win32 </summary>
            public bool IsEmpty
            {
                get
                {
                    // BUGBUG : On Bidi OS (hebrew arabic) left > right
                    return left >= right || top >= bottom;
                }
            }
            /// <summary> Return a user friendly representation of this struct </summary>
            public override string ToString()
            {
                if (this == RECT.Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }

            /// <summary> Determine if 2 RECT are equal (deep compare) </summary>
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }

            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode()
            {
                return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            }


            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2)
            {
                return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom);
            }

            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2)
            {
                return !(rect1 == rect2);
            }


        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        /// <summary>
        /// 
        /// </summary>
        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
        #endregion
    }
}
