using OtelProje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProje.Formlar.Rezervasyon
{
    public partial class FrmTumRezervasyonlar : Form
    {
        public FrmTumRezervasyonlar()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmTumRezervasyonlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_Rezarvasyon
                                       select new
                                       {
                                           x.RezervasyonId,
                                           x.RezervasyonAdSoyad,
                                           x.Telefon,
                                           x.KisiSayisi,
                                           x.Tbl_Oda.OdaNo,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Aciklama,
                                           x.Tbl_Durum.DurumAd,

                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmRezervasyonKarti fr = new FrmRezervasyonKarti();
            fr.id = (int)gridView1.GetFocusedRowCellValue("RezervasyonId");
            fr.Show();
        }
    }
}
