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

namespace OtelProje.Formlar.Urun
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
           
            gridControl1.DataSource = (from x in db.Tbl_Urun
                                       select new
                                       {
                                           x.UrunId,
                                           x.UrunAd,
                                           x.Tbl_UrunGrup.UrunGrupAd,
                                           x.UrunFiyat,
                                           x.UrunBirim,
                                           x.Toplam,
                                           x.Tbl_Durum.DurumAd
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmUrunKarti fr = new FrmUrunKarti();
            fr.id = (int)gridView1.GetFocusedRowCellValue("UrunId");
            fr.Show();
        }
    }
}
