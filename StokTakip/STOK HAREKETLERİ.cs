using StokTakip.Models;
using StokTakipProgramı.Classes;
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
    public partial class STOK_HAREKETLERİ : Form
    {
        public STOK_HAREKETLERİ()
        {
            InitializeComponent();
        }
        StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
        private void STOK_HAREKETLERİ_Load(object sender, EventArgs e)
        {
            var wh = from item in db.WarehouseTB
                     select new { item.W_Name };
            cbSourceW.DataSource = wh.ToList();
            cbSourceW.DisplayMember = "W_Name";
            cbTargetW.DataSource = wh.ToList();
            cbTargetW.DisplayMember = "W_Name";
            cbSourceW.SelectedItem = null;
            cbTargetW.SelectedItem = null;

            var tt = from item in db.TransactionTypeAdTB
                     select new { item.T_Type, item.TT_Id };
            cbTransType.DataSource = tt.ToList();
            cbTransType.DisplayMember = "T_Type";
            cbTransType.ValueMember = "TT_Id";
            cbTransType.SelectedItem = null;

            listele();
        }

        public void incele()
        {
            int sindex = cbSourceW.SelectedIndex;
            int tindex = cbTargetW.SelectedIndex;
            int ttype = cbTransType.SelectedIndex;
            var it = from item in db.TransactionTB
                     join isim in db.ItemTB on item.U_Id equals isim.Item_Id
                     join personel in db.PersonelTB on item.T_Personel equals personel.P_Id
                     join wareS in db.WarehouseTB on item.S_Depo equals wareS.W_Id
                     join wareT in db.WarehouseTB on item.T_Depo equals wareT.W_Id
                     join ttipi in db.TransactionTypeAdTB on item.T_Type equals ttipi.TT_Id
                     where (item.S_Depo == sindex && item.T_Depo == tindex && item.T_Type == ttype)
                     select new { item.T_Id, item.U_Id, isim.Item_Name, ttipi.T_Type, gönderici = wareS.W_Name, alıcı = wareT.W_Name, item.T_Adet, item.T_Date, adsoyad = personel.P_Ad + " " + personel.P_Soyad };
            dtgvHareketler.DataSource = it.ToList();
            dtgvHareketler.Columns[0].HeaderText = "Transfer İd";
            dtgvHareketler.Columns[1].HeaderText = "Ürün id";
            dtgvHareketler.Columns[2].HeaderText = "Ürün Adı";
            dtgvHareketler.Columns[3].HeaderText = "Transfer Tipi";
            dtgvHareketler.Columns[4].HeaderText = "Gönderici";
            dtgvHareketler.Columns[5].HeaderText = "Alıcı";
            dtgvHareketler.Columns[6].HeaderText = "Transfer Adet";
            dtgvHareketler.Columns[7].HeaderText = "Transfer Tarihi";
            dtgvHareketler.Columns[8].HeaderText = "Personel Ad Soyad";
        }

        public void listele()
        {
            int sindex = cbSourceW.SelectedIndex;
            int tindex = cbTargetW.SelectedIndex;
            int ttype = cbTransType.SelectedIndex;
            var it = from item in db.TransactionTB
                     join isim in db.ItemTB on item.U_Id equals isim.Item_Id
                     join personel in db.PersonelTB on item.T_Personel equals personel.P_Id
                     join wareS in db.WarehouseTB on item.S_Depo equals wareS.W_Id
                     join wareT in db.WarehouseTB on item.T_Depo equals wareT.W_Id
                     join ttipi in db.TransactionTypeAdTB on item.T_Type equals ttipi.TT_Id
                     select new { item.T_Id, item.U_Id, isim.Item_Name, ttipi.T_Type, gönderici = wareS.W_Name, alıcı = wareT.W_Name, item.T_Adet, item.T_Date, adsoyad = personel.P_Ad + " " + personel.P_Soyad };
            dtgvHareketler.DataSource = it.ToList();
            dtgvHareketler.Columns[0].HeaderText = "Transfer İd";
            dtgvHareketler.Columns[1].HeaderText = "Ürün id";
            dtgvHareketler.Columns[2].HeaderText = "Ürün Adı";
            dtgvHareketler.Columns[3].HeaderText = "Transfer Tipi";
            dtgvHareketler.Columns[4].HeaderText = "Gönderici";
            dtgvHareketler.Columns[5].HeaderText = "Alıcı";
            dtgvHareketler.Columns[6].HeaderText = "Transfer Adet";
            dtgvHareketler.Columns[7].HeaderText = "Transfer Tarihi";
            dtgvHareketler.Columns[8].HeaderText = "Personel Ad Soyad";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            incele();

            var toplam = (from tp in db.TransactionTB
                         where (tp.S_Depo == cbSourceW.SelectedIndex && tp.T_Depo == cbTargetW.SelectedIndex && tp.T_Type == cbTransType.SelectedIndex)
                         select  tp.T_Adet ).Sum();
            lblToplam.Text = toplam.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            reporting.report(dtgvHareketler);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void STOK_HAREKETLERİ_FormClosing(object sender, FormClosingEventArgs e)
        {
            ANAFORM anafrm = (ANAFORM)this.MdiParent;
            anafrm.tsbHareketler.Enabled = true;
        }
    }
}


