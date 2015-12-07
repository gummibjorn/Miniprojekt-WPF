using ch.hsr.wpf.gadgeothek.domain;
using gadgeothek.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gadgeothek.UI.Views
{
    /// <summary>
    /// Interaction logic for DeletionDialogGadget.xaml
    /// </summary>
    public partial class DeletionDialogGadget : Window
    {
        private GadgetViewModel gadgetViewModel;
        private Gadget toDelete;
        public DeletionDialogGadget()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void continueDeleteGadget_Click(object sender, RoutedEventArgs e)
        {
            gadgetViewModel.DeleteGadget(toDelete);
            this.Close();
        }
        private void cancelDeleteGadget_Click(object sender, RoutedEventArgs e)
        {
            gadgetViewModel.DeleteGadget(toDelete);
            this.Close();
        }
        public Gadget ToDelete
        {
            get { return toDelete; }
            set { toDelete = value; }
        }
         
        internal GadgetViewModel GadgetViewModel
        {
            get { return gadgetViewModel; }
            set { gadgetViewModel = value; }
        }
    }
}
