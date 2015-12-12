using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gadgeothek.UI.ViewModel
{
    class AddGadgetModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Gadget Gadget { get; set; }

        public AddGadgetModel()
        {
            Gadget = new Gadget("");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
