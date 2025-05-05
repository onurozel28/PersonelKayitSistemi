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
    public partial class grafikler : Form
    {
        public grafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ONUR_OZEL\\SQLEXPRESS;Initial Catalog=DbPersonelVeriTabani;Integrated Security=True");
        private void grafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmtg1 = new SqlCommand("Select Persehir,Count(*) From Tbl_Personel group by persehir", baglanti);
            SqlDataReader dr1=kmtg1.ExecuteReader();
            while (dr1.Read()) 
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand kmtg2 = new SqlCommand("Select Permeslek,Avg(permaas) From Tbl_Personel group by permeslek", baglanti);
            SqlDataReader dr2 = kmtg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maaş"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
