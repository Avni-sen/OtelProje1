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

namespace OtelProje.Formlar.WebSite
{
    public partial class FrmOnRezervasyonlar : Form
    {
        DbOtelEntities db = new DbOtelEntities();
        public FrmOnRezervasyonlar()
        {
            InitializeComponent();
        }

        private void FrmOnRezervasyonlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_OnRezervasyon
                                       select new
                                       {
                                           x.Id,
                                           x.AdSoyad,
                                           x.Mail,
                                           x.Telefon,
                                           x.KisiSayisi,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Aciklama
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmOnRezervasyonKarti fr = new FrmOnRezervasyonKarti();
            fr.id = (int)gridView1.GetFocusedRowCellValue("Id");
            fr.Show();
        }
    }
}

