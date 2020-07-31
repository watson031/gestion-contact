using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Model;
using Contact_DAL;

namespace Contact_BLL
{
    public class BLL
    {
        public static int idLogin;


        public static bool Login(String username, String password)
        {
            return ServiceDb.Login(username, password);
        }

        public static void Inscription(String username, String password)
        {
            ServiceDb.SignUp(username, password);
        }

        public static void AjouterUnContact(String prenom, String nom, String cellulaire, String courriel,int idUtilisateurs)
        {
            ServiceDb.AjouterUnContact(prenom, nom, cellulaire, courriel, idUtilisateurs);
        }

        public static Contacts RechercheParId(int id)
        {
            return ServiceDb.RechercheParId(id);
        }

        public static void SupprimerUnContact(int id)
        {
            ServiceDb.SupprimerUnContact(id);
        }

        public static List<Contacts> ShowAllContacts()
        {
            return ServiceDb.ShowAllContacts();
        }

        public static List<Contacts> RechercheParPrenom(string prenom)
        {
            return ServiceDb.RechercheParPrenom(prenom);
        }

        public static void ModifierUnContact(int id, string prenom, string nom, string cellulaire, string courriel)
        {
            ServiceDb.ModifierUnContact(id, prenom, nom, cellulaire, courriel);
        }


        public static int RechercheParUsername(string username)
        {
            return ServiceDb.RechercheParUsername(username);
        }

        public static List<Contacts> ShowAllContactsByUserId(int idUser)
        {
            return ServiceDb.ShowAllContactsByUserId(idUser);
        }


    }
}
