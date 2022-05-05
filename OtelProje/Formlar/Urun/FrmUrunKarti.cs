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
    public partial class FrmUrunKarti : Form
    {
        public FrmUrunKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        Repository<Tbl_Urun> repo = new Repository<Tbl_Urun>();
        Tbl_Urun t = new Tbl_Urun();
        public int id;
        private void FrmUrunKarti_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();

            //urun grup listeleme
            lookUpEditUrunGrup.Properties.DataSource = (from x in db.Tbl_UrunGrup
                                                        select new
                                                        {
                                                            x.UrunGrupId,
                                                            x.UrunGrupAd
                                                        }).ToList();

            //birim listeleme
            lookUpEditBirim.Properties.DataSource = (from x in db.Tbl_Birim
                                                        select new
                                                        {
                                                            x.BirimId,
                                                            x.BirimAd
                                                        }).ToList();

            lookUpEditDurum.Properties.DataSource = (from x in db.Tbl_Durum
                                                        select new
                                                        {
                                                           x.DurumId,
                                                           x.DurumAd
                                                        }).ToList();

            //Urun Guncelleme Alanı 
            if(id != 0)
            {
                var urun = repo.Find(x => x.UrunId == id);
                TxtUrunAd.Text = urun.UrunAd;
                lookUpEditUrunGrup.EditValue = urun.UrunGrup;
                lookUpEditBirim.EditValue = urun.UrunBirim;
                lookUpEditDurum.EditValue = urun.Durum;
                TxtUrunFiyat.Text = urun.UrunFiyat.ToString();
                TxtToplam.Text = urun.Toplam.ToString();
                TxtKDV.Text = urun.KDV.ToString();
                
            }
        }

        private void BtnVagec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.UrunAd = TxtUrunAd.Text;
            t.UrunGrup = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
            t.UrunBirim = int.Parse(lookUpEditBirim.EditValue.ToString());
            t.UrunFiyat =decimal.Parse(TxtUrunFiyat.Text);
            t.Toplam = decimal.Parse(TxtToplam.Text);
            t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            repo.TAdd(t);
            XtraMessageBox.Show("Ürün Girişi Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.UrunId == id);
            deger.UrunAd = TxtUrunAd.Text;
            deger.UrunGrup = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
            deger.UrunBirim = int.Parse(lookUpEditBirim.EditValue.ToString());
            deger.UrunFiyat = decimal.Parse(TxtUrunFiyat.Text);
            deger.Toplam = decimal.Parse(TxtToplam.Text);
            deger.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            repo.TUpdate(deger);
            XtraMessageBox.Show("Ürün GÜncellenmesi Başarıyla Yapılmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Rdb1_CheckedChanged(object sender, EventArgs e)
        {
            TxtKDV.Text = "1";
        }

        private void Rdb2_CheckedChanged(object sender, EventArgs e)
        {
            TxtKDV.Text = "18";
        }

        private void Rdb4_CheckedChanged(object sender, EventArgs e)
        {
            TxtKDV.Text = "10";
        }

        private void Rdb3_CheckedChanged(object sender, EventArgs e)
        {
            TxtKDV.Text = "8";
        }
    }
}
