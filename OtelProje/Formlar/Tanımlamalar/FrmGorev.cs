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
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmGorev_Load(object sender, EventArgs e)
        {
            db.Tbl_Gorev.Load();
            bindingSource1.DataSource = db.Tbl_Gorev.Local;

            repositoryItemLookUpEditItemDurum.DataSource = (from x in db.Tbl_Durum
                                                            select new
                                                            {
                                                                x.DurumId,
                                                                x.DurumAd
                                                            }).ToList();


            repositoryItemLookUpEditDepartman.DataSource = (from x in db.Tbl_Departman
                                                            select new
                                                            {
                                                                x.DepartmanId,
                                                                x.DepartmanAd
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
