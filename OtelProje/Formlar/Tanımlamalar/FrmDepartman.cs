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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            db.Tbl_Departman.Load();
            bindingSource1.DataSource = db.Tbl_Departman.Local;

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
                XtraMessageBox.Show("Bilgiler Kaydedilirken Hata Meydana Geldi, Kontrol ediniz.", "Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
