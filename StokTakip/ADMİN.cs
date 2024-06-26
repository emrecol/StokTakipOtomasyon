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
    public partial class ADMİN : Form
    {
        public ADMİN()
        {
            InitializeComponent();
        }
        StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
        private void ADMİN_Load(object sender, EventArgs e)
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
            cbLokasyon.DataSource = wht.ToList();
            cbLokasyon.DisplayMember = "W_Name";

            var tt = from item in db.TransactionTypePerTB
                     select new { item.T_Type, item.TT_Id };
            cbTransType.DataSource = tt.ToList();
            cbTransType.DisplayMember = "T_Type";
            cbTransType.ValueMember = "TT_Id";
            cbTransType.SelectedItem = null;

            Listele();
            incele();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void dtgvUrunler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunid.Text = dtgvUrunler.CurrentRow.Cells[0].Value.ToString();

        }

        private void txtUrunadet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

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
            dtgvUrunler.DataSource = it.ToList();
            dtgvUrunler.Columns[0].HeaderText = "Ürün İd";
            dtgvUrunler.Columns[1].HeaderText = "Ürün Adı";
            dtgvUrunler.Columns[2].HeaderText = "Ürün Adet";
            dtgvUrunler.Columns[3].HeaderText = "Ürün Raf";
        }

        private void dtgvBildirim_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunid.Text = dtgvBildirim.CurrentRow.Cells[0].Value.ToString();

        }

        private void rbLk1_CheckedChanged(object sender, EventArgs e)
        {

            getir(0);
        }

        private void rbLk2_CheckedChanged(object sender, EventArgs e)
        {
            getir(1);
        }

        private void rbLk3_CheckedChanged(object sender, EventArgs e)
        {
            getir(2);
        }

        private void rbLk4_CheckedChanged(object sender, EventArgs e)
        {
            getir(3);
        }

        private void rbMk_CheckedChanged(object sender, EventArgs e)
        {
            getir(4);
        }

        public void getir(int whid)
        {
            var it = from item in db.StokTB
                     join isim in db.ItemTB
                     on item.U_Id equals isim.Item_Id
                     where (item.Wh_Id == whid)
                     select new { item.U_Id, isim.Item_Name, item.U_Adet, item.U_Raf };
            dtgvUrunler.DataSource = it.ToList();
            dtgvUrunler.Columns[0].HeaderText = "Ürün İd";
            dtgvUrunler.Columns[1].HeaderText = "Ürün Adı";
            dtgvUrunler.Columns[2].HeaderText = "Ürün Adet";
            dtgvUrunler.Columns[3].HeaderText = "Ürün Raf";

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
            int urunid = Convert.ToInt32(txtUrunid.Text);
            var incl = db.StokTB.FirstOrDefault(x => x.U_Id == urunid);
            if (incl != null)
            {
                var stokup = db.StokTB.FirstOrDefault(x => x.U_Id == urunid);
                var itemup = db.ItemTB.FirstOrDefault(x => x.Item_Id == urunid);
                stokup.U_Id = urunid;
                itemup.Item_Id = urunid;
                itemup.Item_Name = txtUrunad.Text;
                stokup.Wh_Id = Convert.ToByte(cbLokasyon.SelectedIndex);
                stokup.U_Adet = Convert.ToInt32(txtUrunadet.Text);
                stokup.U_Raf = txtUrunraf.Text;
                db.SaveChanges();
                Listele();
            }
            else
            {
                MessageBox.Show("Böyle bir ürün bulunamadı!");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var uid = Convert.ToInt32(txtUrunid.Text);

            var bak = from stok in db.StokTB
                      join item in db.ItemTB
                      on stok.U_Id equals item.Item_Id
                      where (stok.U_Id == uid || stok.U_Raf == txtUrunraf.Text || item.Item_Id == uid || item.Item_Name == txtUrunad.Text)
                      select new { stok.U_Id, item.Item_Id, item.Item_Name, stok.U_Raf };
            if (bak != null)
            {
                //StokTB stk = new StokTB();
                //ItemTB itm = new ItemTB();
                //stk.U_Id = Convert.ToInt32(txtUrunid.Text);
                //itm.Item_Id = Convert.ToInt32(txtUrunid.Text);
                //itm.Item_Name = txtUrunad.Text;
                //stk.Wh_Id = Convert.ToByte(txtLokasyon.Text);
                //stk.U_Adet = Convert.ToInt32(txtUrunadet.Text);
                //stk.U_Raf = txtUrunraf.Text;
                //db.StokTB.Add(stk);
                //db.ItemTB.Add(itm);
                //db.SaveChanges();
                //Listele();

                StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                StokTB stk = new StokTB();
                stk.U_Id = uid;
                stk.Wh_Id = Convert.ToByte(cbLokasyon.SelectedIndex);
                stk.U_Adet = Convert.ToInt32(txtUrunadet.Text);
                stk.U_Raf = txtUrunraf.Text;
                ItemTB itm = new ItemTB();
                itm.Item_Id = uid;
                itm.Item_Name = txtUrunad.Text;
                db.StokTB.Add(stk);
                db.ItemTB.Add(itm);
                db.SaveChanges();
                Listele();
            }
            else
            {
                MessageBox.Show("Bu ürün zaten var!");
                return;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var uid = Convert.ToInt32(txtUrunid.Text);

            var bak = from stok in db.StokTB
                      join item in db.ItemTB
                      on stok.U_Id equals item.Item_Id
                      where (stok.U_Id == uid && item.Item_Id == uid)
                      select new { stok.S_Id, item.Item_Id };
            if (bak != null)
            {
                StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
                StokTB stk = db.StokTB.FirstOrDefault(x => x.U_Id == uid);
                db.StokTB.Remove(stk);
                ItemTB itm = db.ItemTB.FirstOrDefault(x => x.Item_Id == uid);
                db.ItemTB.Remove(itm);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Ürün bulunamadı!");
                return;
            }
        }

        private void ADMİN_FormClosing(object sender, FormClosingEventArgs e)
        {
            ANAFORM anafrm = (ANAFORM)this.MdiParent;
            anafrm.tsbAdmin.Enabled = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }
    }
}
