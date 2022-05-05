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
    public partial class FrmBirim : Form
    {
        public FrmBirim()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmBirim_Load(object sender, EventArgs e)
        {
            db.Tbl_Birim.Load();
            bindingSource1.DataSource = db.Tbl_Birim.Local;

            repositoryItemLookUpEditItemDurum.DataSource = (from x in db.Tbl_Durum
                                                            select new
                                                            {
                                                                x.DurumId,
                                                                x.DurumAd
                                                            }).ToList();
           
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
