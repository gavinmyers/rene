using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Runtime.InteropServices;
using WinInterop = System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Controls;
using ReneData.Communicator;

namespace ReneConsumer.View
{
    public class ControlView : Rene.View.ControlView
    {

        public ControlView()
        {
            ReneCommunicator.ReneCommunicatorBridge.BroadcastReceived += new ReneCommunicatorBridge.BroadcastReceivedHandler(ReneCommunicatorBridge_BroadcastReceived);
        }

        void ReneCommunicatorBridge_BroadcastReceived(ReneCommunicatorBroadcast rcb, EventArgs e)
        {
            E.RaiseEvent(rcb.Event, rcb.Data);
        }

        public General General = new ReneConsumer.General();



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

    }
}
