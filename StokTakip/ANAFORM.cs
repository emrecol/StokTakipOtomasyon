using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class ANAFORM : Form
    {
        public ANAFORM()
        {
            InitializeComponent();
        }

        private void tsbLokasyon1_Click(object sender, EventArgs e)
        {
            Lokasyon1 lk1 = new Lokasyon1();
            lk1.MdiParent = this;
            lk1.Show();
            tsbLokasyon1.Enabled = false;
        }

        private void tsbLokasyon2_Click(object sender, EventArgs e)
        {
            Lokasyon2 lk2 = new Lokasyon2();
            lk2.MdiParent = this;
            lk2.Show();
            tsbLokasyon2.Enabled = false;

        }

        private void tsbLokasyon3_Click(object sender, EventArgs e)
        {
            Lokasyon3 lk3 = new Lokasyon3();
            lk3.MdiParent = this;
            lk3.Show();
            tsbLokasyon3.Enabled = false;

        }

        private void tsbLokasyon4_Click(object sender, EventArgs e)
        {
            Lokasyon4 lk4 = new Lokasyon4();
            lk4.MdiParent = this;
            lk4.Show();
            tsbLokasyon4.Enabled = false;

        }

        private void tsbMerkez_Click(object sender, EventArgs e)
        {
            MERKEZ mk = new MERKEZ();
            mk.MdiParent = this;
            mk.Show();
            tsbMerkez.Enabled = false;

        }

        private void tsbAdmin_Click(object sender, EventArgs e)
        {
            ADMİN ad = new ADMİN();
            ad.MdiParent = this;
            ad.Show();
            tsbAdmin.Enabled = false;

        }

        private void tsbHareketler_Click(object sender, EventArgs e)
        {
            STOK_HAREKETLERİ shk = new STOK_HAREKETLERİ();
            shk.MdiParent = this;
            shk.Show();
            tsbHareketler.Enabled = false;

        }

        private void tsbPersonel_Click(object sender, EventArgs e)
        {
            PERSONEL prs = new PERSONEL();
            prs.MdiParent = this;
            prs.Show();
            tsbPersonel.Enabled = false;

        }

        private void ANAFORM_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
