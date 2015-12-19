using ch.hsr.wpf.gadgeothek.domain;
using gadgeothek.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private AddGadgetModel addGadgetModel;
        private Action<Gadget> addGadget;

        internal AddGadgetFormular(Action<Gadget> addGadget)
        {
            this.addGadget = addGadget;
            this.addGadgetModel = new AddGadgetModel();

            InitializeComponent();

            DataContext = addGadgetModel;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            addGadget(addGadgetModel.Gadget);

            this.Close();
        }
    }
}
