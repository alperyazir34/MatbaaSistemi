using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsTakip.Models
{
    public class CariHesapDB 
    {
        public int ID { get; set; }
        public string KimlikNo { get; set; }
        public string MusteriAd { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string Unvan { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string CepTel { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                      ErrorMessage = "Email adresi geçersiz!")]//E Mail için geçerli işaretler
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string EMail { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string TeslimatAdres { get; set; }
    }
}