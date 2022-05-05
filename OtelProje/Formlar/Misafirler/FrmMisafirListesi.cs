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

namespace OtelProje.Formlar.Misafirler
{
    public partial class FrmMisafirListesi : Form
    {
        public FrmMisafirListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmMisafirListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_Misafir
                                       select new
                                       {
                                           x.MisafirId,
                                           x.MisafirAdSoyad,
                                           x.TC,
                                           x.Ulke,
                                           x.iller.sehir,
                                           x.ilceler.ilce,
                                           x.Aciklama,
                                           x.Telefon,
                                           x.Mail,
                                           x.Tbl_Durum.DurumAd
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMisafirKarti fr = new FrmMisafirKarti();
            fr.id = (int)gridView1.GetFocusedRowCellValue("MisafirId");
            fr.Show();
        }
    }
}
