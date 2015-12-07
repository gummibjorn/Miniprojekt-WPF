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
    /// Interaction logic for AddGadgetFormular.xaml
    /// </summary>
    public partial class AddGadgetFormular : Window
    {
        private GadgetViewModel gadgetViewModel;

        public AddGadgetFormular()
        {
            InitializeComponent();
            DataContext = gadgetViewModel;
        }
        internal GadgetViewModel GadgetViewModel
        {
            get
            {
                return gadgetViewModel;
            }

            set
            {
                gadgetViewModel = value;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            gadgetViewModel.addGadget(gadgetName.Text, Convert.ToDouble(gadgetPrice.Text), gadgetManufacturer.Text);
            this.Close();
        }
    }
}
