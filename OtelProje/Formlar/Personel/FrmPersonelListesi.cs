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

namespace OtelProje.Formlar.Personel
{
    public partial class FrmPersonelListesi : Form
    {
        public FrmPersonelListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmPersonelListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_Personel
                            select new
                            {
                                x.PersonelId,
                                x.PersonelAdSoyad,
                                x.TC,
                                x.Tbl_Departman.DepartmanAd,
                                x.Tbl_Gorev.GorevAdı,
                                x.Aciklama,
                                x.Telefon,
                                x.Mail,
                                x.Tbl_Durum.DurumAd
                            }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmPersonelKarti fr = new FrmPersonelKarti();
            fr.id = (int)gridView1.GetFocusedRowCellValue("PersonelId");
            fr.Show();
        }
    }
}
