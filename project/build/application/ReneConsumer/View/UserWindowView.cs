using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneData.DataObject;

namespace ReneConsumer.View
{
    public class UserWindowView : WindowView
    {
        public UserWindowView()
        {
        }

        public UserWindowView(User u)
        {
            M.AddEdit.User = u;
            this.DataContext = M;
        }

    }
}
