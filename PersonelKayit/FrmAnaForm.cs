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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=ONUR_OZEL\\SQLEXPRESS;Initial Catalog=DbPersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            cmbsehir.Text = "";
            mskmaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtmeslek.Text = "";
            txtad.Focus();
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.tbl_personelTableAdapter.Fill(this.dbPersonelVeriTabaniDataSet.Tbl_personel);

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.dbPersonelVeriTabaniDataSet.Tbl_personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            
            SqlCommand komut = new SqlCommand("insert into Tbl_personel (Perad,persoyad,persehir,permaas,perdurum,permeslek) values(@p1,@p2,@p3,@p4,@p5,@p6) ", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", radioButton1.Checked);
            komut.Parameters.AddWithValue("@p6", txtmeslek.Text);
            komut.ExecuteNonQuery();
            
            baglanti.Close();
            MessageBox.Show("Personel eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btntemizlik_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            

        }
        
private void Form1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_TextChanged_1(object sender, EventArgs e)
        {
            if(label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel where perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1",txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt silindi!");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutupdate = new SqlCommand("Update Tbl_Personel set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7", baglanti);
            komutupdate.Parameters.AddWithValue("@a1", txtad.Text);
            komutupdate.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutupdate.Parameters.AddWithValue("@a3", cmbsehir.Text);
            komutupdate.Parameters.AddWithValue("@a4", mskmaas.Text);
            komutupdate.Parameters.AddWithValue("@a5", label8.Text);
            komutupdate.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutupdate.Parameters.AddWithValue("@a7", txtid.Text);
            komutupdate.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla güncelleme yapılmıştır!");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr=new frmistatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            grafikler grafikler = new grafikler();
            grafikler.Show();
        }
    }
}
