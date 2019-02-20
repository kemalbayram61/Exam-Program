using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeslekiIngSinav
{
    public partial class CumleGirisi : Form
    {
        VeriIletisim veri = new VeriIletisim();
        public CumleGirisi()
        {
            InitializeComponent();
        }

        private void CumleGirisi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = veri.Tablo();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            veri.KayitYap(txtCumle.Text);
            txtCumle.Text = "";
            dataGridView1.DataSource = veri.Tablo();
        }
    }
}
