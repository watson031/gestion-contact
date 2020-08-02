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
    /// Interaction logic for Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        public Inscription()
        {
            InitializeComponent();
        }

        private void btnInscrire_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTxtbox.Text.Trim().Length >= 3 && passwordInscription.Password.Trim().Length >= 3 
                && passwordTxtbox_Confirm.Password.Trim().Length >= 3)
            {
                if (passwordInscription.Password.Trim() == passwordTxtbox_Confirm.Password.Trim())
                {
                    BLL.Inscription(usernameTxtbox.Text.Trim(), passwordInscription.Password.Trim());
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();

                }
                else
                {
                    this.lbl_MessageErreur.Content = "Le mot de passe doit être identique";
                }



            }
            else
            {
                this.lbl_MessageErreur.Content = "Les champs doit contenir plus que 3 caractères";
            }


        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fenetreConnexion = new MainWindow();
            fenetreConnexion.Show();
            Close();
        }
    }
}
