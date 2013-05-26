using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ReneData.DataObject;
using Rene.Model;
using System.IO;

namespace ReneConsumer.Model
{
    public class AddEdit : Rene.Model.Model
    {
        public AddEdit()
        {
        }

        private General General;
        public void Instance(General g)
        {
            this.General = g;
        }


        /**********************
            USER
        ***********************/
        private User _User;
        public User User
        {
            get
            {
                if (_User == null)
                {
                    _User = new User();
                }
                return _User;
            }
            set { _User = value; }
        }
        private ObservableCollection<User> _Users;
        public ObservableCollection<User> Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new ObservableCollection<User>();
                }
                return _Users;
            }
            set { _Users = value; }
        }



        /**********************
            Upload
        ***********************/
        private FileStream _Upload;
        public FileStream Upload
        {
            get { return _Upload; }
            set { _Upload = value; }
        }
        private ObservableCollection<FileStream> _Uploads;
        public ObservableCollection<FileStream> Uploads
        {
            get
            {
                if (_Uploads == null)
                {
                    _Uploads = new ObservableCollection<FileStream>();
                }
                return _Uploads;
            }
            set { _Uploads = value; }
        }

    }
}
