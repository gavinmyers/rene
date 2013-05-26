using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReneConsumer
{
    public class General : Rene.General
    {
        public General()
        {
            DirectorModel.Instance(this);
            DirectorController.Instance(this);
        }

        public ReneConsumer.Event.DirectorEvent DirectorEvent = new ReneConsumer.Event.DirectorEvent();
        public ReneConsumer.Model.DirectorModel DirectorModel = new ReneConsumer.Model.DirectorModel();
        public ReneConsumer.Controller.DirectorController DirectorController = new ReneConsumer.Controller.DirectorController();
    }
}
