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
        public static bool Login(String username, String password)
        {
            return ServiceDb.Login(username, password);
        }

        public static void Inscription(String username, String password)
        {
            ServiceDb.SignUp(username, password);
        }

    }
}
