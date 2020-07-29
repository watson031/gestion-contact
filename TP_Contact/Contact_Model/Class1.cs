using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Model
{
    public class Contacts
    {
        public int Id { get;}
        public int IdUsers { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Cellulaire { get; set; }
        public string Courriel { get; set; }

    }
    
    public class Login
    {
        public int Id { get;}
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
