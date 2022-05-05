using DevExpress.XtraEditors;
using OtelProje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProje.Formlar.Tanımlamalar
{
    public partial class FrmUrunGrup : Form
    {
        public FrmUrunGrup()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunGrup_Load(object sender, EventArgs e)
        {
            db.Tbl_UrunGrup.Load();
            bindingSource1.DataSource = db.Tbl_UrunGrup.Local;

            repositoryItemLookUpEditItemDurum.DataSource = (from x in db.Tbl_Durum
                                                            select new
                                                            {
                                                                x.DurumId,
                                                                x.DurumAd

                                                            }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Hatalı bilgi girişi lütfen tekrar deneyiniz.");
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }
    }
}
