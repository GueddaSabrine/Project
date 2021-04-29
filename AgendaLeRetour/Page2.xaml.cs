using AgendaLeRetour.Models;
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

namespace AgendaLeRetour
{
    /// <summary>
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            AgendaCourtierEntities db = new AgendaCourtierEntities();
            var client = from c in db.Customers
                         select c;
            this.ListCustomers.ItemsSource = client.ToList();
        }

        private void ListCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
