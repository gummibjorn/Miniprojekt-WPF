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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gadgeothek.UI.Views
{
    /// <summary>
    /// Interaction logic for GadgetOverview.xaml
    /// </summary>
    public partial class GadgetOverview : UserControl
    {
        private GadgetViewModel gadgetViewModel;

        public GadgetOverview()
        {
            InitializeComponent();
            gadgetViewModel = new GadgetViewModel();
            DataContext = gadgetViewModel;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var addForm = new AddGadgetFormular(g => gadgetViewModel.addGadget(g));

            addForm.Show();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Gadget toDelete = (Gadget)gadgetGrid.SelectedItem;
            var messageBox = MessageBox.Show("Are you sure to delete " + toDelete.Name + "?", "Delete confirmation", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes==messageBox)
            {
                gadgetViewModel.DeleteGadget(toDelete);
            }
        }
    }
}
