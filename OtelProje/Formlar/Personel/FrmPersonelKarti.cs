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

namespace OtelProje.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }
        public int id;
        DbOtelEntities db = new DbOtelEntities();
        Repository<Tbl_Personel> repo = new Repository<Tbl_Personel>();

        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();

            if (id != 0)
            {
                var personel = repo.Find(x => x.PersonelId == id);
                TxtAdSoyad.Text = personel.PersonelAdSoyad;
                TxtTC.Text = personel.TC;
                TxtYabanciKimlik.Text = personel.YabanciKimlikNo;
                TxtAdres.Text = personel.Adres;
                TxtMail.Text = personel.Mail;
                TxtAciklama.Text = personel.Aciklama;
                TxtSifre.Text = personel.Sifre;
                TxtTelefon.Text = personel.Telefon;
                dateEditGiris.Text = personel.IseBaslamaTarihi.ToString();
                dateEditCikis.Text = personel.IstenCikisTarihi.ToString();
                pictureEditKimlikOn.Image = Image.FromFile(personel.KimlikOn);
                pictureEditKimlikArka.Image = Image.FromFile(personel.KimlikArka);
                Departman.EditValue = personel.Gorev;
                lookUpEdit2.EditValue = personel.Departman;
                labelControl17.Text = personel.KimlikArka;
                labelControl16.Text = personel.KimlikOn;

            }

            Departman.Properties.DataSource = (from x in db.Tbl_Departman
                                               select new
                                               {
                                                   x.DepartmanId,
                                                   x.DepartmanAd
                                               }).ToList();


            lookUpEdit2.Properties.DataSource = (from x in db.Tbl_Gorev
                                                 select new
                                                 {
                                                     x.GorevId,
                                                     x.GorevAdı
                                                 }).ToList();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Tbl_Personel t = new Tbl_Personel();
                t.PersonelAdSoyad = TxtAdSoyad.Text;
                // t.Sifre = TxtSifre.Text;
                t.KimlikOn = pictureEditKimlikOn.GetLoadedImageLocation();
                t.KimlikArka = pictureEditKimlikArka.GetLoadedImageLocation();
                t.TC = TxtTC.Text;
                t.YabanciKimlikNo = TxtYabanciKimlik.Text;
                t.Adres = TxtAdres.Text;
                t.Telefon = TxtTelefon.Text;
                t.Mail = TxtMail.Text;
                t.IseBaslamaTarihi = DateTime.Parse(dateEditGiris.Text);
                t.Departman = int.Parse(Departman.EditValue.ToString());
                t.Gorev = int.Parse(lookUpEdit2.EditValue.ToString());
                t.Aciklama = TxtAciklama.Text;
                t.Durum = 1;
                repo.TAdd(t);
                XtraMessageBox.Show("Personel Başarılı Bir Şekilde Sisteme Kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Personel Sisteme Kaydedilemedi.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.PersonelId == id);
            deger.PersonelAdSoyad = TxtAdSoyad.Text;
            deger.Sifre = TxtSifre.Text;
            deger.KimlikOn = labelControl17.Text;
            deger.KimlikArka = labelControl16.Text;
            deger.TC = TxtTC.Text;
            deger.YabanciKimlikNo = TxtYabanciKimlik.Text;
            deger.Adres = TxtAdres.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Mail = TxtMail.Text;
            deger.IseBaslamaTarihi = DateTime.Parse(dateEditGiris.Text);
            deger.Departman = int.Parse(Departman.EditValue.ToString());
            deger.Gorev = int.Parse(lookUpEdit2.EditValue.ToString());
            deger.Aciklama = TxtAciklama.Text;
            repo.TUpdate(deger);
            XtraMessageBox.Show("Personel Kartı Başarıyla Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            labelControl16.Text = pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            labelControl17.Text = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }

        private void BtnVagec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
