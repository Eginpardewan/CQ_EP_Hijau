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

        // PMenghitung Jumlah Mata Kuliah 
        private void btnHitungMk_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM MataKuliah";
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

        // Menggunakan ExecuteNonQuery() 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                string query = "UPDATE Mahasiswa SET Alamat = 'Yogyakarta' WHERE NIM = '23110100001'";
                cmd = new MySqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh : " + hasil, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // LATIHAN 1: Menghitung Jumlah Dosen
        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                string query = "";
                cmd = new MySqlCommand(query, conn);
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