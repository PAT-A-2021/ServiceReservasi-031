using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data Source=LAPTOP-PL25NSSC;Initial Catalog=WCFReservasi;Persist Security Info=true;User ID=sa;Password=bima12345";
        SqlConnection connection;
        SqlCommand com; // Untuk mengkoneksikan database ke visual studio

        public string deletePemesanan(string IDPemesanan)
        {
            throw new NotImplementedException();
        }

        public List<DetailLokasi> DetailLokasi()
        {
            List<DetailLokasi> LokasiFull = new List<DetailLokasi>(); // Proses untuk mendeklarasikan nama list yang telah dibuat dengan nama baru
            try
            {
                string sql = "select ID_lokasi, Nama_lokasi, Deskripsi_full, Kuota from dbo.Lokasi"; // Deklarasi query
                connection = new SqlConnection(constring); // Fungsi untuk koneksi ke database
                com = new SqlCommand(sql, connection); // Proses execute query
                connection.Open(); // Membuka koneksi
                SqlDataReader reader = com.ExecuteReader(); // Menampilkan data query
                while (reader.Read())
                {
                    /* Nama Class */
                    DetailLokasi data = new DetailLokasi(); // Deklarasi data dengan mengambil satu per satu data dari database
                    // Bentuk array
                    data.IDLokasi = reader.GetString(0); // 0 adalah index, terdapat dikolom ke berapa di string sql diatas
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(3);
                    data.Kuota = reader.GetInt32(4);
                    LokasiFull.Add(data); // Mengumpulkan data yang awalnya dari array
                }
                connection.Close(); // Untuk menutup akses ke database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return LokasiFull;

        }

        public string editPemesanan(string IDPemesanan, string NamaCustomer)
        {
            throw new NotImplementedException();
        }

        public string pemesanan(string IDReservasi, string NamaCustomer, string NoTelepon, int JumlahPemesanan, string IDLokasi)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Pemesanan values ('" + IDReservasi + "', '" + NamaCustomer + "', '" + NoTelepon + "', '" + JumlahPemesanan + "', '" + IDLokasi + "')";
                connection = new SqlConnection(constring); // Fungsi konek ke database
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<Pemesanan> Pemesanan()
        {
            throw new NotImplementedException();
        }

        public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }
    }
}
