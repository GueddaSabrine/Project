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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AgendaCourtierEntities db = new AgendaCourtierEntities();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Naviguer.Content = new Page1();
        }

        private void Liste_Click(object sender, RoutedEventArgs e)
        {
            Naviguer.Content = new Page2();
        }
    }
}
