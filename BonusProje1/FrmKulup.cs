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
namespace BonusProje1
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=BonusOKUL;Integrated Security=True");
        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulupler ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
          liste();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_kulupler (kulupad) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1",txtkulupadı.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulüp ataması eklendi","bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightBlue;
        }

      

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        int SECİLEN = dataGridView1.SelectedCells[0].RowIndex;
            txtkulupid.Text = dataGridView1.Rows[SECİLEN].Cells[0].Value.ToString();
            txtkulupadı.Text = dataGridView1.Rows[SECİLEN].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Delete From TBL_KULUPLER WHERE KULUPID = @P1",baglanti);
            cmd.Parameters.AddWithValue("@p1", txtkulupid.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("silme işlemi gerçekleşti");
            liste();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand TERS = new SqlCommand("UPdate TBL_KULUPLER SET KULUPAD=@p1 where KULUPID=@p2 ", baglanti);
            TERS.Parameters.AddWithValue("@p1", txtkulupadı.Text);
            TERS.Parameters.AddWithValue("@p2", txtkulupid.Text);
            TERS.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulup adı guncellendi");
            liste();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
