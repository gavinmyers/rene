using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows;
using ReneGameLogic.Sprite;

namespace ReneData.DataObject
{
    [Serializable]
    [DataContract]
    public class Tank : Rene.DataObject.DataObject
    {
        public Tank()
        {
        }


        private InteractiveElement _InteractiveElement;
        public InteractiveElement InteractiveElement
        {
            get { return _InteractiveElement; }
            set { _InteractiveElement = value; OnPropertyChanged("InteractiveElement"); }
        }
        
    }
}
