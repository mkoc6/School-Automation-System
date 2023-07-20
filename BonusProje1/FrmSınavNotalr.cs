using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BonusProje1.DataSet1TableAdapters;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmSınavNotalr : Form
    {
        public FrmSınavNotalr()
        {
            InitializeComponent();
        }
       
     DataSet1TableAdapters.TBL_NOTLARTableAdapter dr = new DataSet1TableAdapters.TBL_NOTLARTableAdapter();

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dr.NotListesi(int.Parse(txtogrenciid.Text));
        }


    }
}
