using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ch.hsr.wpf.gadgeothek.service;

namespace gadgeothek.UI.ViewModel
{
    class ViewModelBase
    {
        public ViewModelBase()
        {
            Service = new LibraryAdminService("http://localhost:8080");
        }

        public LibraryAdminService Service { get; private set; }
    }
}
