using Contact_Model;
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
using System.Windows.Shapes;
using Contact_BLL;

namespace Contacts_UI
{
    /// <summary>
    /// Interaction logic for AfficherContacts.xaml
    /// </summary>
    public partial class AfficherContacts : Window
    {
        public Contacts contact;
        public static int idAModifier;
        public AfficherContacts()
        {
            InitializeComponent();
            this.contact = new Contacts();
            //this.listBxContacts.Items.Add("Appuyez sur \"Afficher vos contacts\" pour les\n afficher");
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            AjouterContacts fenetreAjout = new AjouterContacts();
            fenetreAjout.Show();
            this.Close();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBxContacts.SelectedItem != null)
            {

                var result = MessageBox.Show("Voulez-Vous Vraiment Modifier ce contact", "Modifier", MessageBoxButton.YesNo, MessageBoxImage.Question);

                //Contacts contact = new Contacts();

                if (result == MessageBoxResult.Yes)
                {
                    idAModifier = ((Contacts)this.listBxContacts.SelectedItem).Id;
                    contact.Prenom = ((Contacts)this.listBxContacts.SelectedItem).Prenom;
                    contact.Nom = ((Contacts)this.listBxContacts.SelectedItem).Nom;
                    contact.Cellulaire = ((Contacts)this.listBxContacts.SelectedItem).Cellulaire;
                    contact.Courriel = ((Contacts)this.listBxContacts.SelectedItem).Courriel;




                    ModifierContacts fenetreModif = new ModifierContacts(this);
                    this.Close();
                    fenetreModif.Show();



                }



            }
            else
            {
                this.LblAucunChoix.Content = "Selectionnez un contact avant de modifier";
            }

        }



        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBxContacts.SelectedItem != null)
            {

                var result = MessageBox.Show("Voulez-Vous Vraiment Supprimer ce contact", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Question);

                Contacts contact = new Contacts();
                int idContact = ((Contacts)this.listBxContacts.SelectedItem).Id;

                if (result == MessageBoxResult.Yes)
                {
                    BLL.SupprimerUnContact(idContact);

                    this.listBxContacts.Items.Clear();
                    List<Contacts> list = new List<Contacts>();
                    list = BLL.ShowAllContactsByUserId(BLL.idLogin);

                    if (list.Count > 0)
                    {
                        foreach (Contacts contacts in list)
                        {
                            this.listBxContacts.Items.Add(contacts);
                        }

                    }
                    else
                    {
                        this.listBxContacts.Items.Add("Vous n'avez plus de Contacts");
                    }

                    this.LblAucunChoix.Content = "";

                }
                
            }
            else
            {
                this.LblAucunChoix.Content = "Selectionnez un contact avant de supprimer";
            }

           
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void btnAffichage_Click(object sender, RoutedEventArgs e)
        {
            this.LblAucunChoix.Content = "";
            this.listBxContacts.Items.Clear();
            List<Contacts> list = new List<Contacts>();
            list = BLL.ShowAllContactsByUserId(BLL.idLogin);

            if (list.Count > 0)
            {
                foreach (Contacts contacts in list)
                {
                    this.listBxContacts.Items.Add(contacts);
                }

            }
            else
            {
                this.listBxContacts.Items.Add("Vous n'avez pas de Contacts");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBoxRecherche.Text.Trim().Length != 0)
            {

                this.LblAucunChoix.Content = "";
                this.listBxContacts.Items.Clear();
                List<Contacts> list = new List<Contacts>();
                list = BLL.RechercheParPrenom(this.textBoxRecherche.Text.Trim(), BLL.idLogin);

                if (list.Count > 0)
                {
                    foreach (Contacts contacts in list)
                    {
                        this.listBxContacts.Items.Add(contacts);
                    }

                }
                else
                {
                    this.LblAucunChoix.Content ="Aucun Contact trouvé pour le nom entré";
                }
                // BLL.RechercheParPrenom(this.textBoxRecherche.Text.Trim());
            }

            else
            {
                this.LblAucunChoix.Content = "Saisir un nom à rechercher";
            }

        }
    }
}
