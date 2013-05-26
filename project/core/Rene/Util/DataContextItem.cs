using System;
using System.Collections.Generic;
using System.Text;

namespace Rene.Util
{
		public enum ListStyle
		{
			None = 0,
			EditDelete = 1,
			Delete = 3,
			View = 4,
			ViewDelete = 5,
			Select = 6,
			Check = 7,
			SelectCheck = 8,
			EditDeleteView = 9,
			Edit = 10,
			EditDisconnectView = 11,
			DisconnectView = 12,
			Disconnect = 13,
			EditDeleteDisconnectView = 14
		}


		public class DataContextItem
		{
			public DataContextItem(ListStyle ls, object o)
			{
				this.Check = new DataContextItemValue(ListStyleFormat.Check(ls));
				this.View = new DataContextItemValue(ListStyleFormat.View(ls));
				this.Edit = new DataContextItemValue(ListStyleFormat.Edit(ls));
				this.Delete = new DataContextItemValue(ListStyleFormat.Delete(ls));
				this.Select = new DataContextItemValue(ListStyleFormat.Select(ls));
				this.Disconnect = new DataContextItemValue(ListStyleFormat.Disconnect(ls));

				this.DataContext = o;
			}
			public ListStyle ListStyle = ListStyle.None;

			private DataContextItemValue _Disconnect;
			public DataContextItemValue Disconnect
			{
				get { return _Disconnect; }
				set { _Disconnect = value; }
			}

			private DataContextItemValue _Check;
			public DataContextItemValue Check
			{
				get { return _Check; }
				set { _Check = value; }
			}

			private DataContextItemValue _View;
			public DataContextItemValue View
			{
				get { return _View; }
				set { _View = value; }
			}

			private DataContextItemValue _Edit;
			public DataContextItemValue Edit
			{
				get { return _Edit; }
				set { _Edit = value; }
			}

			private DataContextItemValue _Delete;
			public DataContextItemValue Delete
			{
				get { return _Delete; }
				set { _Delete = value; }
			}


			private DataContextItemValue _Select;
			public DataContextItemValue Select
			{
				get { return _Select; }
				set { _Select = value; }
			}
			public object DataContext = new object();
		}

		public class DataContextItemValue
		{
			public DataContextItemValue(bool visible)
			{
				this.Visible = visible;
			}

			private bool _Visible = false;
			public bool Visible
			{
				get { return _Visible; }
				set { _Visible = value; }
			}

			private bool _Enabled = true;
			public bool Enabled
			{
				get { return _Enabled; }
				set { _Enabled = value; }
			}
		}

		public static class ListStyleFormat
		{
			public static bool Disconnect(ListStyle ls)
			{
				return ls == ListStyle.Disconnect ||
					ls == ListStyle.DisconnectView ||
					ls == ListStyle.EditDisconnectView ||
					ls == ListStyle.EditDeleteDisconnectView;
			}

			public static bool Delete(ListStyle ls)
			{
				return ls == ListStyle.EditDelete ||
					ls == ListStyle.Delete ||
					ls == ListStyle.ViewDelete ||
					ls == ListStyle.EditDeleteView ||
					ls == ListStyle.EditDelete ||
					ls == ListStyle.EditDeleteDisconnectView;
			}

			public static bool View(ListStyle ls)
			{
				return ls == ListStyle.ViewDelete ||
					ls == ListStyle.View ||
					ls == ListStyle.EditDeleteView ||
					ls == ListStyle.EditDisconnectView ||
					ls == ListStyle.EditDeleteDisconnectView;
			}
			public static bool Edit(ListStyle ls)
			{
				return ls == ListStyle.Edit ||
					ls == ListStyle.EditDelete ||
					ls == ListStyle.EditDeleteView ||
					ls == ListStyle.EditDisconnectView ||
					ls == ListStyle.EditDeleteDisconnectView;
			}
			public static bool Check(ListStyle ls)
			{
				return ls == ListStyle.Check ||
					ls == ListStyle.SelectCheck;
			}

			public static bool Select(ListStyle ls)
			{
				return ls == ListStyle.SelectCheck ||
					ls == ListStyle.Select;
			}
		}
}
