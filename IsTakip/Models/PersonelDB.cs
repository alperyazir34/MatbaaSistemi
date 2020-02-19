using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakip.Models
{
    public class PersonelDB : CariHesapDB
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessage = "{0} alanı en az 5 karakter uzunluğunda olmalıdır!", MinimumLength = 2)]
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [DisplayName("Ad Soyad")]
        public string PersonelAdi { get; set; }

        [DisplayName("Görev")]
        public string Gorev { get; set; }

        
        [StringLength(50, ErrorMessage = "{0} alanı en az 5 karakter uzunluğunda olmalıdır!", MinimumLength = 2)]
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [DisplayName("Şifre")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string YetkiID { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                       @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                       ErrorMessage = "Email adresi geçersiz!")]//E Mail için geçerli işaretler
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string EMail { get; set; }

    }
}