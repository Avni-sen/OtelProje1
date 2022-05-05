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
    public partial class FrmUrunGirisHareket : Form
    {
        public FrmUrunGirisHareket()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunGirisHareket_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_UrunHareket
                                       select new
                                       {
                                           x.UrunHareketId,
                                           x.Tbl_Urun.UrunAd,
                                           x.Miktar,
                                           x.HareketTürü,
                                           x.Aciklama,
                                           x.Tbl_Personel.PersonelAdSoyad,
                                           x.Tarih
                                       }).Where(x=>x.HareketTürü=="Giriş").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmUrunHareketTanimi fr = new FrmUrunHareketTanimi();
            fr.id = (int)gridView1.GetFocusedRowCellValue("UrunHareketId");
            fr.Show();
        }
    }
}
