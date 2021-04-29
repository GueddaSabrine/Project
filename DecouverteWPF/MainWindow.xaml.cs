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

namespace DecouverteWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string name { get; set; } = "Entrez votre nom";
        //private string name = "";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void msg_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World");
        } //exo2p1

        private void NameInputButton_Click(object sender, RoutedEventArgs e)
        {
            name = messageText.Text;
            NameLabel.Content = $"Bonjour {name.ToString()}";
        } //exo3p1

        private void NameInputButton_Click1(object sender, RoutedEventArgs e)
        {
            name = messageText.Text;
            MessageBox.Show("Bonjour"+" "+(messageText1.Text));
        } //exo4p1
    }
}
