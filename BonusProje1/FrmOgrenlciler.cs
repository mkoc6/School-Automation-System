using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmOgrenlciler : Form
    {
        public FrmOgrenlciler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=BonusOKUL;Integrated Security=True");
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void FrmOgrenlciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Ogrencilistesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kulupler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KULUPAD";
            cmbkulup.ValueMember = "KULUPID";
            cmbkulup.DataSource = dt;
            baglanti.Close();
           


        }
        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        { 
            if (radiovttonkız.Checked == true)
            {
                c = "kız";
            }
            if (radioButtonErkek.Checked == true)
            {
                c = "erkek";
            }
            ds.OgrenciEkle(TXTad.Text, txtogrencisoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c);
            MessageBox.Show("ogrenci ekleme yapıldı");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Ogrencilistesi();
        }

        private void cmbkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   txtogrenciid.Text = cmbkulup.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.Ogrencisil(int.Parse(txtogrenciid.Text));
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            //    int secilen = dataGridView1.SelectedCells[0].RowIndex;
            //  txtogrenciid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            //   TXTad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            //   txtogrencisoyad.Text = dataGridView1.Rows[secilen].Cells[2].ToString();
            // cmbkulup.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            // c = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string r;
            txtogrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
               TXTad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
              txtogrencisoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].ToString();
             cmbkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
             r = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtARA.Text = r;
       
            if (r == "erkek")
            {
                radioButtonErkek.Checked = true;
             
            }
            else radioButtonErkek.Checked = false;
            if (r == "kız")
            {
     radiovttonkız.Checked = true ;
                
            }
            else radiovttonkız.Checked= false;
            
        }
       
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OGRENCIGUNCELLE(TXTad.Text, txtogrencisoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c, byte.Parse(txtogrenciid.Text)) ;
        }

        private void label1_Click(object sender, EventArgs e)
        {
       
        }

        private void radiovttonkız_CheckedChanged(object sender, EventArgs e)
        {
            if (radiovttonkız.Checked == true)
            {
                c = "kız";
            }
            if (radioButtonErkek.Checked == true)
            {
                c = "erkek";
            }
        }

        private void txtARA_TextChanged(object sender, EventArgs e)
        {
          //  ds.OGRENCigetir(byte.Parse(txtARA.Text));
           
        }

        private void BTNARA_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OGRENCigetir((txtARA.Text));
        }
    }
}
