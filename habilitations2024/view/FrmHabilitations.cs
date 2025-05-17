using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace habilitations2024
{
    public partial class FrmHabilitations : Form
    {
        public FrmHabilitations()
        {
            InitializeComponent();
        }

        // Cette méthode sera appelée quand le formulaire sera chargé
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();  // Appel à la méthode de connexion à la base de données
        }

        // Méthode pour se connecter à la base de données MySQL
        private void ConnectToDatabase()
        {
            string connectionString = "Server=localhost;Database=habilitations;User ID=comptewdpnonroot;Password=tonmotdepasse;SslMode=none;";

            try
            {
                // Crée une nouvelle connexion à la base de données
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();  // Ouverture de la connexion
                    MessageBox.Show("Connexion réussie!");  // Affichage d'un message si la connexion réussit

                    // Exécution d'une requête pour afficher les tables
                    string query = "SHOW TABLES;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Affichage des tables dans la console
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));  // Affiche chaque table dans la console
                    }

                    reader.Close();  // Fermeture du lecteur
                }
            }
            catch (MySqlException ex)
            {
                // Affichage de l'erreur MySQL détaillée
                MessageBox.Show("Erreur MySQL : " + ex.Message + "\nCode d'erreur : " + ex.Number);
            }
            catch (Exception ex)
            {
                // Affichage des autres erreurs
                MessageBox.Show("Erreur générale : " + ex.Message);
            }
        }
    }
}
