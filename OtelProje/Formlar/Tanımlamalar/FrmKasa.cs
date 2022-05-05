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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            db.Tbl_Kasa.Load();
            bindingSource1.DataSource = db.Tbl_Kasa.Local;

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
                XtraMessageBox.Show("Hatalı Bilgi Girişi Yaptınız , Lütfen Kontrol Ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
