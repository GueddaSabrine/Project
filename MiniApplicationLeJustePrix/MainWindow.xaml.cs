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

namespace MiniApplicationLeJustePrix
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int lives = 10;
        private int random = 0;
        int essai = 0;
        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            random = rnd.Next(1,50) % 100;
        }

        private void txbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(lives == 0)
            {
                lblForm.Content = "tu as";
                lblTo.Content = "perdu" + essai;
                return;
            }
            if(e.Key == Key.Enter)
            {
                lives--;
                int userGuessed = Int32.Parse(txbInput.Text);
                if (userGuessed == random)
                {
                    lblForm.Content = "tu as";
                    lblTo.Content = "gagné";
                    lblStatus.Content = "tu as réussi au bout de " + essai + " tentatives";
                    return;
                }
                if (userGuessed < random)
                {
                    essai++;
                    lblForm.Content = "trop";
                    lblTo.Content = "petit";
                }
                else
                {
                    essai++;
                    lblForm.Content = "trop";
                    lblTo.Content = "grand";
                }

                lblStatus.Content = "Vies restantes : " + lives;
                if (lives <= 3)
                {
                    lblStatus.Foreground = new SolidColorBrush(Color.FromRgb(255,0,0));
                }
            }
        }
    }
}
