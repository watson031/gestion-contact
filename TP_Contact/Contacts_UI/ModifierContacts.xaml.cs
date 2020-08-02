using Contact_BLL;
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
using System.Windows.Shapes;

namespace Contacts_UI
{
    /// <summary>
    /// Interaction logic for ModifierContacts.xaml
    /// </summary>
    public partial class ModifierContacts : Window
    {
        AfficherContacts afficher;
        public ModifierContacts(AfficherContacts afficher)
        {
            InitializeComponent();
            this.afficher = afficher;

            this.prenomTxtBox.Text = afficher.contact.Prenom;
            this.nomTxtBox.Text = afficher.contact.Nom;

            this.cellTxtBox.Text = afficher.contact.Cellulaire;
            this.courrielTxtBox.Text = afficher.contact.Courriel;

        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            string cel = null;
            string courriel = null;


            if (cellTxtBox.Text.Trim().Length >= 10 && Regex.Match(cellTxtBox.Text.Trim(), @"^\(\d{3}\)\d{3}-\d{4}$").Success)
            {
                cel = cellTxtBox.Text.Trim();
            }

            if (courrielTxtBox.Text.Trim().Length >= 10 && courrielTxtBox.Text.Trim().Contains("@"))
            {
                courriel = courrielTxtBox.Text.Trim();
            }

            BLL.ModifierUnContact(AfficherContacts.idAModifier, this.prenomTxtBox.Text, this.nomTxtBox.Text, cel, courriel);

            this.prenomTxtBox.Text = "";
            this.nomTxtBox.Text = "";

            this.cellTxtBox.Text = "";
            this.courrielTxtBox.Text = "";

        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            AfficherContacts afficher = new AfficherContacts();
            afficher.Show();
            this.Close();

        }
    }
}
