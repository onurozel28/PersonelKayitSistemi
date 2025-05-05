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
    public partial class frmgiris : Form
    {
        public frmgiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ONUR_OZEL\\SQLEXPRESS;Initial Catalog=DbPersonelVeriTabani;Integrated Security=True");
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yönetici where KullanıcıAD=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkullaniciad.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr1= komut.ExecuteReader();
            if(dr1.Read())
            {
                FrmAnaForm anaform = new FrmAnaForm();
                anaform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı ya da şifre");
            }



            baglanti.Close();
        }
    }
}
