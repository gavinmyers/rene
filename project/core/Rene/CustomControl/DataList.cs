using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Markup;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Data;
using Rene.Event;
using Rene.Util;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Rene.Collections;

namespace Rene.CustomControl
{
	public partial class DataList : ListView
	{

        public DataList()
        {
            this.SizeChanged += new SizeChangedEventHandler(DataList_SizeChanged);
            this.Loaded += new RoutedEventHandler(DataList_Loaded);
            this.LayoutUpdated +=new EventHandler(DataList_LayoutUpdated);
        }


        void DataList_LayoutUpdated(object sender, EventArgs e)
        {
            if (!this.IsLoaded)
            {
                return;
            }
            this.SizeChangedAction();
        }


		static DataList()
		{
			//this.SelectionMode = SelectionMode.Multiple;
			//this.ListViewColumnSorter = new ListViewColumnSorter();

			_EditCommand = new RoutedCommand("EditCommand", typeof(DataList));
			CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_EditCommand, OnEditCommand));

			EditEvent = EventManager.RegisterRoutedEvent("Edit", RoutingStrategy.Bubble,
				typeof(ExecutedRoutedEventHandler), typeof(DataList));

			_AddCommand = new RoutedCommand("AddCommand", typeof(DataList));
			CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_AddCommand, OnAddCommand));

			AddEvent = EventManager.RegisterRoutedEvent("Add", RoutingStrategy.Bubble,
				typeof(ExecutedRoutedEventHandler), typeof(DataList));

			_DeleteCommand = new RoutedCommand("DeleteCommand", typeof(DataList));
			CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_DeleteCommand, OnDeleteCommand));

			DeleteEvent = EventManager.RegisterRoutedEvent("Delete", RoutingStrategy.Bubble,
				typeof(ExecutedRoutedEventHandler), typeof(DataList));

            _UploadCommand = new RoutedCommand("UploadCommand", typeof(DataList));
            CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_UploadCommand, OnUploadCommand));

            UploadEvent = EventManager.RegisterRoutedEvent("Upload", RoutingStrategy.Bubble,
                typeof(ExecutedRoutedEventHandler), typeof(DataList));

            _SearchCommand = new RoutedCommand("SearchCommand", typeof(DataList));
            CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_SearchCommand, OnSearchCommand));

            SearchEvent = EventManager.RegisterRoutedEvent("Search", RoutingStrategy.Bubble,
                typeof(ExecutedRoutedEventHandler), typeof(DataList));

            _ClearAllCommand = new RoutedCommand("ClearAllCommand", typeof(DataList));
            CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_ClearAllCommand, OnClearAllCommand));

            ClearAllEvent = EventManager.RegisterRoutedEvent("ClearAll", RoutingStrategy.Bubble,
                typeof(ExecutedRoutedEventHandler), typeof(DataList));

            _SelectAllCommand = new RoutedCommand("SelectAllCommand", typeof(DataList));
            CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_SelectAllCommand, OnSelectAllCommand));

            SelectAllEvent = EventManager.RegisterRoutedEvent("SelectAll", RoutingStrategy.Bubble,
                typeof(ExecutedRoutedEventHandler), typeof(DataList));


            _SelectCustomCommand = new RoutedCommand("SelectCustomCommand", typeof(DataList));
            CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_SelectCustomCommand, OnSelectCustomCommand));

            SelectCustomEvent = EventManager.RegisterRoutedEvent("SelectCustom", RoutingStrategy.Bubble,
                typeof(ExecutedRoutedEventHandler), typeof(DataList));

            _FilterCustomCommand = new RoutedCommand("FilterCustomCommand", typeof(DataList));
            CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_FilterCustomCommand, OnFilterCustomCommand));

            FilterCustomEvent = EventManager.RegisterRoutedEvent("FilterCustom", RoutingStrategy.Bubble,
                typeof(ExecutedRoutedEventHandler), typeof(DataList));

            _ManualSelectionChangedCommand = new RoutedCommand("ManualSelectionChangedCommand", typeof(DataList));
            CommandManager.RegisterClassCommandBinding(typeof(DataList), new CommandBinding(_ManualSelectionChangedCommand, OnManualSelectionChangedCommand));

            ManualSelectionChangedEvent = EventManager.RegisterRoutedEvent("ManualSelectionChanged", RoutingStrategy.Bubble,
                typeof(ExecutedRoutedEventHandler), typeof(DataList));
		
        }

        #region Search
        public static RoutedEvent SearchEvent;
        public event ExecutedRoutedEventHandler Search
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }
        private static RoutedCommand _SearchCommand;
        public static RoutedCommand SearchCommand
        {
            get { return _SearchCommand; }

        }
        private static void OnSearchCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataList mw = sender as DataList;
            if (e.OriginalSource is Control)
            {
                Control b = e.OriginalSource as Control;
                mw.Select(b.DataContext);
            }
            RoutedEventArgs args = new RoutedEventArgs();
            e.RoutedEvent = SearchEvent;
            mw.RaiseEvent(e);
        }
        #endregion

        #region Upload
        public static RoutedEvent UploadEvent;
        public event ExecutedRoutedEventHandler Upload
        {
            add { AddHandler(UploadEvent, value); }
            remove { RemoveHandler(UploadEvent, value); }
        }
        private static RoutedCommand _UploadCommand;
        public static RoutedCommand UploadCommand
        {
            get { return _UploadCommand; }

        }
        private static void OnUploadCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataList mw = sender as DataList;
            if (e.OriginalSource is Control)
            {
                Control b = e.OriginalSource as Control;
                mw.Select(b.DataContext);
            }
            RoutedEventArgs args = new RoutedEventArgs();
            e.RoutedEvent = UploadEvent;
            mw.RaiseEvent(e);
        }
        #endregion

		#region Edit
		public static RoutedEvent EditEvent;
		public event ExecutedRoutedEventHandler Edit
		{
			add { AddHandler(EditEvent, value); }
			remove { RemoveHandler(EditEvent, value); }
		}
		private static RoutedCommand _EditCommand;
		public static RoutedCommand EditCommand
		{
			get { return _EditCommand; }

		}
		private static void OnEditCommand(object sender, ExecutedRoutedEventArgs e)
		{
			DataList mw = sender as DataList;
			if (e.OriginalSource is Control)
			{
				Control b = e.OriginalSource as Control;
				mw.Select(b.DataContext);
			}
			RoutedEventArgs args = new RoutedEventArgs();
			e.RoutedEvent = EditEvent;
			mw.RaiseEvent(e);
		}
		#endregion

		#region Add
		public static RoutedEvent AddEvent;
		public event ExecutedRoutedEventHandler Add
		{
			add { AddHandler(AddEvent, value); }
			remove { RemoveHandler(AddEvent, value); }
		}
		private static RoutedCommand _AddCommand;
		public static RoutedCommand AddCommand
		{
			get { return _AddCommand; }

		}
		private static void OnAddCommand(object sender, ExecutedRoutedEventArgs e)
		{
			DataList mw = sender as DataList;
			if (e.OriginalSource is Control)
			{
				Control b = e.OriginalSource as Control;
				mw.Select(b.DataContext);
			}
			RoutedEventArgs args = new RoutedEventArgs();
			e.RoutedEvent = AddEvent;
			mw.RaiseEvent(e);
		}
		#endregion

		#region Delete
		public static RoutedEvent DeleteEvent;
		public event ExecutedRoutedEventHandler Delete
		{
			add { AddHandler(DeleteEvent, value); }
			remove { RemoveHandler(DeleteEvent, value); }
		}
		private static RoutedCommand _DeleteCommand;
		public static RoutedCommand DeleteCommand
		{
			get { return _DeleteCommand; }

		}
		private static void OnDeleteCommand(object sender, ExecutedRoutedEventArgs e)
		{
			DataList mw = sender as DataList;
			if (e.OriginalSource is Control)
			{
				Control b = e.OriginalSource as Control;
				mw.Select(b.DataContext);
			}
			RoutedEventArgs args = new RoutedEventArgs();
			e.RoutedEvent = DeleteEvent;
			mw.RaiseEvent(e);
		}
		#endregion

        #region SelectAll
        public static RoutedEvent SelectAllEvent;
        public event ExecutedRoutedEventHandler SelectAll
        {
            add { AddHandler(SelectAllEvent, value); }
            remove { RemoveHandler(SelectAllEvent, value); }
        }
        private static RoutedCommand _SelectAllCommand;
        public static RoutedCommand SelectAllCommand
        {
            get { return _SelectAllCommand; }

        }
        private static void OnSelectAllCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataList mw = sender as DataList;
            if (e.OriginalSource is Control)
            {
                Control b = e.OriginalSource as Control;
                mw.Select(b.DataContext);
            }
            RoutedEventArgs args = new RoutedEventArgs();
            e.RoutedEvent = SelectAllEvent;
            mw.RaiseEvent(e);
        }
        #endregion

        #region SelectCustom
        public static RoutedEvent SelectCustomEvent;
        public event ExecutedRoutedEventHandler SelectCustom
        {
            add { AddHandler(SelectCustomEvent, value); }
            remove { RemoveHandler(SelectCustomEvent, value); }
        }
        private static RoutedCommand _SelectCustomCommand;
        public static RoutedCommand SelectCustomCommand
        {
            get { return _SelectCustomCommand; }

        }
        private static void OnSelectCustomCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataList mw = sender as DataList;
            e.RoutedEvent = SelectCustomEvent;
            mw.RaiseEvent(e);
        }
        #endregion

        #region FilterCustom
        public static RoutedEvent FilterCustomEvent;
        public event ExecutedRoutedEventHandler FilterCustom
        {
            add { AddHandler(FilterCustomEvent, value); }
            remove { RemoveHandler(FilterCustomEvent, value); }
        }
        private static RoutedCommand _FilterCustomCommand;
        public static RoutedCommand FilterCustomCommand
        {
            get { return _FilterCustomCommand; }

        }
        private static void OnFilterCustomCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataList mw = sender as DataList;
            if (e.OriginalSource is Control)
            {
                Control b = e.OriginalSource as Control;
                mw.Select(b.DataContext);
            }
            e.RoutedEvent = FilterCustomEvent;
            mw.RaiseEvent(e);
        }
        #endregion

        #region ManualSelectionChanged
        public static RoutedEvent ManualSelectionChangedEvent;
        public event ExecutedRoutedEventHandler ManualSelectionChanged
        {
            add { AddHandler(ManualSelectionChangedEvent, value); }
            remove { RemoveHandler(ManualSelectionChangedEvent, value); }
        }
        private static RoutedCommand _ManualSelectionChangedCommand;
        public static RoutedCommand ManualSelectionChangedCommand
        {
            get { return _ManualSelectionChangedCommand; }

        }
        private static void OnManualSelectionChangedCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataList mw = sender as DataList;
            if (e.OriginalSource is Control)
            {
                Control b = e.OriginalSource as Control;
                mw.Select(b.DataContext);
            }
            e.RoutedEvent = ManualSelectionChangedEvent;
            mw.RaiseEvent(e);
        }
        #endregion

        #region ClearAll
        public static RoutedEvent ClearAllEvent;
        public event ExecutedRoutedEventHandler ClearAll
        {
            add { AddHandler(ClearAllEvent, value); }
            remove { RemoveHandler(ClearAllEvent, value); }
        }
        private static RoutedCommand _ClearAllCommand;
        public static RoutedCommand ClearAllCommand
        {
            get { return _ClearAllCommand; }

        }
        private static void OnClearAllCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataList mw = sender as DataList;
            if (e.OriginalSource is Control)
            {
                Control b = e.OriginalSource as Control;
                mw.Select(b.DataContext);
            }
            RoutedEventArgs args = new RoutedEventArgs();
            e.RoutedEvent = ClearAllEvent;
            mw.RaiseEvent(e);
        }
        #endregion

        #region SizeChanged

        void DataList_Loaded(object sender, RoutedEventArgs e)
        {
            this.SelectionChanged +=new SelectionChangedEventHandler(DataList_SelectionChanged);

            //e.Handled = true;
            if (this.Template.FindName("PART_List", this) != null)
            {
                if (!this.GridViewColumnsCalculated)
                {
                    ListView lv = this.Template.FindName("PART_List", this) as ListView;   
                    GridView gv = lv.View as GridView;
                    if (gv == null)
                    {
                        return;
                    }

                    foreach (GridViewColumn gvc in gv.Columns)
                    {
                        if (gvc.Width > 0)
                        {
                            //has a set width
                            GridViewColumns.Add(gvc);
                        }
                    }
                    this.GridViewColumnsCalculated = true;
                }
                else
                {
                    
                }
                this.SizeChangedAction();
            }
        }

        public bool ApplyFilter(object item)
        {
            if (!(item is Rene.DataObject.DataObject))
            {
                return true;
            }

            Rene.DataObject.DataObject dao = item as Rene.DataObject.DataObject;
            return dao.IsVisible;
        }



        void DataList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!this.IsLoaded)
            {
                return;
            }
            e.Handled = true;
            this.SizeChangedAction();

        }

        bool GridViewColumnsCalculated = false;
        AdvancedObservableCollection<GridViewColumn> GridViewColumns = new AdvancedObservableCollection<GridViewColumn>();

        double LastTotal = 0;
        double LastWidth = 0;

        public void SizeChangedAction()
        {

            if (this.Template.FindName("PART_List", this) != null)
            {
                ListView lv = this.Template.FindName("PART_List", this) as ListView;

                GridView gv = lv.View as GridView;
                if (gv == null)
                {
                    return;
                }
                double total = 0;

                
                //HACK why are scrollbars showing up, find margin/padding/spacing issue
                double width = lv.ActualWidth;// -20;

                foreach (GridViewColumn gvc in gv.Columns)
                {
                    if(this.GridViewColumns.Contains(gvc)) {
                        width = width - gvc.Width;
                    } else {
                        total += gvc.ActualWidth;

                    }
                }


                if ((int)LastTotal == (int)total && (int)LastWidth == (int)this.ActualWidth)
                {
                    return;
                }
                //odd 1 pixel issue -- fun stuff, if I don't do this we get into an infinite loop
                if ((LastTotal - total) < 2 && (LastTotal - total) > -2 && (int)LastWidth == (int)this.ActualWidth)
                {
                    return;
                }
                LastTotal = total;
                LastWidth = this.ActualWidth;

                if (total < 1)
                {
                    return;
                }


                double finalWidth = 0;

                foreach (GridViewColumn gvc in gv.Columns)
                {
                    if (this.GridViewColumns.Contains(gvc))
                    {
                    }
                    else
                    {
                        Double actual = gvc.ActualWidth;
                        if(actual < 10) {
                            actual = 10;
                        }
                        double percent = actual / total;
                        if ((width * percent) > 0)
                        {
                            gvc.Width = width * percent;
                        }
                        finalWidth += gvc.Width;
                    }

 
                }

            }
            
        }

        #endregion
        void DataList_MouseUp(object sender, MouseButtonEventArgs e)
		{
		}

		void DataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            foreach (DataObject.DataObject dao in this.Items)
            {
                dao.IsSelected = false;
            }
            foreach (DataObject.DataObject dao in GetListView().SelectedItems)
            {
                dao.IsSelected = true;
            }
		}


		public void Sort()
		{
			this.SortBy("SortOrder", ListSortDirection.Ascending);
		}

		public void SortBy(string code, ListSortDirection sort)
		{
			if (this.Template.FindName("PART_List", this) == null)
			{
				return;
			}
			ListView lv = this.Template.FindName("PART_List", this) as ListView;
			ArrayList al = new ArrayList(lv.SelectedItems);
			lv.Items.SortDescriptions.Clear();
			SortDescription sd = new SortDescription(code, sort);
			lv.Items.SortDescriptions.Add(sd);

            /*
			lv.Items.Refresh();
			foreach (object o in al)
			{
				this.Select(o);
			}
             */

		}

		public void Select(object o)
		{
            if (o == null)
            {
                return;
            }

            if (o is DataObject.DataObject)
            {
                DataObject.DataObject dao = o as DataObject.DataObject;
                dao.IsSelected = true;
            }

            ListView lv = this.GetListView();

            if (lv != null)
			{                
				if (lv.SelectionMode == SelectionMode.Multiple)
				{
					lv.SelectedItems.Add(o);
				}
				else
				{
					lv.SelectedItem = o;
				}

			}
		}


        public void DeSelect(object o)
        {
            if (o == null)
            {
                return;
            }

            if (o is DataObject.DataObject)
            {
                DataObject.DataObject dao = o as DataObject.DataObject;
                dao.IsSelected = false;
            }

            ListView lv = this.GetListView();

            if (lv != null)
            {
                if (lv.SelectionMode == SelectionMode.Multiple)
                {
                    lv.SelectedItems.Remove(o);
                }
                else
                {
                    this.Clear();
                }

            }
        }

		public void Clear()
		{
			if (this.Template.FindName("PART_List", this) != null)
			{
				ListView lv = this.Template.FindName("PART_List", this) as ListView;
				if (lv.SelectionMode == SelectionMode.Multiple)
				{
					lv.SelectedItems.Clear();
				}
				else
				{
                    lv.SelectedItem = new object();
				}
                lv.SelectedIndex = -1;
			}
		}

        public ListView GetListView()
        {
            return this.Template.FindName("PART_List", this) as ListView;
        }

        public void Filter()
        {
            ListView lv = this.Template.FindName("PART_List", this) as ListView;
            ICollectionView view = CollectionViewSource.GetDefaultView(lv.ItemsSource);
            view.Filter = new Predicate<object>(ApplyFilter);
        }
	}
}
