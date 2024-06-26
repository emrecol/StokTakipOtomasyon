using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class PERSONEL : Form
    {
        public PERSONEL()
        {
            InitializeComponent();
        }
        StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
        private void PERSONEL_Load(object sender, EventArgs e)
        {
            Listele();
            var yt = from item in db.PersonelTB
                     select new { item.P_Yetki };
            cbYetki.DataSource = yt.ToList();
            cbYetki.DisplayMember = "P_Yetki";
            cbYetki.SelectedItem = null;
        }

        public void Listele()
        {
            var prs = from personel in db.PersonelTB
                      select new { personel.P_Id, personel.P_Ad, personel.P_Soyad, personel.P_Yetki, personel.P_Sifre, personel.P_Mail };
            dtgvPersonel.DataSource = prs.ToList();
            dtgvPersonel.Columns[0].HeaderText = "Personel İd";
            dtgvPersonel.Columns[1].HeaderText = "Personel Adı";
            dtgvPersonel.Columns[2].HeaderText = "Personel Soyadı";
            dtgvPersonel.Columns[3].HeaderText = "Personel Yetki";
            dtgvPersonel.Columns[2].HeaderText = "Personel Şifre";
            dtgvPersonel.Columns[3].HeaderText = "Personel Mail";
        }

        private void dtgvPersonel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cbYetki.Text = null;
            lblPerid.Text = dtgvPersonel.CurrentRow.Cells[0].Value.ToString();
            txtPerAd.Text = dtgvPersonel.CurrentRow.Cells[1].Value.ToString();
            txtPerSoyad.Text = dtgvPersonel.CurrentRow.Cells[2].Value.ToString();
            cbYetki.SelectedText = dtgvPersonel.CurrentRow.Cells[3].Value.ToString();
            txtPerSifre.Text = dtgvPersonel.CurrentRow.Cells[4].Value.ToString();
            txtPerMail.Text = dtgvPersonel.CurrentRow.Cells[5].Value.ToString();

        }

        public void yetkile()
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int prsid = Convert.ToInt32(lblPerid.Text);
            StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
            var perup = db.PersonelTB.FirstOrDefault(x => x.P_Id == prsid);
            perup.P_Ad = txtPerAd.Text;
            perup.P_Soyad = txtPerSoyad.Text;
            perup.P_Yetki = cbYetki.Text;
            perup.P_Mail = txtPerMail.Text;
            perup.P_Sifre = Convert.ToString(txtPerSifre.Text);
            db.SaveChanges();
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtPerAd.Text == "" && txtPerSoyad.Text == "" && cbYetki.SelectedText == "" && txtPerSifre.Text == "" && txtPerMail.Text == "")
            {
                MessageBox.Show("Lütfen ilgili alanları boldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PersonelTB peradd = new PersonelTB();
                peradd.P_Ad = txtPerAd.Text;
                peradd.P_Soyad = txtPerSoyad.Text;
                peradd.P_Yetki = cbYetki.Text;
                peradd.P_Mail = txtPerMail.Text;
                peradd.P_Sifre = Convert.ToString(txtPerSifre.Text);
                db.PersonelTB.Add(peradd);
                db.SaveChanges();
                Listele();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void PERSONEL_FormClosing(object sender, FormClosingEventArgs e)
        {
            ANAFORM anafrm = (ANAFORM)this.MdiParent;
            anafrm.tsbPersonel.Enabled = true;
        }
    }
}
