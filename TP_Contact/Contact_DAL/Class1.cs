using Contact_Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_DAL
{
    public class ServiceDb
    {
        static readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


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

        public static void AjouterUnContact(String prenom, String nom, String cellulaire, String courriel, int Id_utilisateurs)
        {

            Contacts userContact = new Contacts();
            userContact.Prenom = prenom;
            userContact.Nom = nom;
            userContact.Cellulaire = cellulaire;
            userContact.Courriel = courriel;
            userContact.IdUsers = Id_utilisateurs;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"insert into Contacts(prenom,nom,telephone,courriel,Id_utilisateurs) values (@prenom,@nom,@cellulaire,@courriel,@Id_utilisateurs)";

                    cmd.Parameters.AddWithValue("@prenom", userContact.Prenom);
                    cmd.Parameters.AddWithValue("@nom", userContact.Nom);

                    if (userContact.Cellulaire != null)
                    {
                        cmd.Parameters.AddWithValue("@cellulaire", userContact.Cellulaire);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cellulaire", DBNull.Value);
                    }


                    if (userContact.Courriel != null)
                    {
                        cmd.Parameters.AddWithValue("@courriel", userContact.Courriel);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@courriel", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@Id_utilisateurs", userContact.IdUsers);


                    cmd.ExecuteNonQuery();

                    Console.WriteLine("contact ajoute");
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


        public static List<Contacts> RechercheParPrenom(string prenom, int Id_utilisateurs)
        {

            List<Contacts> contacts = new List<Contacts>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select Contacts.Id_utilisateurs, prenom, nom,telephone, courriel
                        from Contacts
                        Inner Join Utilisateurs On Contacts.Id_utilisateurs = Utilisateurs.Id
                        where (prenom like @prenom + '%' Or nom like @prenom + '%') And Id_utilisateurs = @Id_utilisateurs order by nom asc";
                    cmd.Parameters.Add(new SqlParameter("prenom", prenom));
                    cmd.Parameters.Add(new SqlParameter("@Id_utilisateurs", Id_utilisateurs));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contacts userContacts = new Contacts();
                            userContacts.Id = reader.GetInt32(0);
                            userContacts.Prenom = reader.GetString(1);
                            userContacts.Nom = reader.GetString(2);

                            if (reader.GetValue(3) != DBNull.Value)
                            {
                                userContacts.Cellulaire = reader.GetString(3);
                            }
                            else
                            {
                                userContacts.Cellulaire = null;
                            }
                            if (reader.GetValue(4) != DBNull.Value)
                            {
                                userContacts.Courriel = reader.GetString(4);
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
                    cmd.CommandText = @"update Contacts Set prenom = @prenom, nom = @nom, telephone = @cellulaire, courriel = @courriel where id = @id";
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


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select id
                        from Utilisateurs where username = @username";
                    cmd.Parameters.Add(new SqlParameter("username", username));

                    object idRecherche = cmd.ExecuteScalar();

                    idUser = (int)idRecherche;


                }
            }
            return idUser;
        }



        public static List<Contacts> ShowAllContactsByUserId(int Id_utilisateurs)
        {

            List<Contacts> contacts = new List<Contacts>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select id, prenom, nom, telephone, courriel
                        from Contacts where Id_utilisateurs = @Id_utilisateurs order by nom asc";
                    cmd.Parameters.Add(new SqlParameter("@Id_utilisateurs", Id_utilisateurs));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contacts userContacts = new Contacts();
                            userContacts.Id = reader.GetInt32(0);
                            userContacts.Prenom = reader.GetString(1);
                            userContacts.Nom = reader.GetString(2);

                            if (reader.GetValue(3) != DBNull.Value)
                            {
                                userContacts.Cellulaire = reader.GetString(3);
                            }
                            else
                            {
                                userContacts.Cellulaire = null;
                            }
                            if (reader.GetValue(4) != DBNull.Value)
                            {
                                userContacts.Courriel = reader.GetString(4);
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



    }


}

