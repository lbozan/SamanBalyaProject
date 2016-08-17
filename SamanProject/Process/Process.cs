using SamanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamanProject.Process
{
    public class Islemler : IDisposable
    {
        private SamanDbEntities _db;
        private List<PersonelSurrogate> _personel;
        private List<MusteriSurrogate> _musteri;
        private List<BalyaSamanSurrogate> _balyaSaman;
        private List<CuvalliSamanSurrogate> _cuvalSaman;
        private List<TutulanTarlalarSurrogate> _tarla;
        private List<YakitGiderSurrogate> _yakit;
        private List<AraclarSurrogate> _arac;
        private List<PetrollerSurrogate> _petrol;
        public Islemler()
        {
            _db = new SamanDbEntities();
            _personel = new List<PersonelSurrogate>();
            _musteri = new List<MusteriSurrogate>();
            _balyaSaman = new List<BalyaSamanSurrogate>();
            _cuvalSaman = new List<CuvalliSamanSurrogate>();
            _tarla = new List<TutulanTarlalarSurrogate>();
            _yakit = new List<YakitGiderSurrogate>();
            _arac = new List<AraclarSurrogate>();
            _petrol = new List<PetrollerSurrogate>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool p)
        {
            if (p)
            {
                _db.Dispose();
            }
        }

        internal List<PersonelSurrogate> personelListesi()
        {
            try
            {
                _db.Personel.ToList().ForEach(x => _personel.Add(new PersonelSurrogate()
                {
                    Id = x.Id,
                    Adi = x.Adi,
                    BaslamaTarihi = x.BaslamaTarihi,
                    Gorevi = x.Gorevi,
                    IscikisTarihi = x.IsCikisTarihi,
                    Maas = (decimal)x.Maas,
                    Not = x.Not,
                    Sgk = x.Sgk,
                    Soyadi = x.Soyadi,
                    Tarih = x.Tarih,
                    Telefon = (long)x.Telefon,
                    YapilanOdeme = (decimal)x.YapilanOdeme
                }));
                return _personel;
            }
            catch
            {
                return _personel;
            }
        }

        internal bool personelEkle(PersonelSurrogate p)
        {
            try
            {
                _db.Personel.Add(new Personel()
                {
                    Adi = p.Adi,
                    YapilanOdeme = p.YapilanOdeme,
                    Telefon = p.Telefon,
                    BaslamaTarihi = p.BaslamaTarihi,
                    Gorevi = p.Gorevi,
                    IsCikisTarihi = p.IscikisTarihi,
                    Maas = p.Maas,
                    Not = p.Not,
                    Sgk = p.Sgk,
                    Soyadi = p.Soyadi,
                    Tarih = p.Tarih
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool personelSil(int Id)
        {
            try
            {
                var sil = _db.Personel.Single(x => x.Id == Id);
                _db.Personel.Remove(sil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal List<MusteriSurrogate> musteriListesi()
        {
            try
            {
                _db.Musteri.ToList().ForEach(x => _musteri.Add(new MusteriSurrogate()
                {
                    Id = x.Id,
                    Adres = x.Adres,
                    Email = x.Email,
                    MusteriAdi = x.MusteriAdi,
                    Tarih = x.Tarih,
                    Telefon = (int)x.Telefon,
                    VergiNo = (int)x.VergiNo
                }));
                return _musteri;
            }
            catch
            {
                return _musteri;
            }
        }

        internal bool musteriEkle(MusteriSurrogate m)
        {
            try
            {
                _db.Musteri.Add(new Musteri()
                {
                    Adres = m.Adres,
                    Email = m.Email,
                    MusteriAdi = m.MusteriAdi,
                    Tarih = m.Tarih,
                    Telefon = m.Telefon,
                    VergiNo = m.VergiNo
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool musteriSil(int Id)
        {
            try
            {
                var sil = _db.Musteri.Single(x => x.Id == Id);
                _db.Musteri.Remove(sil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal List<BalyaSamanSurrogate> bsamanListesi()
        {
            try
            {
                _db.BalyaSaman.ToList().ForEach(x => _balyaSaman.Add(new BalyaSamanSurrogate()
                {
                    Id = x.Id,
                    BasilanSaman = (int)x.BasilanSaman,
                    SevkEdilenSaman = (int)x.SevkEdilenSaman,
                    StokSaman = (int)x.StokSaman,
                    Tarih = x.Tarih
                }));
                return _balyaSaman;
            }
            catch
            {
                return _balyaSaman;
            }
        }

        internal List<CuvalliSamanSurrogate> csamanListesi()
        {
            try
            {
                _db.CuvalSaman.ToList().ForEach(x => _cuvalSaman.Add(new CuvalliSamanSurrogate()
                {
                    Id = x.Id,
                    BasilanCuval = (int)x.BasilanCuval,
                    SevkEdilenCuval = (int)x.SevkEdilenCuval,
                    StokCuval = (int)x.StokCuval,
                    Tarih = x.Tarih
                }));
                return _cuvalSaman;
            }
            catch
            {
                return _cuvalSaman;
            }
        }

        internal bool bsamanEkle(BalyaSamanSurrogate b)
        {
            try
            {
                _db.BalyaSaman.Add(new BalyaSaman()
                {
                    BasilanSaman = b.BasilanSaman,
                    SevkEdilenSaman = b.SevkEdilenSaman,
                    StokSaman = b.StokSaman,
                    Tarih = b.Tarih
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool csamanEkle(CuvalliSamanSurrogate c)
        {
            try
            {
                _db.CuvalSaman.Add(new CuvalSaman()
                {
                    BasilanCuval = c.BasilanCuval,
                    SevkEdilenCuval = c.SevkEdilenCuval,
                    StokCuval = c.StokCuval,
                    Tarih = c.Tarih
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool bsamanSil(int Id)
        {
            try
            {
                var sil = _db.BalyaSaman.Single(x => x.Id == Id);
                _db.BalyaSaman.Remove(sil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool csamanSil(int Id)
        {
            try
            {
                var sil = _db.CuvalSaman.Single(x => x.Id == Id);
                _db.CuvalSaman.Remove(sil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal List<TutulanTarlalarSurrogate> tarlaListesi()
        {
            try
            {
                _db.TutulanTarlalar.ToList().ForEach(x => _tarla.Add(new TutulanTarlalarSurrogate()
                {
                    Id = x.Id,
                    AdSoyad = x.AdSoyad,
                    AlinanBalyaAdeti = (int)x.AlinanBalyaAdeti,
                    CikanBalyaAdeti = (int)x.CikanBalyaAdeti,
                    Donum = (int)x.Donum,
                    DonumTutar = (decimal)x.DonumTutari,
                    KalanBorc = (decimal)x.KalanBorc,
                    Not = x.Not,
                    Odeme = (decimal)x.Odeme,
                    Tarih = x.Tarih,
                    Telefon = (int)x.Telefon

                }));
                return _tarla;
            }
            catch
            {
                return _tarla;
            }
        }

        internal bool tarlaEkle(TutulanTarlalarSurrogate t)
        {
            try
            {
                _db.TutulanTarlalar.Add(new TutulanTarlalar()
                {
                    AdSoyad = t.AdSoyad,
                    AlinanBalyaAdeti = t.AlinanBalyaAdeti,
                    CikanBalyaAdeti = t.CikanBalyaAdeti,
                    Donum = t.Donum,
                    DonumTutari = t.DonumTutar,
                    KalanBorc = t.KalanBorc,
                    Not = t.Not,
                    Odeme = t.Odeme,
                    Tarih = t.Tarih,
                    Telefon = t.Telefon
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool tarlaSil(int Id)
        {
            try
            {
                var sil = _db.TutulanTarlalar.Single(x => x.Id == Id);
                _db.TutulanTarlalar.Remove(sil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal List<YakitGiderSurrogate> yakitListesi()
        {
            try
            {
                _db.YakitGider.ToList().ForEach(x => _yakit.Add(new YakitGiderSurrogate()
                {
                    Id = x.Id,
                    AldigiLitre = (int)x.AldigiLitre,
                    AracAdi = x.AracAdi,
                    LitreFiyati = (decimal)x.LitreFiyati,
                    Not = x.Not,
                    PersonelAdi = x.PersonelAdi,
                    PetrolAdi = x.PetrolAdi,
                    Tarih = x.Tarih,
                    ToplamTutar = (decimal)x.ToplamTutar

                }));
                return _yakit;
            }
            catch
            {
                return _yakit;
            }
        }

        internal bool yakitEkle(YakitGiderSurrogate y)
        {
            try
            {
                _db.YakitGider.Add(new YakitGider()
                {
                    AldigiLitre = y.AldigiLitre,
                    AracAdi = y.AracAdi,
                    LitreFiyati = y.LitreFiyati,
                    Not = y.Not,
                    PersonelAdi = y.PersonelAdi,
                    PetrolAdi = y.PetrolAdi,
                    Tarih = y.Tarih,
                    ToplamTutar = y.ToplamTutar
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool yakitSil(int Id)
        {
            try
            {
                var sil = _db.YakitGider.Single(x => x.Id == Id);
                _db.YakitGider.Remove(sil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal List<AraclarSurrogate> aracListesi()
        {
            try
            {
                _db.Araclar.ToList().ForEach(x => _arac.Add(new AraclarSurrogate()
                {
                    Id = x.Id,
                    AracAdi = x.AracAdi,
                    Model = x.Model,
                    Not = x.Not,
                    PersonelAdi = x.PersonelAdi,
                    Plaka = x.Plaka
                }));
                return _arac;
            }
            catch
            {
                return _arac;
            }
        }

        internal bool aracEkle(AraclarSurrogate a)
        {
            try
            {
                _db.Araclar.Add(new Araclar()
                {
                    AracAdi = a.AracAdi,
                    Model = a.Model,
                    Not = a.Not,
                    PersonelAdi = a.PersonelAdi,
                    Plaka = a.Plaka
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool aracSil(int Id)
        {
            try
            {
                var sil = _db.Araclar.Single(x => x.Id == Id);
                _db.Araclar.Remove(sil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal List<PetrollerSurrogate> petrolListesi()
        {
            try
            {
                _db.Petroller.ToList().ForEach(x => _petrol.Add(new PetrollerSurrogate()
                {
                    Id = x.Id,
                    Email = x.Email,
                    KalanBorc = (decimal)x.KalanBorc,
                    OdenenPara = (decimal)x.OdenenPara,
                    PetrolAdi = x.PetrolAdi,
                    PetrolAdresi = x.PetrolAdresi,
                    Telefon = (int)x.Telefon,
                    ToplamTutar = (decimal)x.ToplamTutar,
                    YetkiliAdi = x.YetkiliAdi
                }));
                return _petrol;
            }
            catch
            {
                return _petrol;
            }
        }

        internal bool petrolEkle(PetrollerSurrogate p)
        {
            try
            {
                _db.Petroller.Add(new Petroller()
                {
                    Email = p.Email,
                    KalanBorc = p.KalanBorc,
                    OdenenPara = p.OdenenPara,
                    PetrolAdi = p.PetrolAdi,
                    PetrolAdresi = p.PetrolAdresi,
                    Telefon = p.Telefon,
                    ToplamTutar = p.ToplamTutar,
                    YetkiliAdi = p.YetkiliAdi
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool petrolSil(int Id)
        {
            try
            {
                var sil = _db.Petroller.Single(x => x.Id == Id);
                _db.Petroller.Remove(sil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}