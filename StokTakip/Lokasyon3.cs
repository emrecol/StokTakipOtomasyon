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
    public partial class Lokasyon3 : Form
    {
        public Lokasyon3()
        {
            InitializeComponent();
        }

        StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
        private void Lokasyon3_Load(object sender, EventArgs e)
        {
            timer1.Start();

            var wh = from item in db.WarehouseTB
                     where (item.W_Id == 2 || item.W_Id == 7)
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
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (cbSourceW.SelectedItem == null || cbTargetW.SelectedItem == null || cbTransType.SelectedItem == null || txtUrubid.Text == "" || txtUrunadet.Text == "")
            {
                MessageBox.Show("Lütfen ilgili alanları boş bırakmayınız!");
                return;
            }
            var sor = MessageBox.Show($@"{cbSourceW.Text}'den {cbTargetW.Text}'e {txtUrubid.Text} ürünü {txtUrunadet.Text} adet {cbTransType.Text} işlemi yapılacaktır!", "İŞLEM ONAYI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sor == DialogResult.Yes)
            {
                if (cbSourceW.SelectedIndex == 0 && cbTargetW.SelectedIndex == 1)
                {
                    StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                    int urunno = int.Parse(txtUrubid.Text);
                    TransactionTB ttb = new TransactionTB();
                    db.StokTB.FirstOrDefault(x => x.S_Id == urunno);
                    ttb.U_Id = urunno;
                    ttb.T_Type = (byte)cbTransType.SelectedIndex;
                    ttb.S_Depo = 2;
                    ttb.T_Depo = 7;
                    ttb.T_Adet = int.Parse(txtUrunadet.Text);
                    ttb.T_Date = DateTime.Now;
                    ttb.T_Personel = 162301;
                    db.TransactionTB.Add(ttb);
                    db.SaveChanges();
                    if (cbTransType.SelectedIndex == 0)
                    {
                        db.StokTB.FirstOrDefault(x => x.S_Id == urunno);
                        ttb.U_Id = urunno;
                        ttb.T_Type = 1;
                        ttb.S_Depo = 7;
                        ttb.T_Depo = 2;
                        int uno = int.Parse(txtUrubid.Text);
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
                        db.StokTB.FirstOrDefault(x => x.S_Id == urunno);
                        ttb.U_Id = urunno;
                        ttb.T_Type = 0;
                        ttb.S_Depo = 7;
                        ttb.T_Depo = 2;
                        int uno = int.Parse(txtUrubid.Text);
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
                    int urunno = int.Parse(txtUrubid.Text);
                    TransactionTB ttb = new TransactionTB();
                    db.StokTB.FirstOrDefault(x => x.S_Id == urunno);
                    ttb.U_Id = urunno;
                    ttb.T_Type = (byte)cbTransType.SelectedIndex;
                    ttb.S_Depo = 7;
                    ttb.T_Depo = 2;
                    ttb.T_Adet = int.Parse(txtUrunadet.Text);
                    ttb.T_Date = DateTime.Now;
                    ttb.T_Personel = 162301;
                    db.TransactionTB.Add(ttb);
                    db.SaveChanges();
                    if (cbTransType.SelectedIndex == 0)
                    {
                        db.StokTB.FirstOrDefault(x => x.S_Id == urunno);
                        ttb.U_Id = urunno;
                        ttb.T_Type = 1;
                        ttb.S_Depo = 2;
                        ttb.T_Depo = 7;
                        int uno = int.Parse(txtUrubid.Text);
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
                        db.StokTB.FirstOrDefault(x => x.S_Id == urunno);
                        ttb.U_Id = urunno;
                        ttb.T_Type = 0;
                        ttb.S_Depo = 2;
                        ttb.T_Depo = 7;
                        int uno = int.Parse(txtUrubid.Text);
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
                else if (cbTransType.SelectedItem == null)
                {
                    MessageBox.Show("Transfer tipini belirtiniz!");
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void txtUrunadet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dtgvLokasyon3_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtUrubid.Text = dtgvLokasyon3.CurrentRow.Cells[0].Value.ToString();
        }
        public void Listele()
        {
            var it = from item in db.StokTB
                     join isim in db.ItemTB
                     on item.U_Id equals isim.Item_Id
                     where (item.Wh_Id == 2)
                     select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
            dtgvLokasyon3.DataSource = it.ToList();
            dtgvLokasyon3.Columns[0].HeaderText = "Ürün İd";
            dtgvLokasyon3.Columns[1].HeaderText = "Ürün Adı";
            dtgvLokasyon3.Columns[2].HeaderText = "Ürün Adet";
            dtgvLokasyon3.Columns[3].HeaderText = "Ürün Raf";
        }

        private void Lokasyon3_FormClosing(object sender, FormClosingEventArgs e)
        {
            ANAFORM anafrm = (ANAFORM)this.MdiParent;
            anafrm.tsbLokasyon3.Enabled = true;
        }
    }
}
