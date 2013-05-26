using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneData.DataObject;
using System.Collections.ObjectModel;

namespace ReneConsumer.Model
{
    public class Session : Rene.Model.Model
    {
        public Session()
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
        private static User _User;
        public User User
        {
            get
            {

                if (Session._User == null)
                {
                    Session._User = new User();
                }
                return Session._User;
            }
            set { Session._User = value; }
        }

        private static ObservableCollection<User> _Users;
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
