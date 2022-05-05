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

namespace OtelProje.Formlar.Misafirler
{
    public partial class FrmMisafirKarti : Form
    {
        public FrmMisafirKarti()
        {
            InitializeComponent();
        }
        public int id;
        DbOtelEntities db = new DbOtelEntities();
        Repository<Tbl_Misafir> repo = new Repository<Tbl_Misafir>();
        Tbl_Misafir t = new Tbl_Misafir();
        private void FrmMisafirKarti_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();

            try
            {
                //Güncellenecek Kart Bilgileri 
                if (id != 0)
                {
                    var misafir = repo.Find(x => x.MisafirId == id);
                    TxtAdSoyad.Text = misafir.MisafirAdSoyad;
                    TxtTC.Text = misafir.TC;
                    TxtYabanciKimlik.Text = misafir.YabanciKimlikNo;
                    TxtAdres.Text = misafir.Adres;
                    TxtMail.Text = misafir.Mail;
                    TxtAciklama.Text = misafir.Aciklama;
                    lookUpEditUlke.EditValue = misafir.Ulke;
                    lookUpEditSehir.EditValue = misafir.Sehir;
                    lookUpEditIlce.EditValue = misafir.Ilce;
                    TxtTelefon.Text = misafir.Telefon;
                    pictureEditKimlikOn.Image = Image.FromFile(misafir.KimlikFoto1);
                    pictureEditKimlikArka.Image = Image.FromFile(misafir.KimlikFoto2);
                    resim1 = misafir.KimlikFoto1;
                    resim2 = misafir.KimlikFoto2;

                }
            }
            catch (Exception)
            {
             MessageBox.Show("Bir Hata Meydana Geldi! Lütfen Sütunları Kontrol Ediniz.","Hata" ,MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }


            
           
            //Ülke Listesi 
            lookUpEditUlke.Properties.DataSource = (from x in db.Tbl_Ulke
                                                    select new
                                                    {
                                                        x.UlkeId,
                                                        x.UlkeAd
                                                    }).ToList();
            //iller Listesi 
            lookUpEditSehir.Properties.DataSource = (from x in db.iller
                                                     select new
                                                     {
                                                         x.id,
                                                         x.sehir
                                                     }).ToList();

        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditSehir.EditValue.ToString());

            lookUpEditIlce.Properties.DataSource = (from x in db.ilceler
                                                    select new
                                                    {
                                                        Id = x.id,
                                                        Ilce = x.ilce,
                                                        sehir = x.sehir

                                                    }).Where(y => y.sehir == secilen).ToList();

        }

        string resim1, resim2;

        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            resim1 = pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            resim2 = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.MisafirId == id);
            deger.MisafirAdSoyad = TxtAdSoyad.Text;
            deger.KimlikFoto1 = resim1;
            deger.KimlikFoto2 = resim2;
            deger.TC = TxtTC.Text;
            deger.YabanciKimlikNo = TxtYabanciKimlik.Text;
            deger.Adres = TxtAdres.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Mail = TxtMail.Text;
            deger.Sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
            deger.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            deger.Ilce = int.Parse(lookUpEditIlce.EditValue.ToString());
            deger.Aciklama = TxtAciklama.Text;
            repo.TUpdate(deger);
            XtraMessageBox.Show("Misafir Kartı Başarıyla Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnVagec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            t.MisafirAdSoyad = TxtAdSoyad.Text;
            t.YabanciKimlikNo = TxtYabanciKimlik.Text;
            t.Mail = TxtMail.Text;
            t.TC = TxtTC.Text;
            t.Telefon = TxtTelefon.Text;
            t.Aciklama = TxtAciklama.Text;
            t.Adres = TxtAdres.Text;
            t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            t.Durum = 1;
            t.Sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
            t.Ilce = int.Parse(lookUpEditIlce.EditValue.ToString());
            t.KimlikFoto1 = resim1;
            t.KimlikFoto2 = resim2;
            repo.TAdd(t);
            XtraMessageBox.Show("Misafir Girişi Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
    }
}
