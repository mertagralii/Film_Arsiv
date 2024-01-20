using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Film_Arsiv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // SQL BAGLANTİSİ 
        SqlConnection baglanti = new SqlConnection(@"Data Source=Mert;Initial Catalog=FilmArsivim;Integrated Security=True");

        // Liste Getirme Metodu
        void filmgetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT AD,LİNK FROM TBLFİLMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        // Textbox temizleme metodu
        void temizle()
        {
            TxtFilmAdı.Text = " ";
            TxtKategori.Text = " ";
            TxtLink.Text = " ";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Form Yüklendiği sırada filmgetir metodunu çalıştır.
            filmgetir();
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Kaydet = new SqlCommand("İnsert İnto TBLFilmler(AD,KATEGORİ,LİNK) VALUES (@P1,@P2,@P3)", baglanti);
            Kaydet.Parameters.AddWithValue("@P1", TxtFilmAdı.Text);
            Kaydet.Parameters.AddWithValue("@P2", TxtKategori.Text);
            Kaydet.Parameters.AddWithValue("@P3", TxtLink.Text);
            Kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Kaydetme İşlemi Başarıyla Gerçekleştirildi.", "Kaydetme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmgetir();
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // CellDoubleClick == " Hücreye Çift Tıklandığı Zaman Ne Olsun?"
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void BtHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje 20.01.2024 Tarihinde Mert Ağralı Tarafından Kodlandı.", "Hakkımızda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRenkDegistir_Click(object sender, EventArgs e)
        {
            //ÖDEV
        }

        private void BtnTamEkran_Click(object sender, EventArgs e)
        {
            //ÖDEV