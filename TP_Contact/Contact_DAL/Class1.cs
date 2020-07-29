using Contact_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_DAL
{
    public class ServiceContacts
    {
        static readonly string connectionString = @"Data Source=8Z0QFT2\SQLEXPRESS;Initial Catalog=dbContact;Integrated Security=True;Connect Timeout=5";


        public static void SignUp(String username, String password)
        {
            Login newUser = new Login();

            newUser.Username = username;
            newUser.Password = password;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"insert into Utilisateurs(username,password) values (@username,@password)";

                    cmd.Parameters.AddWithValue("@username", newUser.Username);
                    cmd.Parameters.AddWithValue("@password", newUser.Password = password);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public static bool Login(String username, String password)
        {
            Login userIdentification = new Login();

            bool connection = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"select * from Utilisateurs where username=@username and password=@password";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //userIdentification.Id = reader.GetInt32(0);
                            userIdentification.Username = reader.GetString(1);
                            userIdentification.Password = reader.GetString(2);

                            if (username == userIdentification.Username && password == userIdentification.Password)
                            {
                                connection = true;
                            }
                            else
                            {
                                connection = false;
                            }

                        }

                    }

                }
            }

            return connection;
        }

        public static void AjouterUnContact(String prenom, String nom, String cellulaire, String courriel)
        {

            Contacts userContact = new Contacts();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"insert into Contacts(prenom,nom,cellulaire,courriel) values (@prenom,@nom,@cellulaire,@courriel)";

                    cmd.Parameters.AddWithValue("@prenom", prenom);
                    cmd.Parameters.AddWithValue("@nom", nom);

                    if (userContact.Cellulaire != null)
                    {
                        cmd.Parameters.AddWithValue("@cellulaire", cellulaire);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cellulaire", DBNull.Value);
                    }


                    if (userContact.Courriel != null)
                    {
                        cmd.Parameters.AddWithValue("@courriel", courriel);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@courriel", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }



    }














}

