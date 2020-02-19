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

    public class CariHesap : DataAccesBase
    {

        string m_SQL;
        int m_ConCount;
		int m_ID; 


        public String KimlikNo;
        public String MusteriAd;
        public String MusteriSoyAd;
        public System.DateTime DogumTarih = Convert.ToDateTime("1900-01-01");
        public String Cinsiyet;
        public String Unvan;
        public String Adres;
        public String Telefon;
        public String CepTel;
        public String EMail;
        public String VergiDairesi;
        public String VergiNo;
        public String TeslimatAdres;
		    


        public int ID
        {
            get { return m_ID; }
        }

        public CariHesap ()
        {
        }
        public CariHesap (int pID)
        {
            m_SQL = "Select * from CariHesap where ID=" + pID;
            initialize();
        }

        public CariHesap(string pFIELD_NAME, string pVALUE)
        {
            m_SQL = "Select * from CariHesap where " + pFIELD_NAME + "='" + pVALUE + "'";
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
                KimlikNo = Convert.ToString(DT.Rows[0]["KimlikNo"]);
                MusteriAd = Convert.ToString(DT.Rows[0]["MusteriAd"]);
                MusteriSoyAd = Convert.ToString(DT.Rows[0]["MusteriSoyAd"]);
                DogumTarih = Convert.ToDateTime(DT.Rows[0]["DogumTarih"]);
                Cinsiyet = Convert.ToString(DT.Rows[0]["Cinsiyet"]);
                Unvan = Convert.ToString(DT.Rows[0]["Unvan"]);
                Adres = Convert.ToString(DT.Rows[0]["Adres"]);
                Telefon = Convert.ToString(DT.Rows[0]["Telefon"]);
                CepTel = Convert.ToString(DT.Rows[0]["CepTel"]);
                EMail = Convert.ToString(DT.Rows[0]["EMail"]);
                VergiDairesi = Convert.ToString(DT.Rows[0]["VergiDairesi"]);
                VergiNo = Convert.ToString(DT.Rows[0]["VergiNo"]);
                TeslimatAdres = Convert.ToString(DT.Rows[0]["TeslimatAdres"]);

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

			SQL="Insert Into CariHesap (KimlikNo, MusteriAd, MusteriSoyAd, DogumTarih, ";
            SQL += "Cinsiyet, Unvan, Adres, Telefon, ";
            SQL += "CepTel, EMail, VergiDairesi, VergiNo, ";
            SQL += "TeslimatAdres) values (";
            SQL += "'" + KimlikNo + "',";
            SQL += "'" + MusteriAd + "',";
            SQL += "'" + MusteriSoyAd + "',";
            SQL += "'" + DogumTarih.ToString("yyyy-MM-dd") + " ',";
            SQL += "'" + Cinsiyet + "',";
            SQL += "'" + Unvan + "',";
            SQL += "'" + Adres + "',";
            SQL += "'" + Telefon + "',";
            SQL += "'" + CepTel + "',";
            SQL += "'" + EMail + "',";
            SQL += "'" + VergiDairesi + "',";
            SQL += "'" + VergiNo + "',";
            SQL += "'" + TeslimatAdres + "'  ";
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

            SQL = "UPDATE CariHesap SET ";
            SQL += "KimlikNo='" + KimlikNo + "',";
            SQL += "MusteriAd='" + MusteriAd + "',";
            SQL += "MusteriSoyAd='" + MusteriSoyAd + "',";
            SQL += "DogumTarih='" + DogumTarih.ToString("yyyy-MM-dd") + " ',";
            SQL += "Cinsiyet='" + Cinsiyet + "',";
            SQL += "Unvan='" + Unvan + "',";
            SQL += "Adres='" + Adres + "',";
            SQL += "Telefon='" + Telefon + "',";
            SQL += "CepTel='" + CepTel + "',";
            SQL += "EMail='" + EMail + "',";
            SQL += "VergiDairesi='" + VergiDairesi + "',";
            SQL += "VergiNo='" + VergiNo + "',";
            SQL += "TeslimatAdres='" + TeslimatAdres + "'  ";
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
            m_SQL = "Delete from CariHesap where ID=" + m_ID;
            this.ExecuteSQL(m_SQL);
            return true;
        }

 
	}
}	

