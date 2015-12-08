using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows.Data;
using System.Threading;
using System.Windows.Threading;

namespace gadgeothek.UI.ViewModel
{
    class GadgetViewModel : ViewModelBase
    {

        public GadgetViewModel()
        {
            Gadgets = new ObservableCollection<Gadget>(Service.GetAllGadgets());
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += refreshGadgetList;
            timer.Start();
        }


        public void addGadget(String name, Double price, String Manufacturer)
        {
            Gadget gadget = new Gadget(name);
            gadget.Price = price;
            gadget.Manufacturer = Manufacturer;
            Service.AddGadget(gadget);
        }

        internal void DeleteGadget(Gadget toDelete)
        {
            Gadgets.Remove(toDelete);
            Service.DeleteGadget(toDelete);
        }

        private void refreshGadgetList(object sender, EventArgs e)
        {
            Gadgets.Clear();
            Service.GetAllGadgets().ForEach(g=>Gadgets.Add(g));
        }
        public ObservableCollection<Gadget> Gadgets { get; private set; }
    }
}
