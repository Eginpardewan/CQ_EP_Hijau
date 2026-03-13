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

        // Menggunakan ExecuteScalar() - Menghitung Jumlah Mahasiswa
        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Mahasiswa";
                cmd = new MySqlCommand(query, conn);

                // ✅ PERBAIKAN: Gunakan Convert.ToInt32 untuk mengatasi masalah cast
                long jumlahLong = (long)cmd.ExecuteScalar();
                int jumlah = Convert.ToInt32(jumlahLong);

                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Menghitung Jumlah Mata Kuliah 
        private void btnHitungMk_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                string query = "";
                cmd = new MySqlCommand(query, conn);

                // ✅ PERBAIKAN: Gunakan Convert.ToInt32
                long jumlahLong = (long)cmd.ExecuteScalar();
                int jumlah = Convert.ToInt32(jumlahLong);

                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}