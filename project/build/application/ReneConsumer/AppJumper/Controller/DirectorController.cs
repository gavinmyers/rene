using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReneConsumer.Controller
{
    public class DirectorController : Rene.Controller.DirectorController
    {
        public DirectorController()
        {
        }

        private General General;
        public void Instance(General g)
        {
            this.General = g;
            this.Controller.Instance(g);
        }

        public Controller Controller = new Controller();
    }
}
