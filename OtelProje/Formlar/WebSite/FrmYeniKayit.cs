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
    public partial class FrmYeniKayit : Form
    {

        DbOtelEntities db = new DbOtelEntities();
        public FrmYeniKayit()
        {
            InitializeComponent();
        }

        private void FrmYeniKayit_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_YeniKayit
                                       select new
                                       {
                                           x.AdSoyad,
                                           x.TC,
                                           x.Mail,
                                           x.Telefon,
                                           x.Adres

                                       }).ToList();
        }
    }
}
