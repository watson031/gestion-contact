using Contact_BLL;
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
                string cou = null;

                if (cellTxtBox.Text.Trim().Length >= 10)
                {
                    cel = cellTxtBox.Text.Trim();
                }
                if (courrielTxtBox.Text.Trim() != "")
                {
                    cou = courrielTxtBox.Text.Trim();
                }
                BLL.(prenomSaisie.Text.Trim(), nomSaisie.Text.Trim(), dom, cel, cou);
                List<Contacts> listeContacts = ContactsManager.GetAllById();
                int[] tab = new int[listeContacts.Count];
                int cpt = 0;
                foreach (Contacts co in listeContacts)
                {
                    tab[cpt] = co.Id;
                }

                Detail.Id = tab[cpt];

                Contact cWindow = new Contact();
                cWindow.Show();
                Close();


            }
            else
            {
                labelErreurMessage.Content = "Le prenom/nom doit comporter au moins 3 caracteres.";
                //labelErreurMessage.Foreground = Brushes.Red;
            }


        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
