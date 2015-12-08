using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ch.hsr.wpf.gadgeothek.domain;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;

namespace gadgeothek.UI.ViewModel
{
    class LoanViewModel : ViewModelBase
    {

        public LoanViewModel()
        {
            Loans = new ObservableCollection<Loan>(Service.GetAllLoans());
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += refreshLoanList;
            timer.Start();
        }

        public ObservableCollection<Loan> Loans { get; private set; }

        private void refreshLoanList(object sender, EventArgs e)
        {
            Loans.Clear();
            Service.GetAllLoans().ForEach(l => Loans.Add(l));
        }

    }
}
