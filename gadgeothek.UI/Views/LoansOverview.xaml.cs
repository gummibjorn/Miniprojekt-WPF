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
    /// Interaction logic for LoansOverview.xaml
    /// </summary>
    public partial class LoansOverview : UserControl
    {
        public LoansOverview()
        {
            InitializeComponent();
            DataContext = new LoanViewModel();
        }
    }
}
