using OtelProje.Entity;
using OtelProje.Repositories;
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
    public partial class FrmOnRezervasyonKarti : Form
    {
        public FrmOnRezervasyonKarti()
        {
            InitializeComponent();
        }
        Repository<Tbl_OnRezervasyon> repo = new Repository<Tbl_OnRezervasyon>();
        Tbl_Urun t = new Tbl_Urun();
        public int id;
        private void FrmOnRezervasyonKarti_Load(object sender, EventArgs e)
        {

            if (id != 0)
            {
                var onRezervasyon = repo.Find(x => x.Id == id);
                TxtAdSoyad.Text = onRezervasyon.AdSoyad;
                TxtMail.Text = onRezervasyon.Mail;
                TxtTelefon.Text = onRezervasyon.Telefon;
                TxtAciklama.Text = onRezervasyon.Aciklama;
                dateEditGiris.EditValue = onRezervasyon.GirisTarih;
                dateEditCikis.EditValue = onRezervasyon.CikisTarih;
                dateEditRezervasyonTarihi.EditValue = onRezervasyon.Tarih;
                numericUpDownKisi.Value = decimal.Parse(onRezervasyon.KisiSayisi);
            }

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
