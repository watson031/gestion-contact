﻿using System;
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
using Contact_BLL;
using Contact_Model;


namespace Contacts_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInscription_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnConnection_Click(object sender, RoutedEventArgs e)
        {

            if (BLL.Login(this.usernameTxtbox.Text, this.passwordTxtbox.Password))
            {
                
            }
            else
            {
                
            }

        }
    }
}
