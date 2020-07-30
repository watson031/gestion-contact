using Contact_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_DAL
{
    public class ServiceDb
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

                    cmd.CommandText = @"insert into Contacts(prenom,nom,telephone,courriel) values (@prenom,@nom,@cellulaire,@courriel)";

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

        public static Contacts RechercheParId(int id)
        {

            Contacts userContact = new Contacts();
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select id, prenom, nom, telephone, courriel
                        from Contacts where id = @id";
                    cmd.Parameters.Add(new SqlParameter("id", id));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userContact.Id = reader.GetInt32(0);
                            userContact.Prenom = reader.GetString(1);
                            userContact.Nom = reader.GetString(2);
                           
                            if (reader.GetValue(4) != DBNull.Value)
                            {
                                userContact.Cellulaire = reader.GetString(4);
                            }
                            else
                            {
                                userContact.Cellulaire = null;
                            }
                            if (reader.GetValue(5) != DBNull.Value)
                            {
                                userContact.Courriel = reader.GetString(5);
                            }
                            else
                            {
                                userContact.Courriel = null;
                            }
                           

                        }
                    }
                }
            }
            return userContact;
        }


        public static void SupprimerUnContact(int id)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"delete from Contacts where id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static List<Contacts> ShowAllContacts()
        {

            List<Contacts> contacts = new List<Contacts>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from Contacts order by nom asc";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contacts userContacts = new Contacts();
                            userContacts.Id = reader.GetInt32(0);
                            userContacts.Prenom = reader.GetString(1);
                            userContacts.Nom = reader.GetString(2);
                            
                            if (reader.GetValue(4) != DBNull.Value)
                            {
                                userContacts.Cellulaire = reader.GetString(4);
                            }
                            else
                            {
                                userContacts.Cellulaire = null;
                            }
                            if (reader.GetValue(5) != DBNull.Value)
                            {
                                userContacts.Courriel = reader.GetString(5);
                            }
                            else
                            {
                                userContacts.Courriel = null;
                            }
                            contacts.Add(userContacts);
                        }
                    }
                }
            }
            return contacts;
        }


        public static List<Contacts> RechercheParPrenom(string prenom)
        {

            List<Contacts> contacts = new List<Contacts>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select id, prenom, nom, cellulaire, courriel
                        from Contacts where prenom like @prenom + '%' OR nom like @prenom + '%' order by nom asc";
                    cmd.Parameters.Add(new SqlParameter("prenom", prenom));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contacts userContacts = new Contacts();
                            userContacts.Id = reader.GetInt32(0);
                            userContacts.Prenom = reader.GetString(1);
                            userContacts.Nom = reader.GetString(2);
                            
                            if (reader.GetValue(4) != DBNull.Value)
                            {
                                userContacts.Cellulaire = reader.GetString(4);
                            }
                            else
                            {
                                userContacts.Cellulaire = null;
                            }
                            if (reader.GetValue(5) != DBNull.Value)
                            {
                                userContacts.Courriel = reader.GetString(5);
                            }
                            else
                            {
                                userContacts.Courriel = null;
                            }
                            contacts.Add(userContacts);
                        }
                    }
                }
            }
            return contacts;
        }


        public static void ModifierUnContact(int id, string prenom, string nom, string cellulaire, string courriel)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"update Contacts Set prenom = @prenom, nom = @nom, cellulaire = @cellulaire, courriel = @courriel where id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@prenom", prenom);
                    cmd.Parameters.AddWithValue("@nom", nom);

                    if (cellulaire != null)
                    {
                        cmd.Parameters.AddWithValue("@cellulaire", cellulaire);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cellulaire", DBNull.Value);
                    }

                    if (courriel != null)
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


        public static int RechercheParUsername(string username)
        {
            int idUser;
           // Login idLogin = new Login();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select id
                        from Utilisateurs where username = @username";
                    cmd.Parameters.Add(new SqlParameter("username", username));

                    object idRecherche = cmd.ExecuteScalar();

                    idUser = (int) idRecherche;

                    /*using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idLogin.Id = reader.GetInt32(0);
                            
                        }
                    }*/
                }
            }
            return idUser;
        }



    }














}

