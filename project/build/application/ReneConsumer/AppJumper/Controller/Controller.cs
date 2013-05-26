using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneData.Communicator;

namespace ReneConsumer.AppJumper.Controller
{
    public class Controller : Rene.Controller.Controller
    {
        private General General;

        public void Instance(General g)
        {
            this.General = g;
            this.Instance();
        }

        public virtual void Instance()
        {
        }

        public ReneConsumer.Model.DirectorModel M
        {
            get
            {
                return this.General.DirectorModel as ReneConsumer.Model.DirectorModel;
            }
        }

        public ReneConsumer.Event.DirectorEvent E
        {
            get
            {
                return this.General.DirectorEvent as ReneConsumer.Event.DirectorEvent;
            }
        }

        public ReneCommunicatorServiceClient S
        {
            get
            {
                return ReneCommunicator.GetServiceClient();
            }
        }
    }
}
