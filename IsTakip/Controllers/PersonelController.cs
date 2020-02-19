using IsTakip.Models;
using NZF_DAL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IsTakip.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Index()
        {
            try
            {
                Session["KullaniciKontrol"] = "";
                Session["KullaniciAdi"] = null;
                Session["YetkiID"] = null;
                Session["MusteriAd"] = null;
                Session["YetkiID"] = null;
                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
           
        }
        [HttpPost]
        public ActionResult Index(PersonelDB models)
        {
            try
            {
                DataAccesBase db = new DataAccesBase();
                string sql = "Select * from Personel ";
                DataTable dt = db.ReturnDataTable(sql);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["KullaniciAdi"].ToString() == models.KullaniciAdi & dr["Sifre"].ToString() == models.Sifre)
                    {
                        Session["KullaniciAdi"] = dr["KullaniciAdi"].ToString();
                        Session["YetkiID"] = dr["YetkiID"].ToString();
                        Session["PersonelAdi"] = dr["PersonelAdi"].ToString();
                        if (Session["YetkiID"].ToString() == "Admin")
                        {
                            return RedirectToAction("SiparisListele", "Personel");
                        }
                        else if (Session["YetkiID"].ToString() == "Personel")
                        {
                            return RedirectToAction("SiparisListele", "Kullanici");
                        }

                    }

                }
                Response.Write("<script>alert('Kullanıcı Adı veya Şifre Hatalı')</script>)");
                return View();
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Hata");
            }
           
        }

        public string mails;
        public string sifre;
        public string Ad;

        public string Kullaniciad;
        public ActionResult SifreUnut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifreUnut(PersonelDB p)
        {
            try
            {
                string sql;
                sql = "Select * from Personel as p where p.EMail=" + "'" + p.EMail + "'";
                DataAccesBase db = new DataAccesBase();
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    Kullaniciad = item["KullaniciAdi"].ToString();

                    Ad = item["PersonelAdi"].ToString();
                    sifre = item["Sifre"].ToString();
                    mails = item["EMail"].ToString();

                }
                if (mails == null)
                {

                    Response.Write("<script>alert('Böyle bir mail yoktur')</script>");
                }
                else
                {
                    string Mesaj = "Sayın " + Ad + " " + " Kullanıcı Adını: " + Kullaniciad + " Şifreniz: " + sifre;
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.From = new MailAddress("bilgi@technorob.com.tr");//Verici
                    mail.To.Add(mails);//Alıcı
                    mail.IsBodyHtml = true;//Html mi 
                    mail.Subject = "Mücelliit Form Kullanıcı Bilgileri";//Mail Konusu
                    mail.BodyEncoding = System.Text.Encoding.UTF8;//UTF-8 Encoding
                    mail.Body = Mesaj;//Mail Mesajı
                    SmtpClient sc = new SmtpClient();
                    sc.Host = "mail.technorob.com";//Smtp Host
                    sc.Port = 587;//Smtp Port
                    sc.EnableSsl = false;//Enable SSL
                    sc.Credentials = new NetworkCredential("bilgi@technorob.com.tr", "TEchnorob18");//Gmail Kulanıcı - Şifre
                    sc.Send(mail);//Mail Gönder
                    Response.Write("<script>alert('Şifreniz Mailinize Gönderilmiştir')</script>");
                }
                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
           
        }
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(PersonelDB u)
        {
            try
            {
                Personel p = new Personel(u.ID);
                if (u.ID == 0)
                {


                    var sql = "Select * from Personel  as p where p.KullaniciAdi =" + "'" + u.KullaniciAdi + "'" + " OR p.EMail =" + "'" + u.EMail + "'";
                    DataAccesBase db = new DataAccesBase();
                    DataTable dt = db.ReturnDataTable(sql);

                    if (dt.Rows.Count == 0)
                    {
                        p.PersonelAdi = u.PersonelAdi;
                        p.Gorev = u.Gorev;
                        p.KullaniciAdi = u.KullaniciAdi;
                        p.Sifre = u.Sifre;
                        p.EMail = u.EMail;
                        p.YetkiID = u.YetkiID;

                        p.Kaydet();
                        Response.Write("<script language='javascript'>alert('Kayıt Başarıyla Eklendi.');</script>");
                        return View();
                    }

                    else
                    {
                        Response.Write("<script language='javascript'>alert('Böyle bir kullanıcı adı veya mail adresi mevcuttur');</script>");
                        return View();

                    }



                }
                else
                {

                    p.PersonelAdi = u.PersonelAdi;
                    p.Gorev = u.Gorev;
                    p.KullaniciAdi = u.KullaniciAdi;
                    p.Sifre = u.Sifre;
                    p.EMail = u.EMail;
                    p.YetkiID = u.YetkiID;

                    p.Kaydet();
                    Response.Write("<script language='javascript'>alert('Kayıt Başarıyla Eklendi.');</script>");
                    return View();

                }
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
           
           
        }
       

        public ActionResult PersonelListesi()
        {
            try
            {
                string sql;
                List<PersonelDB> list = new List<PersonelDB>();
                DataAccesBase db = new DataAccesBase();
                sql = "select * from Personel Order By ID DESC ";
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    list.Add(new PersonelDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        PersonelAdi = item["PersonelAdi"].ToString(),
                        Gorev = item["Gorev"].ToString(),

                    });
                }
                return View(list);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
            
        }
        public ActionResult PersonelDuz(int ID)
        {
            try
            {
                PersonelDB model = new PersonelDB();
                Personel s = new NZF_DAL.Personel(ID);
                model.ID = s.ID;
                model.PersonelAdi = s.PersonelAdi;
                model.Gorev = s.Gorev;
                model.KullaniciAdi = s.KullaniciAdi;
                model.Sifre = s.Sifre;
                model.EMail = s.EMail;
                return View("PersonelEkle", model);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
            
        }
        public JsonResult PersonelSil(int id)
        {
            Personel b = new Personel(id);
            var deleteState = b.Delete();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //*************************************
        public ActionResult Siparis()
        {
            try
            {
                DataAccesBase db = new DataAccesBase();
                List<PersonelDB> bList = new List<PersonelDB>();
                DataTable d = db.ReturnDataTable("Select ID,PersonelAdi from Personel");
                foreach (DataRow item in d.Rows)
                {
                    bList.Add(new PersonelDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        PersonelAdi = item["PersonelAdi"].ToString()
                    });
                }
                ViewBag.PerAdi = bList;
                string t = db.ReturnString("select TOP(1) ID + 1 from Siparis order by ID desc");
                ViewBag.ID = t;



                List<CariHesapDB> musteriList = new List<CariHesapDB>();
                DataAccesBase dbb = new DataAccesBase();
                DataTable musteri = dbb.ReturnDataTable("Select ID,MusteriAd,MusteriSoyAd from CariHesap");
                foreach (DataRow item in musteri.Rows)
                {
                    musteriList.Add(new CariHesapDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        MusteriAd = item["MusteriAd"].ToString(),




                    });
                }
                ViewBag.musteriAdi = musteriList;


                List<SiparislerDB> siparisDurum = new List<SiparislerDB>();
                DataAccesBase dbbb = new DataAccesBase();
                DataTable siparis = dbbb.ReturnDataTable("Select ID,SiparisDurum from Siparis");
                foreach (DataRow item in siparis.Rows)
                {
                    siparisDurum.Add(new SiparislerDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        SiparisDurum = item["SiparisDurum"].ToString(),




                    });
                }
                ViewBag.siparisListe = siparisDurum;
                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
            
        }

       public string sifree;
       public string mailss;
       public string SiparisTarih;
       public string isAdi;
       public string MusteriAd;
       public string sql;
        [HttpPost]
        public ActionResult Siparis(SiparislerDB s,CariHesapDB chd)
        {
            try
            {

                #region
                if (s.ID == 0)
                {
                    Siparis k = new NZF_DAL.Siparis(s.ID);
                    k.PersonelID = s.PersonelID;
                    k.MisinAdi = s.MisinAdi;
                    k.Mozellikler = s.Mozellikler;
                    k.SiparisTarihi = (DateTime)s.SiparisTarihi;
                    k.TeslimTarihi = (DateTime)s.TeslimTarihi;
                    k.Madet = (int)s.Madet;
                    k.Mebat = s.Mebat;
                    k.Prova = s.Prova;
                    k.Ornek = s.Ornek;
                    k.Maket = s.Maket;
                    k.Mnot = s.Mnot;
                    k.KkagitCinsiIc = s.KkagitCinsiIc;
                    k.KkagitCinsiDis = s.KkagitCinsiDis;
                    k.KebatIc = s.KebatIc;
                    k.KebatDis = s.KebatDis;
                    k.KagitGramiIc = s.KagitGramiIc;
                    k.KagitGramiDis = s.KagitGramiDis;
                    k.KadetIc = s.KadetIc;
                    k.KadetDis = s.KadetDis;
                    k.BmakinaIc = s.BmakinaIc;
                    k.BMakinaDis = s.BMakinaDis;
                    k.BbaskiIc = s.BbaskiIc;
                    k.BbaskiDis = s.BbaskiDis;
                    k.BadetIc = s.BadetIc;
                    k.BadetDis = s.BadetDis;
                    k.BebatIc = s.BebatIc;
                    k.BebatDis = s.BebatDis;
                    k.BrenkIc = s.BrenkIc;
                    k.BrenkDis = s.BrenkDis;
                    k.BkalipIc = s.BkalipIc;
                    k.BkalipDis = s.BkalipDis;
                    k.BformaIc = s.BformaIc;
                    k.BformaDis = s.BformaDis;
                    k.Bnot = s.Bnot;
                    k.Sselefon = s.Sselefon;
                    k.SselefonDis = s.SselefonDis;
                    k.Slak = s.Slak;
                    k.SlakDis = s.SlakDis;
                    k.Sgofre = s.Sgofre;
                    k.SgofreDis = s.SgofreDis;
                    k.Svarak = s.Svarak;
                    k.SvarakDis = s.SvarakDis;
                    k.Sperforaj = s.Sperforaj;
                    k.SperforajDis = s.SperforajDis;
                    k.SozelKesim = s.SozelKesim;
                    k.SozelKesimDis = s.SozelKesimDİs;
                    k.Scilt = s.Scilt;
                    k.SciltDis = s.SciltDis;
                    k.Skirim = s.Skirim;
                    k.SkirimDis = s.SkirimDis;
                    k.Syapistirma = s.Syapistirma;
                    k.SyapistirmaDis = s.SyapistirmaDis;
                    k.Ssivama = s.Ssivama;
                    k.SsivamaDis = s.SsivamaDis;
                    k.Staslama = s.Staslama;
                    k.StaslamaDis = s.StaslamaDis;
                    k.Snumarator = s.Snumarator;
                    k.SnumaratorDis = s.SnumaratorDis;
                    k.Skesim = s.Skesim;
                    k.SkesimDis = s.SkesimDis;
                    k.Spaket = s.Spaket;
                    k.SpaketDis = s.SpaketDis;
                    k.Snot = s.Snot;
                    k.Tpaket = s.Tpaket;
                    k.TteslimAlacakKisi = s.TteslimAlacakKisi;
                    k.TodemeSekli = s.TodemeSekli;
                    k.TteslimYeri = s.TteslimYeri;
                    k.CariID = s.CariID;
                    k.ToplamTutar = s.ToplamTutar;
                    k.SiparisDurum = s.SiparisDurum;
                    k.SiparisDurum = "Hazırlanıyor";
                    k.Kaydet();
                    #endregion


                    return RedirectToAction("SiparisDetayi", "Personel");
                }
                else
                {
                    Siparis k = new NZF_DAL.Siparis(s.ID);
                    k.PersonelID = s.PersonelID;
                    k.MisinAdi = s.MisinAdi;
                    k.Mozellikler = s.Mozellikler;
                    k.SiparisTarihi = (DateTime)s.SiparisTarihi;
                    k.TeslimTarihi = (DateTime)s.TeslimTarihi;
                    k.Madet = (int)s.Madet;
                    k.Mebat = s.Mebat;
                    k.Prova = s.Prova;
                    k.Ornek = s.Ornek;
                    k.Maket = s.Maket;
                    k.Mnot = s.Mnot;
                    k.KkagitCinsiIc = s.KkagitCinsiIc;
                    k.KkagitCinsiDis = s.KkagitCinsiDis;
                    k.KebatIc = s.KebatIc;
                    k.KebatDis = s.KebatDis;
                    k.KagitGramiIc = s.KagitGramiIc;
                    k.KagitGramiDis = s.KagitGramiDis;
                    k.KadetIc = s.KadetIc;
                    k.KadetDis = s.KadetDis;
                    k.BmakinaIc = s.BmakinaIc;
                    k.BMakinaDis = s.BMakinaDis;
                    k.BbaskiIc = s.BbaskiIc;
                    k.BbaskiDis = s.BbaskiDis;
                    k.BadetIc = s.BadetIc;
                    k.BadetDis = s.BadetDis;
                    k.BebatIc = s.BebatIc;
                    k.BebatDis = s.BebatDis;
                    k.BrenkIc = s.BrenkIc;
                    k.BrenkDis = s.BrenkDis;
                    k.BkalipIc = s.BkalipIc;
                    k.BkalipDis = s.BkalipDis;
                    k.BformaIc = s.BformaIc;
                    k.BformaDis = s.BformaDis;
                    k.Bnot = s.Bnot;
                    k.Sselefon = s.Sselefon;
                    k.SselefonDis = s.SselefonDis;
                    k.Slak = s.Slak;
                    k.SlakDis = s.SlakDis;
                    k.Sgofre = s.Sgofre;
                    k.SgofreDis = s.SgofreDis;
                    k.Svarak = s.Svarak;
                    k.SvarakDis = s.SvarakDis;
                    k.Sperforaj = s.Sperforaj;
                    k.SperforajDis = s.SperforajDis;
                    k.SozelKesim = s.SozelKesim;
                    k.SozelKesimDis = s.SozelKesimDİs;
                    k.Scilt = s.Scilt;
                    k.SciltDis = s.SciltDis;
                    k.Skirim = s.Skirim;
                    k.SkirimDis = s.SkirimDis;
                    k.Syapistirma = s.Syapistirma;
                    k.SyapistirmaDis = s.SyapistirmaDis;
                    k.Ssivama = s.Ssivama;
                    k.SsivamaDis = s.SsivamaDis;
                    k.Staslama = s.Staslama;
                    k.StaslamaDis = s.StaslamaDis;
                    k.Snumarator = s.Snumarator;
                    k.SnumaratorDis = s.SnumaratorDis;
                    k.Skesim = s.Skesim;
                    k.SkesimDis = s.SkesimDis;
                    k.Spaket = s.Spaket;
                    k.SpaketDis = s.SpaketDis;
                    k.Snot = s.Snot;
                    k.Tpaket = s.Tpaket;
                    k.TteslimAlacakKisi = s.TteslimAlacakKisi;
                    k.TodemeSekli = s.TodemeSekli;
                    k.TteslimYeri = s.TteslimYeri;
                    k.CariID = s.CariID;
                    k.ToplamTutar = s.ToplamTutar;
                    k.SiparisDurum = s.SiparisDurum;
                    k.Kaydet();

                    return RedirectToAction("SiparisListele", "Personel");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }

        }
        public ActionResult SiparisListele(int? page)
        {
            try
            {
                string sql;
                List<SiparislerDB> list = new List<SiparislerDB>();
                DataAccesBase db = new DataAccesBase();
                sql = "select * from Siparis s left join Personel as p on s.PersonelID = p.ID left join CariHesap as c on c.ID = s.CariID Order By s.ID DESC";
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    list.Add(new SiparislerDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        MusteriAd = item["MusteriAd"].ToString(),

                        MisinAdi = item["MisinAdi"].ToString(),
                        Mnot = item["Mnot"].ToString(),
                        PersonelAdi = item["PersonelAdi"].ToString(),
                        TeslimTarihi = Convert.ToDateTime(item["TeslimTarihi"]),
                        SiparisTarihi = Convert.ToDateTime(item["SiparisTarihi"]),
                        SiparisDurum = item["SiparisDurum"].ToString(),



                    });
                }

                return View(list.ToPagedList(page ?? 1, 10));
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
            
        }
        public ActionResult SiparisDetayi(SiparislerDB ID)
        {
            try
            {
                string sql;
                List<SiparislerDB> list = new List<SiparislerDB>();
                DataAccesBase db = new DataAccesBase();
                string t = db.ReturnString("select TOP(1) ID from Siparis order by ID desc");
                //DataTable s = db.ReturnDataTable(t);
                sql = "select * from Siparis as s left join Personel as p on s.PersonelID = p.ID left join CariHesap as c on s.CariID=c.ID where s.ID = " + t + "";
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    list.Add(new SiparislerDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        KagitGramiIc = Convert.ToInt32(item["KagitGramiIc"]),
                        KagitGramiDis = Convert.ToInt32(item["KagitGramiDis"]),
                        KkagitCinsiIc = item["KkagitCinsiIc"].ToString(),
                        KkagitCinsiDis = item["KkagitCinsiDis"].ToString(),
                        KebatIc = item["KebatIc"].ToString(),
                        KadetDis = Convert.ToInt32(item["KadetDis"]),
                        KadetIc = Convert.ToInt32(item["KadetIc"]),
                        KebatDis = item["KebatDis"].ToString(),
                        BmakinaIc = item["BmakinaIc"].ToString(),
                        BMakinaDis = item["BMakinaDis"].ToString(),
                        BebatIc = item["BebatIc"].ToString(),
                        BebatDis = item["BebatDis"].ToString(),
                        BadetIc = item["BadetIc"].ToString(),
                        BadetDis = item["BadetDis"].ToString(),
                        BrenkIc = item["BrenkIc"].ToString(),
                        BrenkDis = item["BrenkDis"].ToString(),
                        BkalipIc = item["BkalipIc"].ToString(),
                        BkalipDis = item["BkalipDis"].ToString(),
                        BbaskiIc = item["BbaskiIc"].ToString(),
                        BbaskiDis = item["BbaskiDis"].ToString(),
                        BformaIc = item["BformaIc"].ToString(),
                        BformaDis = item["BformaDis"].ToString(),
                        Bnot = item["Bnot"].ToString(),
                        Sselefon = item["Sselefon"].ToString(),
                        SselefonDis = item["SselefonDis"].ToString(),
                        Slak = item["Slak"].ToString(),
                        SlakDis = item["SlakDis"].ToString(),
                        Sgofre = item["Sgofre"].ToString(),
                        SgofreDis = item["SgofreDis"].ToString(),
                        Svarak = item["Svarak"].ToString(),
                        SvarakDis = item["SvarakDis"].ToString(),
                        Sperforaj = item["Sperforaj"].ToString(),
                        SperforajDis = item["SperforajDis"].ToString(),
                        SozelKesim = item["SozelKesim"].ToString(),
                        SozelKesimDİs = item["SozelKesimDİs"].ToString(),
                        Scilt = item["Scilt"].ToString(),
                        SciltDis = item["SciltDis"].ToString(),
                        Skirim = item["Skirim"].ToString(),
                        SkirimDis = item["SkirimDis"].ToString(),
                        Syapistirma = item["Syapistirma"].ToString(),
                        SyapistirmaDis = item["SyapistirmaDis"].ToString(),
                        Ssivama = item["Ssivama"].ToString(),
                        SsivamaDis = item["SsivamaDis"].ToString(),
                        Staslama = item["Staslama"].ToString(),
                        StaslamaDis = item["StaslamaDis"].ToString(),
                        Snumarator = item["Snumarator"].ToString(),
                        SnumaratorDis = item["SnumaratorDis"].ToString(),
                        Skesim = item["Skesim"].ToString(),
                        SkesimDis = item["SkesimDis"].ToString(),
                        Spaket = item["Spaket"].ToString(),
                        SpaketDis = item["SpaketDis"].ToString(),
                        Snot = item["Snot"].ToString(),
                        Tpaket = item["Tpaket"].ToString(),
                        TteslimAlacakKisi = item["TteslimAlacakKisi"].ToString(),
                        TodemeSekli = item["TodemeSekli"].ToString(),
                        TteslimYeri = item["TteslimYeri"].ToString(),
                        Prova = item["Prova"].ToString(),
                        Maket = item["Maket"].ToString(),
                        Ornek = item["Ornek"].ToString(),
                        Madet = Convert.ToInt32(item["Madet"]),
                        Mebat = item["Mebat"].ToString(),
                        TeslimTarihi = Convert.ToDateTime(item["TeslimTarihi"]),
                        SiparisTarihi = Convert.ToDateTime(item["SiparisTarihi"]),
                        Mnot = item["Mnot"].ToString(),
                        MisinAdi = item["MisinAdi"].ToString(),
                        Mozellikler = item["Mozellikler"].ToString(),
                        CariID = Convert.ToInt32(item["CariID"]),
                        MusteriAd = item["MusteriAd"].ToString(),
                        PersonelAdi = item["PersonelAdi"].ToString(),
                        ToplamTutar = item["ToplamTutar"].ToString(),

                    });


                }
                return View(list);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
           
        }
        public ActionResult SiparisDetay(int ID)
        {
            try
            {
                string sql;
                List<SiparislerDB> list = new List<SiparislerDB>();
                DataAccesBase db = new DataAccesBase();
                sql = "select * from Siparis as s left join Personel as p on s.PersonelID = p.ID left join CariHesap as c on s.CariID = c.ID where s.ID = " + ID + "";
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    list.Add(new SiparislerDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        KagitGramiIc = Convert.ToInt32(item["KagitGramiIc"]),
                        KagitGramiDis = Convert.ToInt32(item["KagitGramiDis"]),
                        KkagitCinsiIc = item["KkagitCinsiIc"].ToString(),
                        KkagitCinsiDis = item["KkagitCinsiDis"].ToString(),
                        KebatIc = item["KebatIc"].ToString(),
                        KadetDis = Convert.ToInt32(item["KadetDis"]),
                        KadetIc = Convert.ToInt32(item["KadetIc"]),
                        KebatDis = item["KebatDis"].ToString(),
                        BmakinaIc = item["BmakinaIc"].ToString(),
                        BMakinaDis = item["BMakinaDis"].ToString(),
                        BebatIc = item["BebatIc"].ToString(),
                        BebatDis = item["BebatDis"].ToString(),
                        BadetIc = item["BadetIc"].ToString(),
                        BadetDis = item["BadetDis"].ToString(),
                        BrenkIc = item["BrenkIc"].ToString(),
                        BrenkDis = item["BrenkDis"].ToString(),
                        BkalipIc = item["BkalipIc"].ToString(),
                        BkalipDis = item["BkalipDis"].ToString(),
                        BbaskiIc = item["BbaskiIc"].ToString(),
                        BbaskiDis = item["BbaskiDis"].ToString(),
                        BformaIc = item["BformaIc"].ToString(),
                        BformaDis = item["BformaDis"].ToString(),
                        Bnot = item["Bnot"].ToString(),
                        Sselefon = item["Sselefon"].ToString(),
                        SselefonDis = item["SselefonDis"].ToString(),
                        Slak = item["Slak"].ToString(),
                        SlakDis = item["SlakDis"].ToString(),
                        Sgofre = item["Sgofre"].ToString(),
                        SgofreDis = item["SgofreDis"].ToString(),
                        Svarak = item["Svarak"].ToString(),
                        SvarakDis = item["SvarakDis"].ToString(),
                        Sperforaj = item["Sperforaj"].ToString(),
                        SperforajDis = item["SperforajDis"].ToString(),
                        SozelKesim = item["SozelKesim"].ToString(),
                        SozelKesimDİs = item["SozelKesimDİs"].ToString(),
                        Scilt = item["Scilt"].ToString(),
                        SciltDis = item["SciltDis"].ToString(),
                        Skirim = item["Skirim"].ToString(),
                        SkirimDis = item["SkirimDis"].ToString(),
                        Syapistirma = item["Syapistirma"].ToString(),
                        SyapistirmaDis = item["SyapistirmaDis"].ToString(),
                        Ssivama = item["Ssivama"].ToString(),
                        SsivamaDis = item["SsivamaDis"].ToString(),
                        Staslama = item["Staslama"].ToString(),
                        StaslamaDis = item["StaslamaDis"].ToString(),
                        Snumarator = item["Snumarator"].ToString(),
                        SnumaratorDis = item["SnumaratorDis"].ToString(),
                        Skesim = item["Skesim"].ToString(),
                        SkesimDis = item["SkesimDis"].ToString(),
                        Spaket = item["Spaket"].ToString(),
                        SpaketDis = item["SpaketDis"].ToString(),
                        Snot = item["Snot"].ToString(),
                        Tpaket = item["Tpaket"].ToString(),
                        TteslimAlacakKisi = item["TteslimAlacakKisi"].ToString(),
                        TodemeSekli = item["TodemeSekli"].ToString(),
                        TteslimYeri = item["TteslimYeri"].ToString(),
                        Prova = item["Prova"].ToString(),
                        Maket = item["Maket"].ToString(),
                        Ornek = item["Ornek"].ToString(),
                        Madet = Convert.ToInt32(item["Madet"]),
                        Mebat = item["Mebat"].ToString(),
                        TeslimTarihi = Convert.ToDateTime(item["TeslimTarihi"]),
                        SiparisTarihi = Convert.ToDateTime(item["SiparisTarihi"]),
                        Mnot = item["Mnot"].ToString(),
                        MisinAdi = item["MisinAdi"].ToString(),
                        Mozellikler = item["Mozellikler"].ToString(),
                        CariID = Convert.ToInt32(item["CariID"]),
                        MusteriAd = item["MusteriAd"].ToString(),
                        PersonelAdi = item["PersonelAdi"].ToString(),
                        ToplamTutar = item["ToplamTutar"].ToString()
                    });


                }
                return View(list);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
            
        }
        //public ActionResult SiparisDuz(int ID)
        //{
        //    SiparislerDB model = new SiparislerDB();
        //    Siparis s = new NZF_DAL.Siparis(ID);
        //    model.MisinAdi = s.MisinAdi;
        //    model.Mozellikler = s.Mozellikler;
        //    model.SiparisTarihi = s.SiparisTarihi;
        //    model.TeslimTarihi = s.TeslimTarihi;
        //    model.Madet = s.Madet;
        //    model.Mebat = s.Mebat;
        //    model.Prova = s.Prova;
        //    model.Ornek = s.Ornek;
        //    model.Maket = s.Maket;
        //    model.Mnot = s.Mnot;
        //    model.KkagitCinsiIc = s.KkagitCinsiIc;
        //    model.KkagitCinsiDis = s.KkagitCinsiDis;
        //    model.KebatIc = s.KebatIc;
        //    model.KebatDis = s.KebatDis;
        //    model.KagitGramiIc = s.KagitGramiIc;
        //    model.KagitGramiDis = s.KagitGramiDis;
        //    model.KadetIc = s.KadetIc;
        //    model.KadetDis = s.KadetDis;
        //    model.BmakinaIc = s.BmakinaIc;
        //    model.BMakinaDis = s.BMakinaDis;
        //    model.BbaskiIc = s.BbaskiIc;
        //    model.BbaskiDis = s.BbaskiDis;
        //    model.BadetIc = s.BadetIc;
        //    model.BadetDis = s.BadetDis;
        //    model.BebatIc = s.BebatIc;
        //    model.BebatDis = s.BebatDis;
        //    model.BrenkIc = s.BrenkIc;
        //    model.BrenkDis = s.BrenkDis;
        //    model.BkalipIc = s.BkalipIc;
        //    model.BkalipDis = s.BkalipDis;
        //    model.BformaIc = s.BformaIc;
        //    model.BformaDis = s.BformaDis;
        //    model.Bnot = s.Bnot;
        //    model.Sselefon = s.Sselefon;
        //    model.SselefonDis = s.SselefonDis;
        //    model.Slak = s.Slak;
        //    model.SlakDis = s.SlakDis;
        //    model.Sgofre = s.Sgofre;
        //    model.SgofreDis = s.SgofreDis;
        //    model.Svarak = s.Svarak;
        //    model.SvarakDis = s.SvarakDis;
        //    model.Sperforaj = s.Sperforaj;
        //    model.SperforajDis = s.SperforajDis;
        //    model.SozelKesim = s.SozelKesim;
        //    model.SozelKesimDİs = s.SozelKesimDis;
        //    model.Scilt = s.Scilt;
        //    model.SciltDis = s.SciltDis;
        //    model.Skirim = s.Skirim;
        //    model.SkirimDis = s.SkirimDis;
        //    model.Syapistirma = s.Syapistirma;
        //    model.SyapistirmaDis = s.SyapistirmaDis;
        //    model.Ssivama = s.Ssivama;
        //    model.SsivamaDis = s.SsivamaDis;
        //    model.Staslama = s.Staslama;
        //    model.StaslamaDis = s.StaslamaDis;
        //    model.Snumarator = s.Snumarator;
        //    model.SnumaratorDis = s.SnumaratorDis;
        //    model.Skesim = s.Skesim;
        //    model.SkesimDis = s.SkesimDis;
        //    model.Spaket = s.Spaket;
        //    model.SpaketDis = s.SpaketDis;
        //    model.Snot = s.Snot;
        //    model.Tpaket = s.Tpaket;
        //    model.TteslimAlacakKisi = s.TteslimAlacakKisi;
        //    model.TodemeSekli = s.TodemeSekli;
        //    model.TteslimYeri = s.TteslimYeri;
        //    model.CariID = s.CariID;
        //    #region RolID
        //    List<PersonelDB> bList = new List<PersonelDB>();
        //    DataAccesBase db = new DataAccesBase();
        //    string sql;
        //    sql = "Select ID,PersonelAdi from Personel";
        //    DataTable d = db.ReturnDataTable(sql);
        //    foreach (DataRow item in d.Rows)
        //    {
        //        bList.Add(new PersonelDB
        //        {
        //            ID = Convert.ToInt32(item["ID"]),
        //            PersonelAdi = item["PersonelAdi"].ToString()
        //        });
        //    }
        //    ViewBag.PerAdi = bList;
        //    #endregion
        //    return View("Siparis", model);
        //}
        public JsonResult SiparisSil(int id)
        {
            Siparis b = new NZF_DAL.Siparis(id);
            var deleteState = b.Delete();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult SiparisAra()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult SiparisAra(SiparislerDB A)
        //{
        //    try
        //    {
        //        if (A.ID != 0)
        //        {
        //            List<SiparislerDB> list = new List<SiparislerDB>();
        //            DataAccesBase db = new DataAccesBase();
        //            string sql = "select * from Siparis as s where s.ID =" + A.ID + "";
        //            DataTable model = db.ReturnDataTable(sql);
        //            foreach (DataRow item in model.Rows)
        //            {
        //                list.Add(new SiparislerDB
        //                {
        //                    ID = Convert.ToInt32(item["ID"]),
        //                    CariID = Convert.ToInt32(item["CariID"]),
        //                    MisinAdi = item["MisinAdi"].ToString(),
        //                    Mnot = item["Mnot"].ToString(),
        //                    TeslimTarihi = Convert.ToDateTime(item["TeslimTarihi"]),
        //                    SiparisTarihi = Convert.ToDateTime(item["SiparisTarihi"]),
        //                });


        //            }
        //            return View("SiparisListele", list);
        //        }
        //        else
        //        {
        //            List<SiparislerDB> list = new List<SiparislerDB>();
        //            DataAccesBase db = new DataAccesBase();
        //            string sql = string.Format("select * from Siparis as s where s.SiparisTarihi = '{0:yyyy-MM-dd}'", A.SiparisTarihi);
        //            DataTable model = db.ReturnDataTable(sql);
        //            foreach (DataRow item in model.Rows)
        //            {
        //                list.Add(new SiparislerDB
        //                {
        //                    ID = Convert.ToInt32(item["ID"]),
        //                    CariID = Convert.ToInt32(item["CariID"]),
        //                    MisinAdi = item["MisinAdi"].ToString(),
        //                    Mnot = item["Mnot"].ToString(),
        //                    TeslimTarihi = Convert.ToDateTime(item["TeslimTarihi"]),
        //                    SiparisTarihi = Convert.ToDateTime(item["SiparisTarihi"]),

        //                });


        //            }
        //            return View("SiparisListele", list);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Index", "Hata");
        //    }
           
        //}
        public ActionResult TCSorgula()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TCSorgula(CariHesapDB hesap)
        {
            try
            {
                int a = 0;
                string sql;
                DataAccesBase db = new DataAccesBase();

                sql = "Select * from CariHesap as c where c.KimlikNo=" + hesap.KimlikNo;
                var model = db.ReturnDataTable(sql);
                if (model.Rows.Count >= 1)
                {
                    foreach (DataRow item in model.Rows)
                    {
                        a = Convert.ToInt32(item["ID"]);


                    }
                    SiparislerDB siparis = new SiparislerDB();
                    CariHesap s = new NZF_DAL.CariHesap(a);
                    siparis.CariID = s.ID;
                    siparis.MusteriAd = s.MusteriAd;


                    List<PersonelDB> bList = new List<PersonelDB>();
                    DataTable d = db.ReturnDataTable("Select ID,PersonelAdi from Personel");
                    foreach (DataRow item in d.Rows)
                    {
                        bList.Add(new PersonelDB
                        {
                            ID = Convert.ToInt32(item["ID"]),
                            PersonelAdi = item["PersonelAdi"].ToString()
                        });
                    }
                    ViewBag.PerAdi = bList;
                    string t = db.ReturnString("select TOP(1) ID + 1 from Siparis order by ID desc");
                    ViewBag.ID = t;

                    return View("Siparis", siparis);
                }

                else
                {
                    Response.Write("<script lang='JavaScript'>alert('Lütfen Önce Müşteri Kayıdı Açınız');</script>");
                    return RedirectToAction("Create", "CariHesap");


                }

            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
           
        }

        public ActionResult SiparisAraa(SiparislerDB s, int? page)
        {
            try
            {
                List<SiparislerDB> list = new List<SiparislerDB>();
                string sql;
                DataAccesBase db = new DataAccesBase();
                sql = "Select * from Siparis as s left join CariHesap as c on s.CariID = c.ID left join Personel as p on s.PersonelID = p.ID where c.MusteriAd like  '%" + s.MusteriAd + "%'";
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    list.Add(new SiparislerDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        MusteriAd = item["MusteriAd"].ToString(),
                        TeslimTarihi = (DateTime)item["TeslimTarihi"],
                        MisinAdi = item["MisinAdi"].ToString(),
                        SiparisTarihi = (DateTime)item["SiparisTarihi"],
                        SiparisDurum = item["SiparisDurum"].ToString(),
                        Mnot = item["Mnot"].ToString(),
                        PersonelAdi = item["PersonelAdi"].ToString()

                    });
                }

                return PartialView("SiparisListele", list.ToPagedList(page ?? 1, 10));
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
           

        }
        public ActionResult SiparisDurumAra(SiparislerDB sdb, int? page)
        {
            try
            {
                List<SiparislerDB> list = new List<SiparislerDB>();
                string sql;
                DataAccesBase db = new DataAccesBase();
                sql = "Select * from Siparis as s left join CariHesap as c on s.CariID = c.ID left join Personel as p on s.PersonelID = p.ID where s.SiparisDurum =" + "'" + sdb.SiparisDurum + "'";
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    list.Add(new SiparislerDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        MusteriAd = item["MusteriAd"].ToString(),
                        TeslimTarihi = (DateTime)item["TeslimTarihi"],
                        MisinAdi = item["MisinAdi"].ToString(),
                        SiparisTarihi = (DateTime)item["SiparisTarihi"],
                        SiparisDurum = item["SiparisDurum"].ToString(),
                        Mnot = item["Mnot"].ToString(),
                        PersonelAdi = item["PersonelAdi"].ToString()

                    });
                }

                return PartialView("SiparisListele", list.ToPagedList(page ?? 1, 10));
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Hata");
            }
           
        }
        public ActionResult SiparisHazirlaniyor(SiparislerDB s)
        {
            try
            {
                Siparis siparis = new NZF_DAL.Siparis(s.ID);
                siparis.SiparisDurum = s.SiparisDurum;
                siparis.SiparisDurum = "Hazırlandı";
                siparis.Kaydet();
                return RedirectToAction("SiparisListele", "Personel");
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
            
        }
        public ActionResult SiparisTeslimEdildi(SiparislerDB s)
        {
            try
            {
                Siparis siparis = new NZF_DAL.Siparis(s.ID);
                siparis.SiparisDurum = s.SiparisDurum;
                siparis.SiparisDurum = "Teslim Edildi";
                siparis.Kaydet();
                return RedirectToAction("SiparisListele", "Personel");
            }
            catch (Exception)
            {

               return RedirectToAction("Index","Hata");
            }
           
        }
    }

}