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
using Rene.View;

namespace Rene.CustomControl
{
    /// <summary>
    /// The three part modal window used by this application
    /// This is a custom control that allows for three areas for UIElements to be placed
    /// 
    /// Title: The title of the modal window
    /// 
    /// Commands: Buttons like Save/Cancel, Yes/No, Ok
    /// 
    /// Content: The content of the modal window
    /// </summary>
    /// 
    public class WindowView : System.Windows.Controls.Control
    {
        public WindowView()
        {
            this.Loaded += new RoutedEventHandler(WindowView_Loaded);
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

        void BaseView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).DragMove();
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

		#region Title
		public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
          DependencyProperty.Register("Title", typeof(string),
          typeof(WindowView), new UIPropertyMetadata());
        #endregion


        #region Icon
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
          DependencyProperty.Register("Icon", typeof(ImageSource),
          typeof(WindowView), new UIPropertyMetadata());
        #endregion

        #region Commands
        public UIElement Commands
        {
            get { return (UIElement)GetValue(CommandsProperty); }
            set { SetValue(CommandsProperty, value); }
        }

        public static readonly DependencyProperty CommandsProperty =
          DependencyProperty.Register("Commands", typeof(UIElement),
          typeof(WindowView), new UIPropertyMetadata());
        #endregion

        #region Content
        public UIElement Content
        {
            get { return (UIElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
          DependencyProperty.Register("Content", typeof(UIElement),
          typeof(WindowView), new UIPropertyMetadata());
        #endregion

    }
}
