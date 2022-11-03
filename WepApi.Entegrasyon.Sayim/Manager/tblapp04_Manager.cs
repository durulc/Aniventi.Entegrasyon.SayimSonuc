using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;
using System;
using WepApi.Entegrasyon.Sayim.Request;
using WepApi.Entegrasyon.Sayim.Response;

namespace WepApi.Entegrasyon.Sayim.Manager
{
    public class tblapp04_Manager
    {
        internal tblapp04verilerresponse fn_tblapp04veriler(tblapp04verilerrequest v_Gelen)
        {
            #region Değişkenler
            tblapp04verilerresponse _Cevap;
            #endregion

            try
            {
                _Cevap = new tblapp04verilerresponse();

                using (Session session = XpoManager.Instance.GetNewSession())
                { 
                }
            }
            catch (Exception ex)
            {
                _Cevap = new tblapp04verilerresponse();
                _Cevap.zSonuc = -1;
                _Cevap.zAciklama = ex.ToString();

                return _Cevap;
            }

            return _Cevap;
                
        }
    }
}