﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contact_DAL;
using Contact_Model;

//Fichier Test
//Fichier à supprimer de l'assembly

namespace SolutionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test d'ajout d'utilisateurs dans la base de données

            Login util = new Login();
            /*// util.Id = 15;
            util.Password = "ecole";
            util.Username = "etudiant";

            ServiceContacts.SignUp("etudiant", "ecole");*/

            Login util2 = new Login();

            /*util.Password = "waugusti";
            util.Username = "waugusti123";

            ServiceContacts.SignUp(util.Username, util.Password);*/

            /*Console.WriteLine(ServiceDb.RechercheParUsername("waugusti"));
            Thread.Sleep(100);*/

        }
    }
}
