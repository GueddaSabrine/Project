using AgendaLeRetour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        //Déclaration des regex
        string regexMail = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        string regexPhone = @"^((\+)33|0)[1-9](\d{2}){4}$"; //numéro telephone avec +33 ou 06 !!
        //string regexPhone = @"^[0][0-9]{9}" //numéro télephone avec 06 !!

        AgendaCourtierEntities db = new AgendaCourtierEntities();

        public Page1()
        {
            InitializeComponent();
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            //Déclaration du booléen qui permettra la validation du formulaire ou non
            bool isValid = true;

            //Vérification permettant de vérifier si l'input est vide ou non
            if (!String.IsNullOrEmpty(txtFirstname.Text))
            {
                //Initialisation du booléen isValid à false
                isValid = false;
                //Affichage du message d'erreur dans le textblock correspondant
                textErrorFirstname.Text = "Caractères non valides.";
                //Apparition du message d'erreur
                textErrorFirstname.Visibility = Visibility;
            }
            //Si le champ est vide, affichage d'un message d'erreur et initialisation du booléen isValid à false
            else
            {
                isValid = false;
                textErrorFirstname.Text = "Le champ est vide";
                textErrorFirstname.Visibility = Visibility;
            }


            if (!String.IsNullOrEmpty(txtLastname.Text))
            {
                isValid = false;
                textErrorFirstname.Text = "Caractères non valides.";
                textErrorFirstname.Visibility = Visibility;
            }
            else
            {
                isValid = false;
                textErrorFirstname.Text = "Le champ est vide";
                textErrorFirstname.Visibility = Visibility;
            }


            if (!String.IsNullOrEmpty(txtMail.Text))
            {
                if (!Regex.IsMatch(txtMail.Text, regexMail))
                {
                    isValid = false;
                    textErrorMail.Text = "Caractères non valides";
                    textErrorMail.Visibility = Visibility;
                }
            }
            else
            {
                isValid = false;
                textErrorMail.Text = "Le champ est vide";
                textErrorMail.Visibility = Visibility;
            }


            if (!String.IsNullOrEmpty(txtPhone.Text))
            {
                //Vérification permettant de vérifier si la valeur saisie dans l'input match avec la regex
                if (!Regex.IsMatch(txtPhone.Text, regexPhone))
                {
                    isValid = false;
                    textErrorMail.Text = "Caractères non valides";
                    textErrorMail.Visibility = Visibility;
                }
            }
            else
            {
                isValid = false;
                textErrorMail.Text = "Le champ est vide";
                textErrorMail.Visibility = Visibility;
            }


            if (String.IsNullOrEmpty(txtBudget.Text))
            {
                isValid = false;
                textErrorBudget.Text = "Le champ est vide";
                textErrorBudget.Visibility = Visibility;
            }



            //Déclaration de la variable mailAlreadyUsed qui stockera la valeur de la recherche permettant de vérifier si l'adresse mail utilisée dans le mailTextBox est déjà présente dans la base de données
            var mailAlreadyUsed = db.Customers.Where(x => x.mail == txtMail.Text).FirstOrDefault();
            //Si le résultat de la recherche est null, poursuite de la validation du formulaire
            if (mailAlreadyUsed == null)
            {
                //Si isValid est true
                if (isValid)
                {
                    //Instantiation de la table customers et déclaration de l'objet addCustomer
                    /* Models.customer addCustomer = new Models.customer()
                     {
                         //Liaison de chaques colonnes de la table customers aux textBox
                         lastname = lastnameTextBox.Text,
                         firstname = firstnameTextBox.Text,
                         mail = mailBextBox.Text,
                         phoneNumber = telTextBox.Text,
                         budget = int.Parse(budgetTextBox.Text)
                     };*/

                    Customers customer = new Customers()
                    {
                        lastname = txtLastname.Text,
                        firstname = txtFirstname.Text,
                        mail = txtMail.Text,
                        phoneNumber = txtPhone.Text,
                        budget = Int32.Parse(txtBudget.Text)
                    };

                    //Ajout d'un client en base de données
                    db.Customers.Add(customer);
                    //Sauvegarde des modifications apportées
                    db.SaveChanges();
                    //Affichage du message de succès
                    textSuccessAdd.Visibility = Visibility;
                    //Page1 ===> Page2
                    this.NavigationService.Navigate(new Uri("Page2.xaml", UriKind.Relative));
                }
                //Affichage du message d'erreur si l'adresse mail est déjà utilisée
            }
            /*else
            {
                isValid = false;
                textMailAlreadyUsed.Visibility = Visibility;
            }*/


            /*Customers customer = new Customers()
            {
                lastname = txtLastname.Text,
                firstname = txtFirstname.Text,
                mail = txtMail.Text,
                phoneNumber = txtPhone.Text,
                budget = Int32.Parse(txtBudget.Text)
            };
                db.Customers.Add(customer);
                db.SaveChanges();
                MessageBox.Show("Client ajouté");
                this.NavigationService.Navigate(new Uri("Page2.xaml", UriKind.Relative));*/
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            txtLastname.Text = "";
            txtFirstname.Text = "";
            txtMail.Text = "";
            txtPhone.Text = "";
            txtBudget.Text = "";

            MessageBox.Show("Client NON ajouté");
            //this.NavigationService.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }
    }
}
