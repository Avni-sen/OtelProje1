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
    public partial class FrmIptalEdilenRezervasyonlar : Form
    {
        public FrmIptalEdilenRezervasyonlar()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmIptalEdilenRezervasyonlar_Load(object sender, EventArgs e)
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

                                       }).Where(y=>y.DurumAd == "Rezervasyon İptal").ToList();
        }
    }
}
