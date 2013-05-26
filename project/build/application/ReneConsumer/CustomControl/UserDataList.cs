using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Rene.CustomControl;
using ReneConsumer.Event;
using ReneConsumer.Model;
using ReneData.DataObject;
using System.Collections.ObjectModel;
using System.Windows;
using ReneConsumer.View;
using System.IO;

namespace ReneConsumer.CustomControl
{
	public class UserDataList : ReneConsumer.CustomControl.DataList
	{
   
		public UserDataList()
		{
            this.Loaded +=new RoutedEventHandler(UserDataList_Loaded);
		}

        void UserDataList_Loaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            this.SelectionChanged += new SelectionChangedEventHandler(UserDataList_SelectionChanged);

            this.ItemsSource = M.Search.Users;
            this.Edit += new System.Windows.Input.ExecutedRoutedEventHandler(UserDataList_Edit);
            this.Add += new System.Windows.Input.ExecutedRoutedEventHandler(UserDataList_Add);
            this.Delete += new System.Windows.Input.ExecutedRoutedEventHandler(UserDataList_Delete);

            this.Upload += new System.Windows.Input.ExecutedRoutedEventHandler(UserDataList_Upload);
        }

        void UserDataList_Upload(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            FileStream fs = new FileStream("..\\..\\..\\ReneClientUploads\\file.jpg", FileMode.Open);
            M.AddEdit.Uploads.Clear();
            M.AddEdit.Uploads.Add(fs);
            E.RaiseEvent("UploadFiles");
        }

        void UserDataList_Delete(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            E.RaiseEvent("DeleteUser");
        }

        void UserDataList_Add(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            UserWindowView uv = new UserWindowView(M.AddEdit.User);
            uv.ShowDetached();
        }

        void UserDataList_Edit(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            UserWindowView uv = new UserWindowView(M.AddEdit.User);
            uv.ShowDetached();
        }


        #region SelectionChangedHandler

        void UserDataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            M.AddEdit.Users.Clear();

			ListView lv = e.OriginalSource as ListView;
			if (lv == null)
			{
				return;
			}
			if (this.SelectionMode == SelectionMode.Multiple)
			{
				foreach (User s in lv.SelectedItems)
				{
					M.AddEdit.Users.Add(s);
                    M.AddEdit.User = lv.SelectedValue as User;
				}
			}
			else
			{
                M.AddEdit.User = lv.SelectedValue as User;
			}

        }
        #endregion





    }
}
