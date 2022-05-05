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

namespace OtelProje.Formlar.Urun
{
    public partial class FrmUrunHareketTanimi : Form
    {
        public FrmUrunHareketTanimi()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        Repository<Tbl_UrunHareket> repo = new Repository<Tbl_UrunHareket>();
        Tbl_UrunHareket t = new Tbl_UrunHareket();
        public int id;
        private void FrmUrunHareketTanimi_Load(object sender, EventArgs e)
        {
            TxtId.Text = id.ToString();
            //urun grup listeleme
            lookUpEditUrun.Properties.DataSource = (from x in db.Tbl_Urun
                                                        select new
                                                        {
                                                            x.UrunId,
                                                            x.UrunAd
                                                        }).ToList();
            //personel listeleme
            lookUpEditPersonel.Properties.DataSource = (from x in db.Tbl_Personel
                                                    select new
                                                    {
                                                        x.PersonelId,
                                                        x.PersonelAdSoyad,
                                                        x.Tbl_Gorev.GorevAdı
                                                    }).ToList();

            //Urun Guncelleme Alanı 
            if (id != 0)
            {
                var urun = repo.Find(x => x.UrunHareketId == id);
                lookUpEditUrun.EditValue = urun.Urun;
                lookUpEditPersonel.EditValue = urun.Personel;
                TxtAciklama.Text = urun.Aciklama;
                CmbHareket.Text = urun.HareketTürü;
                dateEdit1.Text = urun.Tarih.ToString();
                TxtMiktar.Text = urun.Miktar.ToString();

            }
        }

        private void BtnVagec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
            t.Miktar = decimal.Parse(TxtMiktar.Text);
            t.HareketTürü = CmbHareket.Text;
            t.Personel = int.Parse(lookUpEditPersonel.EditValue.ToString());
            t.Aciklama = TxtAciklama.Text;
            t.Tarih = DateTime.Parse(dateEdit1.Text);
            repo.TAdd(t);
            XtraMessageBox.Show("Ürün Hareketi Başarıyla Kaydedildi.", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.UrunHareketId == id);
            deger.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
            deger.Personel = int.Parse(lookUpEditPersonel.EditValue.ToString());
            deger.Aciklama = TxtAciklama.Text;
            deger.HareketTürü = CmbHareket.Text;
            deger.Miktar = decimal.Parse(TxtMiktar.Text);
            deger.Tarih = DateTime.Parse(dateEdit1.Text);
            repo.TUpdate(deger);
            XtraMessageBox.Show("Ürün Hareketi GÜncellenmesi Başarıyla Yapılmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
    }
}
