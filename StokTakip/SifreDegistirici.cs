using StokTakip.Classes;
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
    public partial class SifDegForm : Form
    {
        public SifDegForm()
        {
            InitializeComponent();
        }

        private void SifDegForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Kullanıcı_Giriş kgf = new Kullanıcı_Giriş();
            this.Hide();
            kgf.ShowDialog();
        }
        SifreMail sm = new SifreMail();
        private void button1_Click(object sender, EventArgs e)
        {
            string gmail = "Kaderinbu16@outlook.com";
            string gsifre = "vn2013nz86e";
            StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
            int pid = int.Parse(textBox2.Text);
            var adsoyad = db.PersonelTB.Where(x => x.P_Id == pid).Select(x=>x.P_Ad +" "+ x.P_Soyad).FirstOrDefault();
            sm.Microsoft(adsoyad,gmail,gsifre,pid,textBox1.Text);

            MessageBox.Show("Girilen bilgiler doğrulanır ise yeni şifreniz gönderilecek.","Şifre Sıfırlama",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
