using DevExpress.XtraEditors;
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

namespace OtelProje.Formlar.Rezervasyon
{
    public partial class FrmRezervasyonKarti : Form
    {
        public FrmRezervasyonKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        Repository<Tbl_Rezarvasyon> repo = new Repository<Tbl_Rezarvasyon>();
        Tbl_Rezarvasyon t = new Tbl_Rezarvasyon();
        public int id;

        private void FrmRezervasyonKarti_Load(object sender, EventArgs e)
        {
            lookUpEditDurum.Properties.DataSource = (from x in db.Tbl_Durum
                                                     select new
                                                     {
                                                         x.DurumId,
                                                         x.DurumAd
                                                     }).ToList();

            lookUpEditMisafir.Properties.DataSource = (from x in db.Tbl_Misafir
                                                     select new
                                                     {
                                                         x.MisafirId,
                                                         x.MisafirAdSoyad
                                                     }).ToList();
            //Misafir Listesi1
            lookUpEditKisi1.Properties.DataSource = (from x in db.Tbl_Misafir
                                                       select new
                                                       {
                                                           x.MisafirId,
                                                           x.MisafirAdSoyad
                                                       }).ToList();
            //Misafir Listesi2
            lookUpEditKisi2.Properties.DataSource = (from x in db.Tbl_Misafir
                                                       select new
                                                       {
                                                           x.MisafirId,
                                                           x.MisafirAdSoyad
                                                       }).ToList();
            //Misafir Listesi3 
            lookUpEditKisi3.Properties.DataSource = (from x in db.Tbl_Misafir
                                                       select new
                                                       {
                                                           x.MisafirId,
                                                           x.MisafirAdSoyad
                                                       }).ToList();

            lookUpEditOda.Properties.DataSource = (from x in db.Tbl_Oda
                                                       select new
                                                       {
                                                           x.OdaId,
                                                           x.OdaNo,
                                                           x.Tbl_Durum.DurumAd
                                                       }).Where(x =>x.DurumAd=="Aktif").ToList();

            //Urun Guncelleme Alanı 
            if (id != 0)
            {
                var rezervasyon = repo.Find(x => x.RezervasyonId == id);
                lookUpEditMisafir.EditValue = rezervasyon.Misafir;
                dateEditGiris.EditValue = rezervasyon.GirisTarih.ToString();
                dateEditCikis.EditValue = rezervasyon.CikisTarih.ToString();
                numericUpDownKisi.Value = decimal.Parse(rezervasyon.KisiSayisi.ToString());
                lookUpEditOda.EditValue = rezervasyon.Oda;
                lookUpEditKisi1.EditValue = rezervasyon.Kisi1;
                lookUpEditKisi2.EditValue = rezervasyon.Kisi2;
                lookUpEditKisi3.EditValue = rezervasyon.Kisi3;
                lookUpEditDurum.EditValue = rezervasyon.Durum;
                TxtTelefon.EditValue = rezervasyon.Telefon;
                TxtMail.EditValue = rezervasyon.Mail;
                TxtAciklama.EditValue = rezervasyon.Aciklama;

            }
        }

        private void BtnVagec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (numericUpDownKisi.Value == 1)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            }
            if (numericUpDownKisi.Value == 2)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
            }
            if (numericUpDownKisi.Value == 3)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            }
            if (numericUpDownKisi.Value == 4)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                t.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            }

            //t.RezervasyonAdSoyad = TxtAdSoyad.Text;
            t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            t.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
            t.Aciklama = TxtAciklama.Text;
            t.KisiSayisi = numericUpDownKisi.Value.ToString();
            t.GirisTarih = DateTime.Parse(dateEditGiris.Text);
            t.CikisTarih = DateTime.Parse(dateEditCikis.Text);
            t.Telefon = TxtTelefon.Text;
            t.Mail = TxtMail.Text;
            repo.TAdd(t);
            XtraMessageBox.Show("Rezervasyon Girişi Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var rezervasyon = repo.Find(x => x.RezervasyonId == id);

           //kişi sayısına göre güncelleme ekranında lookupeditlerde isimlerin düzgün şekilde gelmesi için yukarıdaki sorguyu tekrar yaz...
            if (numericUpDownKisi.Value == 1)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            }
            if (numericUpDownKisi.Value == 2)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
            }
            if (numericUpDownKisi.Value == 3)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            }
            if (numericUpDownKisi.Value == 4)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                rezervasyon.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            }


            rezervasyon.GirisTarih = DateTime.Parse(dateEditGiris.Text);
            rezervasyon.CikisTarih = DateTime.Parse(dateEditCikis.Text);
            rezervasyon.KisiSayisi = numericUpDownKisi.Value.ToString();
            rezervasyon.Telefon = TxtTelefon.Text;
            rezervasyon.Mail = TxtMail.Text;
            rezervasyon.Aciklama = TxtAciklama.Text;
            rezervasyon.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
            rezervasyon.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());

            repo.TUpdate(rezervasyon);
            XtraMessageBox.Show("Rezervasyon GÜncellenmesi Başarıyla Yapılmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void lookUpEditMisafir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditMisafir.EditValue.ToString());
            var telefon = db.Tbl_Misafir.Where(x => x.MisafirId == secilen).Select(y => y.Telefon).FirstOrDefault();
            var mail = db.Tbl_Misafir.Where(x => x.MisafirId == secilen).Select(y => y.Mail).FirstOrDefault();
            var aciklama = db.Tbl_Misafir.Where(x => x.MisafirId == secilen).Select(y => y.Aciklama).FirstOrDefault();
            TxtTelefon.Text = telefon.ToString();
            TxtMail.Text = mail.ToString();
            TxtAciklama.Text = aciklama.ToString();

        }
    }
}
