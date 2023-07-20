using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
        }

        private void BtnDersler_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
        }

        private void BrnOgrenciislemleri_Click(object sender, EventArgs e)
        {
            FrmOgrenlciler fr = new FrmOgrenlciler();
            fr.Show();
        }

        private void btnsınavnotlar_Click(object sender, EventArgs e)
        {
            FrmSınavNotalr fr =new FrmSınavNotalr();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
