using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ch.hsr.wpf.gadgeothek.domain;
using System.Collections.ObjectModel;
using System.Threading;

namespace gadgeothek.UI.ViewModel
{
    class LoanViewModel : ViewModelBase
    {

        public LoanViewModel()
        {
            Run(refreshLoanList, new TimeSpan(0,0,3));
            Loans = new ObservableCollection<Loan>(Service.GetAllLoans());
        }

        public ObservableCollection<Loan> Loans { get; private set; }
        public async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(period, cancellationToken);
                action();
            }
        }
        private Task Run(Action refreshLoanList, TimeSpan period)
        {
            return Run(refreshLoanList, period, CancellationToken.None);
        }

        private void refreshLoanList()
        {
            Loans.Clear();
            Service.GetAllLoans().ForEach(l => Loans.Add(l));
        }

    }
}
