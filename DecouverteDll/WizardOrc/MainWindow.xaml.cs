using ClassLibrary1;
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

namespace WizardOrc
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Wizard wizard;
        Orc orc;
        public MainWindow()
        {
            InitializeComponent();
            orc = new Orc(1000, 0, 5, name.Text);
            health.Text = orc.health.ToString();
            wizard = new Wizard(500, 250, 7, nameW.Text);
            healthW.Text = wizard.health.ToString();
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void health_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void message_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            orc.name = name.Text;
            messageW.Text = orc.SendMessage(message.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            wizard.Fire();
            healthW.Text = wizard.health.ToString();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            wizard.name = nameW.Text;
            message.Text = wizard.SendMessage(messageW.Text);

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            orc.Kick();
            health.Text = orc.health.ToString();
        }
    }
}
