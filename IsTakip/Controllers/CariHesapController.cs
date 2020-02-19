using IsTakip.Models;
using NZF_DAL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakip.Controllers
{
    public class CariHesapController : Controller
    {
        // GET: CariHesap

        public string toplamTutarCont;
        public ActionResult Index(int? page)
        {
            try
            {

                List<CariHesapDB> list = new List<CariHesapDB>();
                string sql;
                DataAccesBase db = new DataAccesBase();
                sql = "Select * from CariHesap Order By ID DESC";
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    list.Add(new CariHesapDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        MusteriAd = item["MusteriAd"].ToString(),
                        Telefon = item["Telefon"].ToString(),
                        KimlikNo = item["KimlikNo"].ToString(),
                        DogumTarihi = Convert.ToDateTime(item["DogumTarih"])

                    });
                }
                return View(list.ToPagedList(page ?? 1, 10));
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CariHesapDB c)
        {
            try
            {

                if (c.ID == 0)
                {
                    CariHesap hesap = new CariHesap(c.ID);

                    hesap.Adres = c.Adres;
                    hesap.CepTel = c.CepTel;
                    hesap.Cinsiyet = c.Cinsiyet;
                    hesap.DogumTarih = (DateTime)c.DogumTarihi;
                    hesap.EMail = c.EMail;
                    hesap.KimlikNo = c.KimlikNo;
                    hesap.MusteriAd = c.MusteriAd;

                    hesap.Telefon = c.Telefon;
                    hesap.TeslimatAdres = c.TeslimatAdres;
                    hesap.Unvan = c.Unvan;
                    hesap.VergiDairesi = c.VergiDairesi;
                    hesap.VergiNo = c.VergiNo;

                    hesap.Kaydet();
                    Response.Write("<script language='javascript'>alert('Kayıt Başarıyla Eklendi.');</script>");
                    return View();

                }
                else
                {
                    CariHesap hesap = new CariHesap(c.ID);

                    hesap.Adres = c.Adres;
                    hesap.CepTel = c.CepTel;
                    hesap.Cinsiyet = c.Cinsiyet;
                    hesap.DogumTarih = c.DogumTarihi;
                    hesap.EMail = c.EMail;
                    hesap.KimlikNo = c.KimlikNo;
                    hesap.MusteriAd = c.MusteriAd;

                    hesap.Telefon = c.Telefon;
                    hesap.TeslimatAdres = c.TeslimatAdres;
                    hesap.Unvan = c.Unvan;
                    hesap.VergiDairesi = c.VergiDairesi;
                    hesap.VergiNo = c.VergiNo;
                    hesap.Kaydet();
                    return RedirectToAction("Index", "CariHesap");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
        }
        public ActionResult Edit(int ID)
        {
            try
            {

            CariHesapDB model = new Models.CariHesapDB();
            CariHesap cari = new CariHesap(ID);

            //model.ID = cari.ID;
            model.Adres = cari.Adres;
            model.CepTel = cari.CepTel;
            model.Cinsiyet = cari.Cinsiyet;
            model.DogumTarihi = cari.DogumTarih;
            model.EMail = cari.EMail;
            model.KimlikNo = cari.KimlikNo;
            model.MusteriAd = cari.MusteriAd;

            model.Telefon = cari.Telefon;
            model.TeslimatAdres = cari.TeslimatAdres;
            model.Unvan = cari.Unvan;
            model.VergiDairesi = cari.VergiDairesi;
            model.VergiNo = cari.VergiNo;

            return View("Create", model);
        }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
        }
        public ActionResult Details(int ID)
        {
            try
            {
                string sql;
                List<CariHesapDB> cari = new List<CariHesapDB>();
                DataAccesBase db = new DataAccesBase();
                sql = "Select * from CariHesap as c where c.ID=" + ID;
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    cari.Add(new CariHesapDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        Adres = item["Adres"].ToString(),
                        CepTel = item["CepTel"].ToString(),
                        Cinsiyet = item["Cinsiyet"].ToString(),
                        DogumTarihi = Convert.ToDateTime(item["DogumTarih"]),
                        EMail = item["EMail"].ToString(),
                        KimlikNo = item["KimlikNo"].ToString(),
                        MusteriAd = item["MusteriAd"].ToString(),

                        Telefon = item["Telefon"].ToString(),
                        TeslimatAdres = item["TeslimatAdres"].ToString(),
                        Unvan = item["Unvan"].ToString(),
                        VergiDairesi = item["VergiDairesi"].ToString(),
                        VergiNo = item["VergiNo"].ToString()


                    });
                }

                List<SiparislerDB> list = new List<SiparislerDB>();
                string sqll;
                DataAccesBase dbb = new DataAccesBase();

                sqll = "Select * from Siparis as s left join CariHesap as c on s.CariID = c.ID where s.CariID=" + ID + "Order By s.ID DESC";
                DataTable modell = dbb.ReturnDataTable(sqll);
                foreach (DataRow item in modell.Rows)
                {
                    list.Add(new SiparislerDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        MusteriAd = item["MusteriAd"].ToString(),
                        CariID = (int)item["CariID"],
                        TeslimTarihi = (DateTime)item["TeslimTarihi"],
                        SiparisDurum = item["SiparisDurum"].ToString(),
                        ToplamTutar = item["ToplamTutar"].ToString()

                    });
                }
                ViewBag.cariliste = list;
                return View(cari);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
           
        }
        public JsonResult Delete(int ID)
        {
            CariHesap cari = new NZF_DAL.CariHesap(ID);
            var silinen = cari.Delete();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult HesapFiltrele(CariHesapDB c, int? page)
        {
            try
            {
                List<CariHesapDB> list = new List<CariHesapDB>();
                string sql;
                DataAccesBase db = new DataAccesBase();
                sql = "Select * from CariHesap as c where c.MusteriAd like  '%" + c.MusteriAd + "%'";
                DataTable model = db.ReturnDataTable(sql);
                foreach (DataRow item in model.Rows)
                {
                    list.Add(new CariHesapDB
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        MusteriAd = item["MusteriAd"].ToString(),
                        Telefon = item["Telefon"].ToString(),
                        KimlikNo = item["KimlikNo"].ToString(),
                        DogumTarihi = Convert.ToDateTime(item["DogumTarih"])

                    });
                }
                return PartialView("Index", list.ToPagedList(page ?? 1, 10));
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
                return RedirectToAction("Details", "CariHesap");
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
                return RedirectToAction("Details", "CariHesap");
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Hata");
            }
           
        }

    }
}