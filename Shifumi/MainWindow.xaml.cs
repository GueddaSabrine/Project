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

namespace Shifumi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string userChoice = ""; // Déclaration de mes variables et de leurs valeurs
        string paper = "papier";
        string stone = "pierre";
        string cutter = "ciseau";
        int userVictory = 0; // On commence à 0 pour indiquer que l'on commence une nouvelle partie
        int userDefeat = 0;
        int userSame = 0;
        int totalGame = 0;

        private void Play_Click(object sender, RoutedEventArgs e)
        {

            string resultat = resultTextBlock.Text;  //Pour afficher mes résultats dans mes textblocs
            string stats = statsTextBlock.Text; // Mes stats
            string percents = percentsTextBlock.Text; // Mon pourcentage de victoires
            Random rnd = new Random(); // Génération d'une valeur prédéfinie au hasard
            string[] iaChoices = { "pierre", "feuille", "ciseau" };
            int choiceComputer = rnd.Next(iaChoices.Length); // Le choiceComputeur correspond à l'index de mon tableau

            if (userChoice == "") // Si l'utilisateur ne rentre aucunes données
            {
                MessageBox.Show("Erreur, merci de sélectionner un des trois éléments ci-dessus");
            }
            else
            {
                totalGame++;
                if (userChoice == paper && iaChoices[choiceComputer] == stone || userChoice == stone && iaChoices[choiceComputer] == cutter || userChoice == cutter && iaChoices[choiceComputer] == paper)
                {
                    resultTextBlock.Text = "Gagné, tu as choisis : " + userChoice + " , et la machine : " + iaChoices[choiceComputer];
                    userVictory++; // Ajouter les victoires pour les compter
                     // Permet d'incrémenter mon total de parties pour calculer le % de victoires par la suite
                }
                else if (userChoice == iaChoices[choiceComputer])
                {
                    resultTextBlock.Text = "Egalité, tu as choisis : " + userChoice + " , et la machine : " + iaChoices[choiceComputer];
                    userSame++; // Ajouter les égalités pour les compter
                    
                }
                else
                {
                    resultTextBlock.Text = "Perdu, tu as choisis : " + userChoice + " , et la machine : " + iaChoices[choiceComputer];
                    userDefeat++; // Ajouter les défaites pour les compter
                    
                }
                statsTextBlock.Text = "Nombre de victoire(s) : " + userVictory + " , Nombre de défaite(s) : " + userDefeat + " , Nombre d'égalité(s) : " + userSame + ".";
                counterTextBlock.Text = totalGame.ToString(); // Affichage dans mes textblocks de mes données receuillies au dessus
                percentsTextBlock.Text = "Pourcentage de victoire(s) : " + 100 * userVictory / totalGame + " %";

            }

        }

        private void Stone_Click(object sender, RoutedEventArgs e) // Méthode pour enregistrer la valeur au clique de l'élément sélectionné
        {
            userChoice = stone; // Lors du clique sur la pierre, la valeur sera stockée dans la variable userChoice
        }

        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            userChoice = paper;
        }

        private void Cutter_Click(object sender, RoutedEventArgs e)
        {
            userChoice = cutter;
        }

    }
}
