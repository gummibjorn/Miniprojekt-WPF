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

namespace gadgeothek.UI.ViewModel
{
    class GadgetViewModel : ViewModelBase
    {
        public ObservableCollection<Gadget> Gadgets { get; private set; }

        public GadgetViewModel()
        {
            Run(refreshGadgetList, new TimeSpan(0, 0, 3));
            Gadgets = new ObservableCollection<Gadget>(Service.GetAllGadgets());
        }

        public void addGadget(String name, Double price, String Manufacturer)
        {
            Gadget gadget = new Gadget(name);
            gadget.Price = price;
            gadget.Manufacturer = Manufacturer;
            Service.AddGadget(gadget);
        }

        public void addGadget(Gadget gadget)
        {
            Service.AddGadget(gadget);
        }

        public async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(period, cancellationToken);
                action();
            }
        }

        internal void DeleteGadget(Gadget toDelete)
        {
            Service.DeleteGadget(toDelete);
        }

        private Task Run(Action refreshGadgetList, TimeSpan period)
        {
            return Run(refreshGadgetList, period, CancellationToken.None);
        }

        private void refreshGadgetList()
        {
            Gadgets.Clear();
            Service.GetAllGadgets().ForEach(g => Gadgets.Add(g));
        }
    }
}

