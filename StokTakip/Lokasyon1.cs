using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class Lokasyon1 : Form
    {
        public Lokasyon1()
        {
            InitializeComponent();
        }
        StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            var wh = from item in db.WarehouseTB
                     where (item.W_Id == 0 || item.W_Id == 5)
                     select new { item.W_Name };
            cbSourceW.DataSource = wh.ToList();
            cbSourceW.DisplayMember = "W_Name";
            cbTargetW.DataSource = wh.ToList();
            cbTargetW.DisplayMember = "W_Name";
            cbSourceW.SelectedItem = null;
            cbTargetW.SelectedItem = null;

            var tt = from item in db.TransactionTypePerTB
                     select new { item.T_Type, item.TT_Id };
            cbTransType.DataSource = tt.ToList();
            cbTransType.DisplayMember = "T_Type";
            cbTransType.ValueMember = "TT_Id";
            cbTransType.SelectedItem = null;

            Listele();
        }

        private void dtgvLokasyon1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunid.Text = dtgvLokasyon1.CurrentRow.Cells[0].Value.ToString();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        public void Listele()
        {
            var it = from item in db.StokTB
                     join isim in db.ItemTB
                     on item.U_Id equals isim.Item_Id
                     where (item.Wh_Id == 0)
                     select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
            dtgvLokasyon1.DataSource = it.ToList();
            dtgvLokasyon1.Columns[0].HeaderText = "Ürün İd";
            dtgvLokasyon1.Columns[1].HeaderText = "Ürün Adı";
            dtgvLokasyon1.Columns[2].HeaderText = "Ürün Adet";
            dtgvLokasyon1.Columns[3].HeaderText = "Ürün Raf";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void txtUrunadet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {

            if (cbSourceW.SelectedItem == null || cbTargetW.SelectedItem == null || cbTransType.SelectedItem == null || txtUrunid.Text == "" || txtUrunadet.Text == "")
            {
                MessageBox.Show("Lütfen ilgili alanları boş bırakmayınız!");
                return;
            }

            var sor = MessageBox.Show($@"{cbSourceW.Text}'den {cbTargetW.Text}'e {txtUrunid.Text} ürünü {txtUrunadet.Text} adet {cbTransType.Text} işlemi yapılacaktır!", "İŞLEM ONAYI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sor == DialogResult.Yes)
            {
                if (cbSourceW.SelectedIndex == 0 && cbTargetW.SelectedIndex == 1)
                {
                    StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                    int urunno = int.Parse(txtUrunid.Text);
                    TransactionTB ttb = new TransactionTB();
                    db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                    ttb.U_Id = urunno;
                    ttb.T_Type = (byte)cbTransType.SelectedIndex;
                    ttb.S_Depo = 0;
                    ttb.T_Depo = 5;
                    ttb.T_Adet = int.Parse(txtUrunadet.Text);
                    ttb.T_Date = DateTime.Now;
                    ttb.T_Personel = 162301;
                    db.TransactionTB.Add(ttb);
                    db.SaveChanges();
                    if (cbTransType.SelectedIndex == 0)
                    {
                        db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                        ttb.U_Id = urunno;
                        ttb.T_Type = 1;
                        ttb.S_Depo = 5;
                        ttb.T_Depo = 0;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno);
                        stok.U_Adet -= uadet;
                        ttb.T_Adet = int.Parse(txtUrunadet.Text);
                        ttb.T_Date = DateTime.Now;
                        ttb.T_Personel = 162301;
                        db.TransactionTB.Add(ttb);
                        db.SaveChanges();
                    }
                    else if (cbTransType.SelectedIndex == 1)
                    {
                        db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                        ttb.U_Id = urunno;
                        ttb.T_Type = 0;
                        ttb.S_Depo = 5;
                        ttb.T_Depo = 0;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno);
                        stok.U_Adet += uadet;
                        ttb.T_Adet = int.Parse(txtUrunadet.Text);
                        ttb.T_Date = DateTime.Now;
                        ttb.T_Personel = 162301;
                        db.TransactionTB.Add(ttb);
                        db.SaveChanges();
                    }
                }
                else if (cbSourceW.SelectedIndex == 1 && cbTargetW.SelectedIndex == 0)
                {
                    StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                    int urunno = int.Parse(txtUrunid.Text);
                    TransactionTB ttb = new TransactionTB();
                    db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                    ttb.U_Id = urunno;
                    ttb.T_Type = (byte)cbTransType.SelectedIndex;
                    ttb.S_Depo = 5;
                    ttb.T_Depo = 0;
                    ttb.T_Adet = int.Parse(txtUrunadet.Text);
                    ttb.T_Date = DateTime.Now;
                    ttb.T_Personel = 162301;
                    db.TransactionTB.Add(ttb);
                    db.SaveChanges();
                    if (cbTransType.SelectedIndex == 0)
                    {
                        db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                        ttb.U_Id = urunno;
                        ttb.T_Type = 1;
                        ttb.S_Depo = 0;
                        ttb.T_Depo = 5;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno);
                        stok.U_Adet -= uadet;
                        ttb.T_Adet = int.Parse(txtUrunadet.Text);
                        ttb.T_Date = DateTime.Now;
                        ttb.T_Personel = 162301;
                        db.TransactionTB.Add(ttb);
                        db.SaveChanges();
                    }
                    else if (cbTransType.SelectedIndex == 1)
                    {
                        db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                        ttb.U_Id = urunno;
                        ttb.T_Type = 0;
                        ttb.S_Depo = 0;
                        ttb.T_Depo = 5;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno);
                        stok.U_Adet += uadet;
                        ttb.T_Adet = int.Parse(txtUrunadet.Text);
                        ttb.T_Date = DateTime.Now;
                        ttb.T_Personel = 162301;
                        db.TransactionTB.Add(ttb);
                        db.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Lokasyon seçimlerinizi kontrol ediniz!");
                    return;
                }
                Listele();
                MessageBox.Show("işlem başarılı");


            }
            else
            {
                MessageBox.Show("İşleminiz iptal edilmiştir.", "İPTAL EDİLDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void Lokasyon1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ANAFORM anafrm = (ANAFORM)this.MdiParent;
            anafrm.tsbLokasyon1.Enabled = true;
        }
    }
}
