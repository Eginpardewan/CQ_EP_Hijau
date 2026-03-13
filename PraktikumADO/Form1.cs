using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PraktikumADO
{
    public partial class Form1 : Form
    {

        MySqlConnection conn;
        MySqlCommand cmd;

        // Method Koneksi Database 
        private void koneksi()
        {
            conn = new MySqlConnection("Server=127.0.0.1;database=DBAkademiADO;UID=root;Password=Ars1pneg@r@;");
        }

        public Form1()
        {
            InitializeComponent();
        }

        // Membuka Koneksi Database 
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                MessageBox.Show("Koneksi ke Database Berhasil", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}