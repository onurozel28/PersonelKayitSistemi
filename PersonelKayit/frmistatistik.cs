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


namespace PersonelKayit
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ONUR_OZEL\\SQLEXPRESS;Initial Catalog=DbPersonelVeriTabani;Integrated Security=True");
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand frmistatistik = new SqlCommand("Select Count(*) From Tbl_Personel", baglanti);
            SqlDataReader reader =frmistatistik.ExecuteReader();
            while (reader.Read())
            {
                lbltoplampersonel.Text = reader[0].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand frmistatistik2 = new SqlCommand("Select Count(*) From Tbl_Personel where perdurum=1", baglanti);
            SqlDataReader reader2 = frmistatistik2.ExecuteReader();
            while (reader2.Read())
            {
                lblevlipersonel.Text = reader2[0].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand frmistatik3 = new SqlCommand("Select Count(*) From Tbl_Personel where perdurum=0", baglanti);
            SqlDataReader reader3=frmistatik3.ExecuteReader();
            while (reader3.Read())
            { 
                lblbekarpersonel.Text = reader3[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand frmistatistik4 = new SqlCommand("Select Count(Distinct(persehir)) From Tbl_Personel ", baglanti);
            SqlDataReader reader4=frmistatistik4.ExecuteReader();
            while(reader4.Read())
            {
                lblsehirsayisi.Text = reader4[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand frmistatik5 = new SqlCommand("Select sum(permaas) From Tbl_Personel", baglanti);
            SqlDataReader reader5 = frmistatik5.ExecuteReader();
            while(reader5.Read())
            {
                lbltoplammaas.Text = reader5[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand frmistatik6 = new SqlCommand("Select avg(permaas) From Tbl_Personel", baglanti);
            SqlDataReader reader6= frmistatik6.ExecuteReader();
            while (reader6.Read())
            {
                lblortalamamaas.Text = reader6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
