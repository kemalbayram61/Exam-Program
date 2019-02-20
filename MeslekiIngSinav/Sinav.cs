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
    public partial class Sinav : Form
    {
        Random rnd = new Random();
        SoruIslem soru = new SoruIslem();
        VeriIletisim veri = new VeriIletisim();

        public Sinav()
        {
            InitializeComponent();
        }
        public void Yenile()
        {
            
            lblSoru.Text = soru.SoruVer();
            int cevap = rnd.Next(4);
            switch (cevap)
            {
                case 0:rdA.Text = soru.silinen; rdB.Text = veri.rndKelime(); rdC.Text = veri.rndKelime(); rdD.Text = veri.rndKelime(); ; break;
                case 1: rdB.Text = soru.silinen; rdA.Text = veri.rndKelime(); rdC.Text = veri.rndKelime(); rdD.Text = veri.rndKelime(); ; break;
                case 2: rdC.Text = soru.silinen; rdB.Text = veri.rndKelime(); rdA.Text = veri.rndKelime(); rdD.Text = veri.rndKelime(); ; break;
                case 3: rdD.Text = soru.silinen; rdB.Text = veri.rndKelime(); rdC.Text = veri.rndKelime(); rdA.Text = veri.rndKelime(); ; break;
            }
        }
        public void Kontrol()
        {
            if (rdA.Checked == true && soru.silinen == rdA.Text) Yenile();
            else if (rdB.Checked == true && soru.silinen == rdB.Text) Yenile();
            else if (rdC.Checked == true && soru.silinen == rdC.Text) Yenile();
            else if (rdD.Checked == true && soru.silinen == rdD.Text) Yenile();
            else MessageBox.Show("Hatali");
        }
        private void Sinav_Load(object sender, EventArgs e)
        {
            Yenile();
        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            Kontrol();
        }
    }
}
