using StokTakip.Models;
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
    public partial class Kullanıcı_Giriş : Form
    {
        public Kullanıcı_Giriş()
        {
            InitializeComponent();
        }
        StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciadi.Text=="" && txtSifre.Text=="")
            {
                MessageBox.Show("İlgili alanları doldurunuz!");
                return;
            }
            int uid = Convert.ToInt32(txtKullaniciadi.Text);
            var durum = db.PersonelTB.FirstOrDefault(x => x.P_Id == uid && x.P_Sifre == txtSifre.Text);
            if (durum != null)
            {
                var yetki = db.PersonelTB.Where(x => x.P_Id == uid).Select(x => x.P_Yetki).FirstOrDefault();
                var peradsoyad = db.PersonelTB.Where(x => x.P_Id == uid).Select(x => new { x.P_Ad, x.P_Soyad }).FirstOrDefault();
                //ANAFORM anafrom = new ANAFORM();
                //anafrom.lbladsoyad.Text = $"{peradsoyad.Per_Ad} {peradsoyad.Per_Soyad}";

                if (yetki == "AD")
                {
                    ANAFORM anafrm = new ANAFORM();
                    anafrm.tsbLokasyon1.Enabled = true;
                    anafrm.tsbLokasyon2.Enabled = true;
                    anafrm.tsbLokasyon3.Enabled = true;
                    anafrm.tsbLokasyon4.Enabled = true;
                    anafrm.tsbMerkez.Enabled = true;
                    anafrm.tsbPersonel.Enabled = true;
                    anafrm.tsbHareketler.Enabled = true;
                    anafrm.tsbAdmin.Enabled = true;
                    this.Hide();
                    anafrm.ShowDialog();
                }
                else if (yetki == "L1")
                {
                    ANAFORM anafrm = new ANAFORM();
                    anafrm.tsbLokasyon1.Enabled=true;
                    this.Hide(); 
                    anafrm.ShowDialog();
                }
                else if (yetki == "L2")
                {
                    ANAFORM anafrm = new ANAFORM();
                    anafrm.tsbLokasyon2.Enabled = true;
                    this.Hide();
                    anafrm.ShowDialog();
                }
                else if (yetki == "L3")
                {
                    ANAFORM anafrm = new ANAFORM();
                    anafrm.tsbLokasyon3.Enabled = true;
                    this.Hide();
                    anafrm.ShowDialog();
                }
                else if (yetki == "L4")
                {
                    ANAFORM anafrm = new ANAFORM();
                    anafrm.tsbLokasyon4.Enabled = true;
                    this.Hide();
                    anafrm.ShowDialog();
                }
                else if (yetki == "MK")
                {
                    ANAFORM anafrm = new ANAFORM();
                    anafrm.tsbMerkez.Enabled = true;
                    this.Hide();
                    anafrm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Lütfen giriş bilgilerinizi kontrol ediniz!","Hatalı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void llblSifreDegistir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifDegForm sdf  = new SifDegForm();
            this.Hide();
            sdf.ShowDialog();
        }
    }
}
