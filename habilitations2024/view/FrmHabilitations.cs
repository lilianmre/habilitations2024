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

        // Cette m�thode sera appel�e quand le formulaire sera charg�
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();  // Appel � la m�thode de connexion � la base de donn�es
        }

        // M�thode pour se connecter � la base de donn�es MySQL
        private void ConnectToDatabase()
        {
            string connectionString = "Server=localhost;Database=habilitations;User ID=comptewdpnonroot;Password=tonmotdepasse;SslMode=none;";

            try
            {
                // Cr�e une nouvelle connexion � la base de donn�es
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();  // Ouverture de la connexion
                    MessageBox.Show("Connexion r�ussie!");  // Affichage d'un message si la connexion r�ussit

                    // Ex�cution d'une requ�te pour afficher les tables
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
                // Affichage de l'erreur MySQL d�taill�e
                MessageBox.Show("Erreur MySQL : " + ex.Message + "\nCode d'erreur : " + ex.Number);
            }
            catch (Exception ex)
            {
                // Affichage des autres erreurs
                MessageBox.Show("Erreur g�n�rale : " + ex.Message);
            }
        }
    }
}
