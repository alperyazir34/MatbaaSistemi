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

    public class YetkiDurum : DataAccesBase
    {

        string m_SQL;
        int m_ConCount;
		int m_ID; 


        public String Yetki;
		    


        public int ID
        {
            get { return m_ID; }
        }

        public YetkiDurum ()
        {
        }
        public YetkiDurum (int pID)
        {
            m_SQL = "Select * from YetkiDurum where ID=" + pID;
            initialize();
        }

        public YetkiDurum(string pFIELD_NAME, string pVALUE)
        {
            m_SQL = "Select * from YetkiDurum where " + pFIELD_NAME + "='" + pVALUE + "'";
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
                Yetki = Convert.ToString(DT.Rows[0]["Yetki"]);

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

			SQL="Insert Into YetkiDurum (Yetki) values (";
            SQL += "'" + Yetki + "'  ";
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

            SQL = "UPDATE YetkiDurum SET ";
            SQL += "Yetki='" + Yetki + "'  ";
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
            m_SQL = "Delete from YetkiDurum where ID=" + m_ID;
            this.ExecuteSQL(m_SQL);
            return true;
        }

 
	}
}	

