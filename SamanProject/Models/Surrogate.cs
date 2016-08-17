using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamanProject.Models
{
    public class Surrogate
    {
    }
    public class UsersModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
    }
    public class RolesModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
    public class UsersInRoleModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class KullaniciSurrogate
    {
        public int Id { get; set; }
        public string HesabAdi { get; set; }
        public string Sifre { get; set; }
        public string Adi { get; set; }
        public string Email { get; set; }
    }

    public class PersonelSurrogate
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public long Telefon { get; set; }
        public string Gorevi { get; set; }
        public string BaslamaTarihi { get; set; }
        public string Sgk { get; set; }
        public decimal Maas { get; set; }
        public decimal YapilanOdeme { get; set; }
        public string IscikisTarihi { get; set; }
        public string Not { get; set; }
        public string Tarih { get; set; }
    }
    public class MusteriSurrogate
    {
        public int Id { get; set; }
        public string MusteriAdi { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public int VergiNo { get; set; }
        public string Tarih { get; set; }
    }
    public class MusteriCariHesabSurrogate
    {
        public int Id { get; set; }
        public string Tarih { get; set; }
        public string Plaka { get; set; }
        public int Adet { get; set; }
        public int Tonas { get; set; }
        public decimal Satis { get; set; }
        public decimal OdenenNakliyeUcreti { get; set; }
        public decimal KalanAlacak { get; set; }
        public decimal Tahsilat { get; set; }
        public decimal Bakiye { get; set; }
        public int IrsaliyeNo { get; set; }
        public int FaturaNo { get; set; }
        public string Alici { get; set; }
        public string Not { get; set; }
    }
    public class BalyaSamanSurrogate
    {
        public int Id { get; set; }
        public string Tarih { get; set; }
        public int BasilanSaman { get; set; }
        public int SevkEdilenSaman { get; set; }
        public int StokSaman { get; set; }
    }
    public class CuvalliSamanSurrogate
    {
        public int Id { get; set; }
        public string Tarih { get; set; }
        public int BasilanCuval { get; set; }
        public int SevkEdilenCuval { get; set; }
        public int StokCuval { get; set; }
    }
    public class TutulanTarlalarSurrogate
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public int Telefon { get; set; }
        public int Donum { get; set; }
        public decimal DonumTutar { get; set; }
        public int CikanBalyaAdeti { get; set; }
        public int AlinanBalyaAdeti { get; set; }
        public decimal Odeme { get; set; }
        public decimal KalanBorc { get; set; }
        public string Not { get; set; }
        public string Tarih { get; set; }
    }
    public class YakitGiderSurrogate
    {
        public int Id { get; set; }
        public string PersonelAdi { get; set; } // Alan Personel
        public string AracAdi { get; set; }
        public string PetrolAdi { get; set; }
        public string Tarih { get; set; }
        public int AldigiLitre { get; set; }
        public decimal LitreFiyati { get; set; }
        public decimal ToplamTutar { get; set; }
        public string Not { get; set; }
    }
    public class AraclarSurrogate
    {
        public int Id { get; set; }
        public string PersonelAdi { get; set; }
        public string AracAdi { get; set; }
        public string Plaka { get; set; }
        public string Model { get; set; }
        public string Not { get; set; }
    }
    public class PetrollerSurrogate
    {
        public int Id { get; set; }
        public string YetkiliAdi { get; set; }
        public string PetrolAdi { get; set; }
        public string PetrolAdresi { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public decimal OdenenPara { get; set; }
        public decimal KalanBorc { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}
