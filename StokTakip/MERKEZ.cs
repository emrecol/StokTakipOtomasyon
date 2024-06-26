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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StokTakip
{
    public partial class MERKEZ : Form
    {
        public MERKEZ()
        {
            InitializeComponent();
        }

        StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();

        private void MERKEZ_Load(object sender, EventArgs e)
        {
            timer1.Start();

            var whs = from item in db.WarehouseTB
                      where (item.W_Id == 4)
                      select new { item.W_Name };
            var wht = from item in db.WarehouseTB
                      where (item.W_Id == 0 || item.W_Id == 1 || item.W_Id == 2 || item.W_Id == 3)
                      select new { item.W_Name };
            cbSourceW.DataSource = whs.ToList();
            cbSourceW.DisplayMember = "W_Name";
            cbTargetW.DataSource = wht.ToList();
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
            incele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cbSourceW.SelectedItem == null || cbTargetW.SelectedItem == null || cbTransType.SelectedItem == null || txtUrunid.Text == "" || txtUrunadet.Text == "")
            {
                MessageBox.Show("Lütfen ilgili alanları boş bırakmayınız!");
                return;
            }
            var sor = MessageBox.Show($@"{cbSourceW.Text}'den {cbTargetW.Text}'e {txtUrunid.Text} ürünü {txtUrunadet.Text} adet {cbTransType.Text} işlemi yapılacaktır!", "İŞLEM ONAYI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sor == DialogResult.Yes)
            {
                if (cbSourceW.SelectedIndex == 0 && cbTargetW.SelectedIndex == 0)
                {
                    StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                    int urunno = int.Parse(txtUrunid.Text);
                    TransactionTB ttb = new TransactionTB();
                    db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                    ttb.U_Id = urunno;
                    ttb.T_Type = (byte)cbTransType.SelectedIndex;
                    ttb.S_Depo = 4;
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
                        ttb.T_Depo = 4;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 0);
                        stok.U_Adet += uadet;
                        StokTB merkez = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 4);
                        merkez.U_Adet -= uadet;
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
                        ttb.T_Depo = 4;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 0);
                        stok.U_Adet -= uadet;
                        StokTB merkez = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 4);
                        merkez.U_Adet += uadet;
                        ttb.T_Adet = int.Parse(txtUrunadet.Text);
                        ttb.T_Date = DateTime.Now;
                        ttb.T_Personel = 162301;
                        db.TransactionTB.Add(ttb);
                        db.SaveChanges();
                    }
                }
                else if (cbSourceW.SelectedIndex == 0 && cbTargetW.SelectedIndex == 1)
                {
                    StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                    int urunno = int.Parse(txtUrunid.Text);
                    TransactionTB ttb = new TransactionTB();
                    db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                    ttb.U_Id = urunno;
                    ttb.T_Type = (byte)cbTransType.SelectedIndex;
                    ttb.S_Depo = 4;
                    ttb.T_Depo = 1;
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
                        ttb.S_Depo = 1;
                        ttb.T_Depo = 4;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 1);
                        stok.U_Adet += uadet;
                        StokTB merkez = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 4);
                        merkez.U_Adet -= uadet;
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
                        ttb.S_Depo = 1;
                        ttb.T_Depo = 4;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 1);
                        stok.U_Adet -= uadet;
                        StokTB merkez = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 4);
                        merkez.U_Adet += uadet;
                        ttb.T_Adet = int.Parse(txtUrunadet.Text);
                        ttb.T_Date = DateTime.Now;
                        ttb.T_Personel = 162301;
                        db.TransactionTB.Add(ttb);
                        db.SaveChanges();
                    }
                }
                else if (cbSourceW.SelectedIndex == 0 && cbTargetW.SelectedIndex == 2)
                {
                    StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                    int urunno = int.Parse(txtUrunid.Text);
                    TransactionTB ttb = new TransactionTB();
                    db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                    ttb.U_Id = urunno;
                    ttb.T_Type = (byte)cbTransType.SelectedIndex;
                    ttb.S_Depo = 4;
                    ttb.T_Depo = 2;
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
                        ttb.S_Depo = 2;
                        ttb.T_Depo = 4;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 2);
                        stok.U_Adet += uadet;
                        StokTB merkez = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 4);
                        merkez.U_Adet -= uadet;
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
                        ttb.S_Depo = 2;
                        ttb.T_Depo = 4;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 2);
                        stok.U_Adet -= uadet;
                        StokTB merkez = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 4);
                        merkez.U_Adet += uadet;
                        ttb.T_Adet = int.Parse(txtUrunadet.Text);
                        ttb.T_Date = DateTime.Now;
                        ttb.T_Personel = 162301;
                        db.TransactionTB.Add(ttb);
                        db.SaveChanges();
                    }
                }
                else if (cbSourceW.SelectedIndex == 0 && cbTargetW.SelectedIndex == 3)
                {
                    StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                    int urunno = int.Parse(txtUrunid.Text);
                    TransactionTB ttb = new TransactionTB();
                    db.StokTB.FirstOrDefault(x => x.U_Id == urunno);
                    ttb.U_Id = urunno;
                    ttb.T_Type = (byte)cbTransType.SelectedIndex;
                    ttb.S_Depo = 4;
                    ttb.T_Depo = 3;
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
                        ttb.S_Depo = 4;
                        ttb.T_Depo = 3;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 3);
                        stok.U_Adet += uadet;
                        StokTB merkez = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 4);
                        merkez.U_Adet -= uadet;
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
                        ttb.S_Depo = 4;
                        ttb.T_Depo = 3;
                        int uno = int.Parse(txtUrunid.Text);
                        int uadet = int.Parse(txtUrunadet.Text);
                        StokTB stok = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 3);
                        stok.U_Adet -= uadet;
                        StokTB merkez = db.StokTB.FirstOrDefault(x => x.U_Id == uno && x.Wh_Id == 4);
                        merkez.U_Adet += uadet;
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
                incele();
                MessageBox.Show("işlem başarılı");
            }
            else
            {
                MessageBox.Show("İşleminiz iptal edilmiştir.", "İPTAL EDİLDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dtgvMerkez_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunid.Text = dtgvMerkez.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtUrunadet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }
        public void incele()
        {
            var it = from item in db.StokTB
                     join isim in db.ItemTB
                     on item.U_Id equals isim.Item_Id
                     where (item.U_Adet < 500 && (item.Wh_Id == 0 || item.Wh_Id == 1 || item.Wh_Id == 2 || item.Wh_Id == 3))
                     select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
            dtgvBildirim.DataSource = it.ToList();
            dtgvBildirim.Columns[0].HeaderText = "Ürün İd";
            dtgvBildirim.Columns[1].HeaderText = "Ürün Adı";
            dtgvBildirim.Columns[2].HeaderText = "Ürün Adet";
            dtgvBildirim.Columns[3].HeaderText = "Ürün Raf";
        }
        public void Listele()
        {
            var it = from item in db.StokTB
                     join isim in db.ItemTB
                     on item.U_Id equals isim.Item_Id
                     where (item.Wh_Id == 0 || item.Wh_Id == 1 || item.Wh_Id == 2 || item.Wh_Id == 3)
                     select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
            dtgvMerkez.DataSource = it.ToList();
            dtgvMerkez.Columns[0].HeaderText = "Ürün İd";
            dtgvMerkez.Columns[1].HeaderText = "Ürün Adı";
            dtgvMerkez.Columns[2].HeaderText = "Ürün Adet";
            dtgvMerkez.Columns[3].HeaderText = "Ürün Raf";
        }

        private void dtgvBildirim_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunid.Text = dtgvBildirim.CurrentRow.Cells[0].Value.ToString();
        }

        private void cbTargetW_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = cbTargetW.SelectedIndex;

            switch (selectedValue)
            {
                case 0:
                    var it0 = from item in db.StokTB
                              join isim in db.ItemTB
                              on item.U_Id equals isim.Item_Id
                              where (item.Wh_Id == 0)
                              select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
                    dtgvMerkez.DataSource = it0.ToList();
                    dtgvMerkez.Columns[0].HeaderText = "Ürün İd";
                    dtgvMerkez.Columns[1].HeaderText = "Ürün Adı";
                    dtgvMerkez.Columns[2].HeaderText = "Ürün Adet";
                    dtgvMerkez.Columns[3].HeaderText = "Ürün Raf";
                    break;
                case 1:
                    var it1 = from item in db.StokTB
                              join isim in db.ItemTB
                              on item.U_Id equals isim.Item_Id
                              where (item.Wh_Id == 1)
                              select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
                    dtgvMerkez.DataSource = it1.ToList();
                    dtgvMerkez.Columns[0].HeaderText = "Ürün İd";
                    dtgvMerkez.Columns[1].HeaderText = "Ürün Adı";
                    dtgvMerkez.Columns[2].HeaderText = "Ürün Adet";
                    dtgvMerkez.Columns[3].HeaderText = "Ürün Raf";
                    break;
                case 2:
                    var it2 = from item in db.StokTB
                              join isim in db.ItemTB
                              on item.U_Id equals isim.Item_Id
                              where (item.Wh_Id == 2)
                              select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
                    dtgvMerkez.DataSource = it2.ToList();
                    dtgvMerkez.Columns[0].HeaderText = "Ürün İd";
                    dtgvMerkez.Columns[1].HeaderText = "Ürün Adı";
                    dtgvMerkez.Columns[2].HeaderText = "Ürün Adet";
                    dtgvMerkez.Columns[3].HeaderText = "Ürün Raf";
                    break;
                case 3:
                    var it3 = from item in db.StokTB
                             join isim in db.ItemTB
                             on item.U_Id equals isim.Item_Id
                             where (item.Wh_Id == 3)
                             select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
                    dtgvMerkez.DataSource = it3.ToList();
                    dtgvMerkez.Columns[0].HeaderText = "Ürün İd";
                    dtgvMerkez.Columns[1].HeaderText = "Ürün Adı";
                    dtgvMerkez.Columns[2].HeaderText = "Ürün Adet";
                    dtgvMerkez.Columns[3].HeaderText = "Ürün Raf";
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MERKEZ_FormClosing(object sender, FormClosingEventArgs e)
        {
            ANAFORM anafrm = (ANAFORM)this.MdiParent;
            anafrm.tsbMerkez.Enabled = true;
        }
    }
}

