using SamanProject.Models;
using SamanProject.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SamanProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        // Duzenleme Ekleneçek
        // Detaylar Eklenecek
        private Islemler _islem = new Islemler();
        #region Giris / Cıkış / Hata /Index
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Giris()
        {
            return View();

        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Giris(FormCollection d, string returnUrl)
        {
            string kullanici = d["username"];
            string sifre = d["password"];
            if (kullanici != null && kullanici != "" && sifre != null && sifre != "")
            {
                FormsAuthentication.SetAuthCookie(kullanici, true, returnUrl);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Index");
        }
        public ActionResult Hata(string Info)
        {
            ViewBag.hata = Info.ToString();
            return View();
        }
        #endregion

        #region Personel İslemleri
        public ActionResult personelListesi()
        {
            List<PersonelSurrogate> list = _islem.personelListesi();
            return View(list.ToList());
        }
        public ActionResult personelEkle()
        {
            return View();
        }
        [HttpPost] // Eksik var ..!
        public ActionResult personelEkle(FormCollection d)
        {
            //adi- soyadi-telefon-gorevi-baslamatarihi-sgk
            //maas-yapilanodeme-iscikistarihi
            string adi = d["adi"];
            string soyadi = d["soyadi"];
            if (adi != "" && adi != null && soyadi != "" && soyadi != null)
            {
                PersonelSurrogate p = new PersonelSurrogate();
                // Kontroller yapıldıktan sonra 
                // birazdaha kontrol
                p.Adi = adi;
                p.BaslamaTarihi = d["baslamatarihi"];
                p.Gorevi = d["gorevi"];
                p.IscikisTarihi = d["iscikistarihi"];
                p.Maas = Convert.ToDecimal(d["maas"]);
                p.Not = d["not"];
                p.Sgk = d["sgk"];
                p.Soyadi = soyadi;
                p.Tarih = DateTime.Now.ToString();
                p.Telefon = Convert.ToInt64(d["telefon"]);
                p.YapilanOdeme = Convert.ToDecimal(d["yapilanodeme"]);
                bool kontrol = _islem.personelEkle(p);
                if (kontrol)
                {
                    return RedirectToAction("personelListesi", "Home");
                }
                else
                {
                    return RedirectToAction("Hata", "Home", new { Info = "personel Eklenirken Hata Oluştu" });
                }
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Lütfen Formu Boş Bırakmayın" });
            }
        }
        public ActionResult personelSil(int Id)
        {
            bool kontrol = _islem.personelSil(Id);
            if (kontrol)
            {
                return RedirectToAction("personelListesi", "Home");
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Personel Silinirken Hata Oluştu" });
            }
        }
        #endregion

        #region Müşteri İslemleri
        public ActionResult musteriListesi()
        {
            List<MusteriSurrogate> liste = _islem.musteriListesi();
            return View(liste.ToList());
        }
        public ActionResult musteriEkle()
        {
            return View();
        }
        [HttpPost] // Eksik Var
        public ActionResult musteriEkle(FormCollection d)
        {
            string adi = d["adi"];
            if (adi != null && adi != "")
            {
                MusteriSurrogate m = new MusteriSurrogate();
                // kontroller olacak 
                m.Adres = d["adres"];
                m.Email = d["email"];
                m.MusteriAdi = adi;
                m.Tarih = d["tarih"];
                m.Telefon = Convert.ToInt32(d["telefon"]);
                m.VergiNo = Convert.ToInt32(d["vergino"]);

                bool kontrol = _islem.musteriEkle(m);
                if (kontrol)
                {
                    return RedirectToAction("musteriListesi", "Home");
                }
                else
                {
                    return RedirectToAction("Hata", "Home", new { Info = "Musteri Eklenirken Bir HAta Oluştu." });
                }
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Formu BOş Bırakmayın" });
            }
        }
        public ActionResult musteriSil(int Id)
        {
            bool kontrol = _islem.musteriSil(Id);
            if (kontrol)
            {
                return RedirectToAction("musteriListesi", "Home");
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Musteri Silinirken Hata Oluştu" });
            }
        }
        #endregion

        #region BalyaSaman / CuvalSaman
        public ActionResult bsamanListesi()
        {
            List<BalyaSamanSurrogate> liste = _islem.bsamanListesi();
            return View(liste.ToList());
        }
        public ActionResult bsamanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult bsamanEkle(FormCollection d)
        {
            string tarih = d["tarih"];
            if (tarih != null && tarih != "")
            {
                BalyaSamanSurrogate b = new BalyaSamanSurrogate();

                b.BasilanSaman = Convert.ToInt32(d["basilan"]);
                b.SevkEdilenSaman = Convert.ToInt32(d["sevkedilen"]);
                b.StokSaman = Convert.ToInt32(d["stok"]);
                b.Tarih = tarih;

                bool kontrol = _islem.bsamanEkle(b);
                if (kontrol)
                {
                    return RedirectToAction("bsamanListesi", "Home");
                }
                else
                {
                    return RedirectToAction("Hata", "Home", new { Info = "Balya Saman Eklemede Hata Oluştu" });
                }
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Formu Boş Bırakmayın" });
            }
        }
        public ActionResult bsamanSil(int Id)
        {
            bool kontrol = _islem.bsamanSil(Id);
            if (kontrol)
            {
                return RedirectToAction("bsamanListesi", "Home");
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Balya Saman Silinirken hata Oluştu" });
            }
        }


        public ActionResult csamanListesi()
        {
            List<CuvalliSamanSurrogate> liste = _islem.csamanListesi();
            return View(liste.ToList());
        }
        public ActionResult csamanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult csamanEkle(FormCollection d)
        {
            string tarih = d["tarih"];
            if (tarih != null && tarih != "")
            {
                CuvalliSamanSurrogate c = new CuvalliSamanSurrogate();
                c.Tarih = tarih;
                c.BasilanCuval = Convert.ToInt32(d["basilan"]);
                c.SevkEdilenCuval = Convert.ToInt32(d["sevkedilen"]);
                c.StokCuval = Convert.ToInt32(d["stok"]);
                bool kontrol = _islem.csamanEkle(c);
                if (kontrol)
                {
                    return RedirectToAction("csamanListesi", "Home");
                }
                else
                {
                    return RedirectToAction("Hata", "Home", new { Info = "Cuval saman Eklerken Hata Oluştu" });
                }
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Formu Boş Bırakmyın" });
            }
        }
        public ActionResult csamanSil(int Id)
        {
            bool kontrol = _islem.csamanSil(Id);
            if (kontrol)
            {
                return RedirectToAction("csamanListesi", "Home");
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Cuval Saman Silinirken Hata Oluştu" });
            }
        }


        #endregion

        #region Tutulan Tarlalar
        public ActionResult tarlaListesi()
        {
            List<TutulanTarlalarSurrogate> liste = _islem.tarlaListesi();
            return View(liste.ToList());
        }
        public ActionResult tarlaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult tarlaEkle(FormCollection d)
        {
            string adi = d["adi"];
            if (adi != null && adi != "")
            {
                TutulanTarlalarSurrogate t = new TutulanTarlalarSurrogate();
                t.AdSoyad = adi;
                t.AlinanBalyaAdeti = Convert.ToInt32(d["alinanbalyaadet"]);
                t.CikanBalyaAdeti = Convert.ToInt32(d["cikanbalyaadet"]);
                t.Donum = Convert.ToInt32(d["donum"]);
                t.DonumTutar = Convert.ToDecimal(d["donumtutar"]);
                t.KalanBorc = Convert.ToDecimal(d["kalanborc"]);
                t.Not = d["not"];
                t.Odeme = Convert.ToDecimal(d["odeme"]);
                t.Tarih = d["tarih"];
                t.Telefon = Convert.ToInt32(d["telefon"]);

                bool kontrol = _islem.tarlaEkle(t);
                if (kontrol)
                {
                    return RedirectToAction("tarlaListesi", "Home");
                }
                else
                {
                    return RedirectToAction("Hata", "Home", new { Info = "Tutulan Tarka Eklenirken Hata Oluştu" });
                }
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Formu Boş Bırakmayın" });
            }
        }
        public ActionResult tarlaSil(int Id)
        {
            bool kontrol = _islem.tarlaSil(Id);
            if (kontrol)
            {
                return RedirectToAction("tarlaListesi", "Home");
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Tutulan Tarla Silinirken Hata Oluşturdu" });
            }
        }
        #endregion

        #region Yakıt
        public ActionResult yakitListesi()
        {
            List<YakitGiderSurrogate> liste = _islem.yakitListesi();
            return View(liste.ToList());
        }
        public ActionResult yakitEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yakitEkle(FormCollection d)
        {
            string personela = d["personela"];
            string araca = d["araca"];
            if (personela != null && personela != "" && araca != "" && araca != null)
            {
                YakitGiderSurrogate y = new YakitGiderSurrogate();
                y.AldigiLitre = Convert.ToInt32(d["aldigilitre"]);
                y.AracAdi = araca;
                y.LitreFiyati = Convert.ToDecimal(d["litrefiyati"]);
                y.Not = d["not"];
                y.PersonelAdi = personela;
                y.PetrolAdi = d["petrola"];
                y.Tarih = d["tarih"];
                y.ToplamTutar = Convert.ToDecimal(d["toplamtutar"]);

                bool kontrol = _islem.yakitEkle(y);
                if (kontrol)
                {
                    return RedirectToAction("yakitListesi", "Home");
                }
                else
                {
                    return RedirectToAction("Hata", "Home", new { Info = "Yakıt Ekleme İşleminde Hata Oluştu" });
                }
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Formu Boş Bırakmayın" });
            }
        }
        public ActionResult yakitSil(int Id)
        {
            bool kontrol = _islem.yakitSil(Id);
            if (kontrol)
            {
                return RedirectToAction("yakitListesi", "Home");
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Yakit Verisi Silinirken Hata Oluştu" });
            }
        }
        #endregion

        #region Araç
        public ActionResult aracListesi()
        {
            List<AraclarSurrogate> liste = _islem.aracListesi();
            return View(liste.ToList());
        }
        public ActionResult aracEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult aracEkle(FormCollection d)
        {
            string personelAdi = d["personela"];
            string aracAdi = d["araca"];
            if (personelAdi != "" && personelAdi != null && aracAdi != "" && aracAdi != null)
            {
                AraclarSurrogate a = new AraclarSurrogate();
                a.AracAdi = aracAdi;
                a.Model = d["model"];
                a.Not = d["not"];
                a.PersonelAdi = personelAdi;
                a.Plaka = d["plaka"];
                bool kontrol = _islem.aracEkle(a);
                if (kontrol)
                {
                    return RedirectToAction("aracListesi", "Home");
                }
                else
                {
                    return RedirectToAction("Hata", "Home", new { Info = "Araç Eklem  Hata Oluştu" });
                }
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Formu Doldurunuz" });
            }
        }
        public ActionResult aracSil(int Id)
        {
            bool kontrol = _islem.aracSil(Id);
            if (kontrol)
            {
                return RedirectToAction("aracListesi", "Home");
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Araç Silinirken Hata Oluştu" });
            }
        }

        #endregion

        #region Petrol

        public ActionResult petrolListesi()
        {
            List<PetrollerSurrogate> liste = _islem.petrolListesi();
            return View(liste.ToList());
        }
        public ActionResult petrolEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult petrolEkle(FormCollection d)
        {
            string yetkili = d["adi"];
            string petroladi = d["petrola"];
            if (yetkili != "" && yetkili != null && petroladi != "" && petroladi != null)
            {
                PetrollerSurrogate p = new PetrollerSurrogate();
                p.Email = d["email"];
                p.KalanBorc = Convert.ToDecimal(d["kalanborc"]);
                p.OdenenPara = Convert.ToDecimal(d["odenenpara"]);
                p.PetrolAdi = petroladi;
                p.PetrolAdresi = d["petroladresi"];
                p.Telefon = Convert.ToInt32(d["telefon"]);
                p.ToplamTutar = Convert.ToDecimal(d["toplamtutar"]);
                p.YetkiliAdi = yetkili;

                bool kontrol = _islem.petrolEkle(p);
                if (kontrol)
                {
                    return RedirectToAction("petrolListesi", "Home");
                }
                else
                {
                    return RedirectToAction("Hata", "Home", new { Info = "Petrol Eklenirken Hata Oluştu" });
                }
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Formu BOş Bırakmayın" });
            }
        }
        public ActionResult petrolSil(int Id)
        {
            bool kontrol = _islem.petrolSil(Id);
            if (kontrol)
            {
                return RedirectToAction("petrolListesi", "Home");
            }
            else
            {
                return RedirectToAction("Hata", "Home", new { Info = "Petrol Silinirken Hata Oluştu" });
            }
        }

        #endregion


    }
}
