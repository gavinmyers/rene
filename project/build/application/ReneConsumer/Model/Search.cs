using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ReneData.DataObject;

namespace ReneConsumer.Model
{
    public class Search
    {
        public Search()
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
    }
}
