using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsTakip.Models
{
    public class SiparislerDB : PersonelDB
    {
        public int ID { get; set; }
        public int PersonelID { get; set; }

        [DisplayName("Kağıt Gr.")]
        public int KagitGramiIc { get; set; }

        [DisplayName("Kapak Kağıt Gr.")]
        public int KagitGramiDis { get; set; }

        [DisplayName("Kağıt Cinsi")]
        public string KkagitCinsiIc { get; set; }

        [DisplayName("Kapak Kağıt Cinsi")]
        public string KkagitCinsiDis { get; set; }

        [DisplayName("Ebat")]
        public string KebatIc { get; set; }

        [DisplayName("Kapak Ebat")]
        public string KebatDis { get; set; }

        [DisplayName("Adet")]
        public int KadetIc { get; set; }

        [DisplayName("Adet")]
        public int KadetDis { get; set; }

        [DisplayName("Makine")]
        public string BmakinaIc { get; set; }

        [DisplayName("Kapak Makine")]
        public string BMakinaDis { get; set; }

        [DisplayName("Ebat")]
        public string BebatIc { get; set; }

        [DisplayName("Kapak Ebat")]
        public string BebatDis { get; set; }

        [DisplayName("Adet")]
        public string BadetIc { get; set; }

        [DisplayName("Kapak Adet")]
        public string BadetDis { get; set; }

        [DisplayName("Renk")]
        public string BrenkIc { get; set; }

        [DisplayName("Kapak Renk")]
        public string BrenkDis { get; set; }

        [DisplayName("Kalıp Sayısı")]
        public string BkalipIc { get; set; }

        [DisplayName("Kapak Kalıp")]
        public string BkalipDis { get; set; }

        [DisplayName("Baskı Şekli")]
        public string BbaskiIc { get; set; }
        public string BbaskiDis { get; set; }

        [DisplayName("Forma")]
        public string BformaIc { get; set; }

        [DisplayName("Kapak Forma")]
        public string BformaDis { get; set; }

        [DisplayName("Not")]
        public string Bnot { get; set; }

        [DisplayName("Selefon")]
        public string Sselefon { get; set; }

        [DisplayName("Kapak Selefon")]
        public string SselefonDis { get; set; }

        [DisplayName("Lak")]
        public string Slak { get; set; }

        [DisplayName("Kapak Lak")]
        public string SlakDis { get; set; }

        [DisplayName("Gofre")]
        public string Sgofre { get; set; }

        [DisplayName("Kapak Gofre")]
        public string SgofreDis { get; set; }

        [DisplayName("Varak")]
        public string Svarak { get; set; }

        [DisplayName("Varak")]
        public string SvarakDis { get; set; }

        [DisplayName("Perforaj")]
        public string Sperforaj { get; set; }

        [DisplayName("Perforaj Dış")]
        public String SperforajDis { get; set; }

        [DisplayName("Özel Kesim")]
        public string SozelKesim { get; set; }

        [DisplayName("Kapak Özel Kesim")]
        public string SozelKesimDİs { get; set; }

        [DisplayName("Cilt")]
        public string Scilt { get; set; }

        [DisplayName("Kapak Cilt")]
        public string SciltDis { get; set; }

        [DisplayName("Kırım")]
        public string Skirim { get; set; }

        [DisplayName("Kapak Kırım")]
        public string SkirimDis { get; set; }

        [DisplayName("Yapıştırma")]
        public string Syapistirma { get; set; }

        [DisplayName("Kapak Yapistırma")]
        public string SyapistirmaDis { get; set; }

        [DisplayName("Sıvama")]
        public string Ssivama { get; set; }

        [DisplayName("Kapak Sıvama")]
        public string SsivamaDis { get; set; }

        [DisplayName("Taslama")]
        public string Staslama { get; set; }

        public string StaslamaDis { get; set; }

        [DisplayName("Numaratör")]
        public string Snumarator { get; set; }

        [DisplayName("Kapak Numaratör")]
        public string SnumaratorDis { get; set; }

        [DisplayName("Kesim")]
        public string Skesim { get; set; }

        [DisplayName("Kapak Kesim")]
        public string SkesimDis { get; set; }

        [DisplayName("Paket")]
        public string Spaket { get; set; }

        public string SpaketDis { get; set; }

        [DisplayName("Not")]
        public string Snot { get; set; }

        [DisplayName("Paket Şekli")]
        public string Tpaket { get; set; }

        [DisplayName("Teslim Alacak Kişi")]
        public string TteslimAlacakKisi { get; set; }

        [DisplayName("Ödeme Şekli")]
        public string TodemeSekli { get; set; }

        [DisplayName("Teslim Yeri")]
        public string TteslimYeri { get; set; }

        [DisplayName("Prova")]
        public string Prova { get; set; }

        [DisplayName("Maket")]
        public string Maket { get; set; }

        [DisplayName("Örnek")]
        public string Ornek { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [DisplayName("Adet")]
        public Nullable<int> Madet { get; set; }

        [DisplayName("Ebat")]
        public string Mebat { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [DisplayName("Teslim Tarihi")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> TeslimTarihi { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Sipariş Tarihi")]
        public Nullable<DateTime> SiparisTarihi { get; set; }

        [DisplayName("NOT")]
        public string Mnot { get; set; }

        [DisplayName("İşin Adı")]
        public string MisinAdi { get; set; }

        [DisplayName("Özellikler")]
        public string Mozellikler { get; set; }

        [DisplayName("Müşteri")]
        public int CariID { get; set; }

        public string ToplamTutar { get; set; }

        [DisplayName("Sipariş Durumu")]
        public string SiparisDurum { get; set; }

        public bool IsActive { get; set; }

        public string YetkiID { get; set; }
    }
}