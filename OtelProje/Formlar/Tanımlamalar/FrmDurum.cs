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
using DevExpress.XtraEditors;
using OtelProje.Entity;
namespace OtelProje.Formlar.Tanımlamalar
{
    public partial class FrmDurum : Form
    {
        public FrmDurum()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmDurum_Load(object sender, EventArgs e)
        {
            db.Tbl_Durum.Load();
            bindingSource1.DataSource = db.Tbl_Durum.Local;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Litfen değerleri kontrol edip yeniden giriş yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void durumuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
