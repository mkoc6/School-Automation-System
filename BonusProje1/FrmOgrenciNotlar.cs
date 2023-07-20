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
    public partial class FrmOgrenciNotlar : Form
    {

        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=BonusOKUL;Integrated Security=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select DERSAD,sınav1,sınav2,sınav3,proje,ortalama,durum from TBL_NOTLAR INNER JOIN TBL_DERSLER ON TBL_NOTLAR.DERSID = TBL_DERSLER.DERSID  WHERE OGRID=@P1", baglanti);
            cmd.Parameters.AddWithValue("@P1",numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            ///////////
             baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("select ograd, ogrsoyad  from tbl_ogrenciler where ogrıd ="+numara, baglanti);
         //   cmd2.Parameters.AddWithValue("@p1", numara);
           SqlDataReader ct = cmd2.ExecuteReader();
            while (ct.Read()) 
            {
                this.Text = ct[0] + " " +ct[1];
            }
        }
    }
}
