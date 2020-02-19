using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace NZF_DAL
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;

    public class Siparis : DataAccesBase
    {

        string m_SQL;
        int m_ConCount;
		int m_ID; 


        public Int32 PersonelID;
        public Int32 KagitGramiIc;
        public Int32 KagitGramiDis;
        public String KkagitCinsiIc;
        public String KkagitCinsiDis;
        public String KebatIc;
        public String KebatDis;
        public Int32 KadetIc;
        public Int32 KadetDis;
        public String BmakinaIc;
        public String BMakinaDis;
        public String BebatIc;
        public String BebatDis;
        public String BadetIc;
        public String BadetDis;
        public String BrenkIc;
        public String BrenkDis;
        public String BkalipIc;
        public String BkalipDis;
        public String BbaskiIc;
        public String BbaskiDis;
        public String BformaIc;
        public String BformaDis;
        public String Bnot;
        public String Sselefon;
        public String SselefonDis;
        public String Slak;
        public String SlakDis;
        public String Sgofre;
        public String SgofreDis;
        public String Svarak;
        public String SvarakDis;
        public String Sperforaj;
        public String SperforajDis;
        public String SozelKesim;
        public String SozelKesimDis;
        public String Scilt;
        public String SciltDis;
        public String Skirim;
        public String SkirimDis;
        public String Syapistirma;
        public String SyapistirmaDis;
        public String Ssivama;
        public String SsivamaDis;
        public String Staslama;
        public String StaslamaDis;
        public String Snumarator;
        public String SnumaratorDis;
        public String Skesim;
        public String SkesimDis;
        public String Spaket;
        public String SpaketDis;
        public String Snot;
        public String Tpaket;
        public String TteslimAlacakKisi;
        public String TodemeSekli;
        public String TteslimYeri;
        public String Prova;
        public String Maket;
        public String Ornek;
        public Int32 Madet;
        public String Mebat;
        public String Mnot;
        public String MisinAdi;
        public String Mozellikler;
        public Int32 CariID;
        public System.DateTime TeslimTarihi = Convert.ToDateTime("1900-01-01");
        public System.DateTime SiparisTarihi = Convert.ToDateTime("1900-01-01");
        public String ToplamTutar;
        public String SiparisDurum;
        public Int32 IsActive;
        public String YetkiID;
		    


        public int ID
        {
            get { return m_ID; }
        }

        public Siparis ()
        {
        }
        public Siparis (int pID)
        {
            m_SQL = "Select * from Siparis where ID=" + pID;
            initialize();
        }

        public Siparis(string pFIELD_NAME, string pVALUE)
        {
            m_SQL = "Select * from Siparis where " + pFIELD_NAME + "='" + pVALUE + "'";
            initialize();
        }
 

        public bool initialize()
        {
            DataTable DT = ReturnDataTable(m_SQL);
            try
            {
                m_ConCount = DT.Rows.Count;
                if (DT.Rows.Count == 0)
                {
                    m_ID = 0;
                    return true;
                }
                m_ID = Convert.ToInt32( DT.Rows[0]["ID"]);
                PersonelID = Convert.ToInt32(DT.Rows[0]["PersonelID"]);
                KagitGramiIc = Convert.ToInt32(DT.Rows[0]["KagitGramiIc"]);
                KagitGramiDis = Convert.ToInt32(DT.Rows[0]["KagitGramiDis"]);
                KkagitCinsiIc = Convert.ToString(DT.Rows[0]["KkagitCinsiIc"]);
                KkagitCinsiDis = Convert.ToString(DT.Rows[0]["KkagitCinsiDis"]);
                KebatIc = Convert.ToString(DT.Rows[0]["KebatIc"]);
                KebatDis = Convert.ToString(DT.Rows[0]["KebatDis"]);
                KadetIc = Convert.ToInt32(DT.Rows[0]["KadetIc"]);
                KadetDis = Convert.ToInt32(DT.Rows[0]["KadetDis"]);
                BmakinaIc = Convert.ToString(DT.Rows[0]["BmakinaIc"]);
                BMakinaDis = Convert.ToString(DT.Rows[0]["BMakinaDis"]);
                BebatIc = Convert.ToString(DT.Rows[0]["BebatIc"]);
                BebatDis = Convert.ToString(DT.Rows[0]["BebatDis"]);
                BadetIc = Convert.ToString(DT.Rows[0]["BadetIc"]);
                BadetDis = Convert.ToString(DT.Rows[0]["BadetDis"]);
                BrenkIc = Convert.ToString(DT.Rows[0]["BrenkIc"]);
                BrenkDis = Convert.ToString(DT.Rows[0]["BrenkDis"]);
                BkalipIc = Convert.ToString(DT.Rows[0]["BkalipIc"]);
                BkalipDis = Convert.ToString(DT.Rows[0]["BkalipDis"]);
                BbaskiIc = Convert.ToString(DT.Rows[0]["BbaskiIc"]);
                BbaskiDis = Convert.ToString(DT.Rows[0]["BbaskiDis"]);
                BformaIc = Convert.ToString(DT.Rows[0]["BformaIc"]);
                BformaDis = Convert.ToString(DT.Rows[0]["BformaDis"]);
                Bnot = Convert.ToString(DT.Rows[0]["Bnot"]);
                Sselefon = Convert.ToString(DT.Rows[0]["Sselefon"]);
                SselefonDis = Convert.ToString(DT.Rows[0]["SselefonDis"]);
                Slak = Convert.ToString(DT.Rows[0]["Slak"]);
                SlakDis = Convert.ToString(DT.Rows[0]["SlakDis"]);
                Sgofre = Convert.ToString(DT.Rows[0]["Sgofre"]);
                SgofreDis = Convert.ToString(DT.Rows[0]["SgofreDis"]);
                Svarak = Convert.ToString(DT.Rows[0]["Svarak"]);
                SvarakDis = Convert.ToString(DT.Rows[0]["SvarakDis"]);
                Sperforaj = Convert.ToString(DT.Rows[0]["Sperforaj"]);
                SperforajDis = Convert.ToString(DT.Rows[0]["SperforajDis"]);
                SozelKesim = Convert.ToString(DT.Rows[0]["SozelKesim"]);
                SozelKesimDis = Convert.ToString(DT.Rows[0]["SozelKesimDis"]);
                Scilt = Convert.ToString(DT.Rows[0]["Scilt"]);
                SciltDis = Convert.ToString(DT.Rows[0]["SciltDis"]);
                Skirim = Convert.ToString(DT.Rows[0]["Skirim"]);
                SkirimDis = Convert.ToString(DT.Rows[0]["SkirimDis"]);
                Syapistirma = Convert.ToString(DT.Rows[0]["Syapistirma"]);
                SyapistirmaDis = Convert.ToString(DT.Rows[0]["SyapistirmaDis"]);
                Ssivama = Convert.ToString(DT.Rows[0]["Ssivama"]);
                SsivamaDis = Convert.ToString(DT.Rows[0]["SsivamaDis"]);
                Staslama = Convert.ToString(DT.Rows[0]["Staslama"]);
                StaslamaDis = Convert.ToString(DT.Rows[0]["StaslamaDis"]);
                Snumarator = Convert.ToString(DT.Rows[0]["Snumarator"]);
                SnumaratorDis = Convert.ToString(DT.Rows[0]["SnumaratorDis"]);
                Skesim = Convert.ToString(DT.Rows[0]["Skesim"]);
                SkesimDis = Convert.ToString(DT.Rows[0]["SkesimDis"]);
                Spaket = Convert.ToString(DT.Rows[0]["Spaket"]);
                SpaketDis = Convert.ToString(DT.Rows[0]["SpaketDis"]);
                Snot = Convert.ToString(DT.Rows[0]["Snot"]);
                Tpaket = Convert.ToString(DT.Rows[0]["Tpaket"]);
                TteslimAlacakKisi = Convert.ToString(DT.Rows[0]["TteslimAlacakKisi"]);
                TodemeSekli = Convert.ToString(DT.Rows[0]["TodemeSekli"]);
                TteslimYeri = Convert.ToString(DT.Rows[0]["TteslimYeri"]);
                Prova = Convert.ToString(DT.Rows[0]["Prova"]);
                Maket = Convert.ToString(DT.Rows[0]["Maket"]);
                Ornek = Convert.ToString(DT.Rows[0]["Ornek"]);
                Madet = Convert.ToInt32(DT.Rows[0]["Madet"]);
                Mebat = Convert.ToString(DT.Rows[0]["Mebat"]);
                Mnot = Convert.ToString(DT.Rows[0]["Mnot"]);
                MisinAdi = Convert.ToString(DT.Rows[0]["MisinAdi"]);
                Mozellikler = Convert.ToString(DT.Rows[0]["Mozellikler"]);
                CariID = Convert.ToInt32(DT.Rows[0]["CariID"]);
                TeslimTarihi = Convert.ToDateTime(DT.Rows[0]["TeslimTarihi"]);
                SiparisTarihi = Convert.ToDateTime(DT.Rows[0]["SiparisTarihi"]);
                ToplamTutar = Convert.ToString(DT.Rows[0]["ToplamTutar"]);
                SiparisDurum = Convert.ToString(DT.Rows[0]["SiparisDurum"]);
                IsActive = Convert.ToInt32(DT.Rows[0]["IsActive"]);
                YetkiID = Convert.ToString(DT.Rows[0]["YetkiID"]);

                DT.Dispose();
            }
            catch (Exception ex)
            {
            }
            return true;
        }

       public void Kaydet()
        {
            if (Kontrol())
            {
                switch (m_ID)
                {
                    case 0:
                        KaydetInsert();
                        break;
                    default:
                        KaydetUpdate();
                        break;
                }
            }
        }


        public bool Kontrol()
        {
            return true;
        }

		
		
		
		private int KaydetInsert()
        {
            string SQL = null;

			SQL="Insert Into Siparis (PersonelID, KagitGramiIc, KagitGramiDis, KkagitCinsiIc, ";
            SQL += "KkagitCinsiDis, KebatIc, KebatDis, KadetIc, ";
            SQL += "KadetDis, BmakinaIc, BMakinaDis, BebatIc, ";
            SQL += "BebatDis, BadetIc, BadetDis, BrenkIc, ";
            SQL += "BrenkDis, BkalipIc, BkalipDis, BbaskiIc, ";
            SQL += "BbaskiDis, BformaIc, BformaDis, Bnot, ";
            SQL += "Sselefon, SselefonDis, Slak, SlakDis, ";
            SQL += "Sgofre, SgofreDis, Svarak, SvarakDis, ";
            SQL += "Sperforaj, SperforajDis, SozelKesim, SozelKesimDis, ";
            SQL += "Scilt, SciltDis, Skirim, SkirimDis, ";
            SQL += "Syapistirma, SyapistirmaDis, Ssivama, SsivamaDis, ";
            SQL += "Staslama, StaslamaDis, Snumarator, SnumaratorDis, ";
            SQL += "Skesim, SkesimDis, Spaket, SpaketDis, ";
            SQL += "Snot, Tpaket, TteslimAlacakKisi, TodemeSekli, ";
            SQL += "TteslimYeri, Prova, Maket, Ornek, ";
            SQL += "Madet, Mebat, Mnot, MisinAdi, ";
            SQL += "Mozellikler, CariID, TeslimTarihi, SiparisTarihi, ";
            SQL += "ToplamTutar, SiparisDurum, IsActive, YetkiID";
            SQL += ") values (";
            SQL += "  " + PersonelID + " ,";
            SQL += "  " + KagitGramiIc + " ,";
            SQL += "  " + KagitGramiDis + " ,";
            SQL += "'" + KkagitCinsiIc + "',";
            SQL += "'" + KkagitCinsiDis + "',";
            SQL += "'" + KebatIc + "',";
            SQL += "'" + KebatDis + "',";
            SQL += "  " + KadetIc + " ,";
            SQL += "  " + KadetDis + " ,";
            SQL += "'" + BmakinaIc + "',";
            SQL += "'" + BMakinaDis + "',";
            SQL += "'" + BebatIc + "',";
            SQL += "'" + BebatDis + "',";
            SQL += "'" + BadetIc + "',";
            SQL += "'" + BadetDis + "',";
            SQL += "'" + BrenkIc + "',";
            SQL += "'" + BrenkDis + "',";
            SQL += "'" + BkalipIc + "',";
            SQL += "'" + BkalipDis + "',";
            SQL += "'" + BbaskiIc + "',";
            SQL += "'" + BbaskiDis + "',";
            SQL += "'" + BformaIc + "',";
            SQL += "'" + BformaDis + "',";
            SQL += "'" + Bnot + "',";
            SQL += "'" + Sselefon + "',";
            SQL += "'" + SselefonDis + "',";
            SQL += "'" + Slak + "',";
            SQL += "'" + SlakDis + "',";
            SQL += "'" + Sgofre + "',";
            SQL += "'" + SgofreDis + "',";
            SQL += "'" + Svarak + "',";
            SQL += "'" + SvarakDis + "',";
            SQL += "'" + Sperforaj + "',";
            SQL += "'" + SperforajDis + "',";
            SQL += "'" + SozelKesim + "',";
            SQL += "'" + SozelKesimDis + "',";
            SQL += "'" + Scilt + "',";
            SQL += "'" + SciltDis + "',";
            SQL += "'" + Skirim + "',";
            SQL += "'" + SkirimDis + "',";
            SQL += "'" + Syapistirma + "',";
            SQL += "'" + SyapistirmaDis + "',";
            SQL += "'" + Ssivama + "',";
            SQL += "'" + SsivamaDis + "',";
            SQL += "'" + Staslama + "',";
            SQL += "'" + StaslamaDis + "',";
            SQL += "'" + Snumarator + "',";
            SQL += "'" + SnumaratorDis + "',";
            SQL += "'" + Skesim + "',";
            SQL += "'" + SkesimDis + "',";
            SQL += "'" + Spaket + "',";
            SQL += "'" + SpaketDis + "',";
            SQL += "'" + Snot + "',";
            SQL += "'" + Tpaket + "',";
            SQL += "'" + TteslimAlacakKisi + "',";
            SQL += "'" + TodemeSekli + "',";
            SQL += "'" + TteslimYeri + "',";
            SQL += "'" + Prova + "',";
            SQL += "'" + Maket + "',";
            SQL += "'" + Ornek + "',";
            SQL += "  " + Madet + " ,";
            SQL += "'" + Mebat + "',";
            SQL += "'" + Mnot + "',";
            SQL += "'" + MisinAdi + "',";
            SQL += "'" + Mozellikler + "',";
            SQL += "  " + CariID + " ,";
            SQL += "'" + TeslimTarihi.ToString("yyyyMMdd") + " ',";
            SQL += "'" + SiparisTarihi.ToString("yyyyMMdd") + " ',";
            SQL += "'" + ToplamTutar + "',";
            SQL += "'" + SiparisDurum + "',";
            SQL += "  " + IsActive + " ,";
            SQL += "'" + YetkiID + "'";
            SQL += ") SELECT @@IDENTITY AS ID ";   

            DataSet DS = new DataSet();
            try
            {
                this.FillDataSet(DS, SQL);
                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                {
                    m_ID = int.Parse(DS.Tables[0].Rows[0]["ID"].ToString());

                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message + " Hatasql:" + SQL);
            }
            finally
            {
                DS.Dispose();
            }
            return 0;
        }
		
		
		
		
		
		
         private int KaydetUpdate()
        {
            string SQL = null;

            SQL = "UPDATE Siparis SET ";
            SQL += "PersonelID=  " + PersonelID + " ,";
            SQL += "KagitGramiIc=  " + KagitGramiIc + " ,";
            SQL += "KagitGramiDis=  " + KagitGramiDis + " ,";
            SQL += "KkagitCinsiIc='" + KkagitCinsiIc + "',";
            SQL += "KkagitCinsiDis='" + KkagitCinsiDis + "',";
            SQL += "KebatIc='" + KebatIc + "',";
            SQL += "KebatDis='" + KebatDis + "',";
            SQL += "KadetIc=  " + KadetIc + " ,";
            SQL += "KadetDis=  " + KadetDis + " ,";
            SQL += "BmakinaIc='" + BmakinaIc + "',";
            SQL += "BMakinaDis='" + BMakinaDis + "',";
            SQL += "BebatIc='" + BebatIc + "',";
            SQL += "BebatDis='" + BebatDis + "',";
            SQL += "BadetIc='" + BadetIc + "',";
            SQL += "BadetDis='" + BadetDis + "',";
            SQL += "BrenkIc='" + BrenkIc + "',";
            SQL += "BrenkDis='" + BrenkDis + "',";
            SQL += "BkalipIc='" + BkalipIc + "',";
            SQL += "BkalipDis='" + BkalipDis + "',";
            SQL += "BbaskiIc='" + BbaskiIc + "',";
            SQL += "BbaskiDis='" + BbaskiDis + "',";
            SQL += "BformaIc='" + BformaIc + "',";
            SQL += "BformaDis='" + BformaDis + "',";
            SQL += "Bnot='" + Bnot + "',";
            SQL += "Sselefon='" + Sselefon + "',";
            SQL += "SselefonDis='" + SselefonDis + "',";
            SQL += "Slak='" + Slak + "',";
            SQL += "SlakDis='" + SlakDis + "',";
            SQL += "Sgofre='" + Sgofre + "',";
            SQL += "SgofreDis='" + SgofreDis + "',";
            SQL += "Svarak='" + Svarak + "',";
            SQL += "SvarakDis='" + SvarakDis + "',";
            SQL += "Sperforaj='" + Sperforaj + "',";
            SQL += "SperforajDis='" + SperforajDis + "',";
            SQL += "SozelKesim='" + SozelKesim + "',";
            SQL += "SozelKesimDis='" + SozelKesimDis + "',";
            SQL += "Scilt='" + Scilt + "',";
            SQL += "SciltDis='" + SciltDis + "',";
            SQL += "Skirim='" + Skirim + "',";
            SQL += "SkirimDis='" + SkirimDis + "',";
            SQL += "Syapistirma='" + Syapistirma + "',";
            SQL += "SyapistirmaDis='" + SyapistirmaDis + "',";
            SQL += "Ssivama='" + Ssivama + "',";
            SQL += "SsivamaDis='" + SsivamaDis + "',";
            SQL += "Staslama='" + Staslama + "',";
            SQL += "StaslamaDis='" + StaslamaDis + "',";
            SQL += "Snumarator='" + Snumarator + "',";
            SQL += "SnumaratorDis='" + SnumaratorDis + "',";
            SQL += "Skesim='" + Skesim + "',";
            SQL += "SkesimDis='" + SkesimDis + "',";
            SQL += "Spaket='" + Spaket + "',";
            SQL += "SpaketDis='" + SpaketDis + "',";
            SQL += "Snot='" + Snot + "',";
            SQL += "Tpaket='" + Tpaket + "',";
            SQL += "TteslimAlacakKisi='" + TteslimAlacakKisi + "',";
            SQL += "TodemeSekli='" + TodemeSekli + "',";
            SQL += "TteslimYeri='" + TteslimYeri + "',";
            SQL += "Prova='" + Prova + "',";
            SQL += "Maket='" + Maket + "',";
            SQL += "Ornek='" + Ornek + "',";
            SQL += "Madet=  " + Madet + " ,";
            SQL += "Mebat='" + Mebat + "',";
            SQL += "Mnot='" + Mnot + "',";
            SQL += "MisinAdi='" + MisinAdi + "',";
            SQL += "Mozellikler='" + Mozellikler + "',";
            SQL += "CariID=  " + CariID + " ,";
            SQL += "TeslimTarihi='" + TeslimTarihi.ToString("yyyyMMdd") + " ',";
            SQL += "SiparisTarihi='" + SiparisTarihi.ToString("yyyyMMdd") + " ',";
            SQL += "ToplamTutar='" + ToplamTutar + "',";
            SQL += "SiparisDurum='" + SiparisDurum + "',";
            SQL += "IsActive=  " + IsActive + " ,";
            SQL += "YetkiID=  '" + YetkiID + "'   ";
            SQL += " WHERE ID=" + m_ID;

            try
            {
                this.ExecuteSQL(SQL);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message + " Hatasql:" + SQL);
            }
            return 0;
        }
	
	
	
	
	
	
       public object Delete()
        {
            m_SQL = "Delete from Siparis where ID=" + m_ID;
            this.ExecuteSQL(m_SQL);
            return true;
        }

 
	}
}	

