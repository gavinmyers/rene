using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReneConsumer.Model
{
    public class DirectorModel : Rene.Model.DirectorModel
    {
        public DirectorModel()
        {
        }

        public void Instance(General g)
        {
            this.General = g;
            this.AddEdit.Instance(g);
            this.Session.Instance(g);
            this.Search.Instance(g);
        }

        private General General;

        private AddEdit _AddEdit;
        public AddEdit AddEdit
        {
            get
            {
                if (_AddEdit == null)
                {
                    _AddEdit = new AddEdit();
                }
                return _AddEdit;
            }
            set { _AddEdit = value; }
        }

        private Session _Session;
        public Session Session
        {
            get
            {
                if (_Session == null)
                {
                    _Session = new Session();
                }
                return _Session;
            }
            set { _Session = value; }
        }

        private Search _Search;
        public Search Search
        {
            get
            {
                if (_Search == null)
                {
                    _Search = new Search();
                }
                return _Search;
            }
            set { _Search = value; }
        }

    }
}
