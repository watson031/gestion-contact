using Contact_BLL;
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

namespace Contacts_UI
{
    /// <summary>
    /// Interaction logic for AjouterContacts.xaml
    /// </summary>
    public partial class AjouterContacts : Window
    {
        
        public AjouterContacts()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {

            if (prenomTxtBox.Text.Trim().Length >= 3 && nomTxtBox.Text.Trim().Length >= 3)
            {

                string cel = null;
                string courriel = null;

                if (cellTxtBox.Text.Trim().Length >= 10)
                {
                    cel = cellTxtBox.Text.Trim();
                }
                if (courrielTxtBox.Text.Trim() != "")
                {
                    courriel = courrielTxtBox.Text.Trim();
                }


                BLL.AjouterUnContact(prenomTxtBox.Text.Trim(), nomTxtBox.Text.Trim(), cel, courriel,BLL.idLogin);
                this.prenomTxtBox.Text = "";
                this.nomTxtBox.Text = "";
                this.cellTxtBox.Text = "";
                this.courrielTxtBox.Text = "";
                
            }
            else
            {
                labelErreurMessage.Content = "Le prenom/nom doit comporter au moins 3 caracteres.";
                //labelErreurMessage.Foreground = Brushes.Red;
            }

        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            AfficherContacts fenetreCont = new AfficherContacts();
            fenetreCont.Show();
            this.Close();
        }
    }
}
