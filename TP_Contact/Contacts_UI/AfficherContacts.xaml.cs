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
        public AfficherContacts()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            AjouterContacts fenetreAjout = new AjouterContacts();
            fenetreAjout.Show();
            this.Close();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            //***********
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            //***********
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void btnAffichage_Click(object sender, RoutedEventArgs e)
        {
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
                this.listBxContacts.Items.Add("Vous n'avez de Contacts");
            }



        }
    }
}
