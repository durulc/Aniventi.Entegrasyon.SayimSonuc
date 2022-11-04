using Aniventi.Entegtasyon.Entity.EntityFramework;
using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;
using System;
using System.Linq;
using System.Collections.Generic;
using WepApi.Entegrasyon.Sayim.Request;
using WepApi.Entegrasyon.Sayim.Response;

namespace WepApi.Entegrasyon.Sayim.Manager
{
    public class tblapp04_Manager
    {

        internal tblapp04verilerSilresponse fn_tblapp04verilerSil(tblapp04verilerSilrequest v_Gelen)
        {
            #region Değişkenler
            tblapp04verilerSilresponse _Cevap;
            #endregion
            try
            {
                _Cevap = new tblapp04verilerSilresponse();

                _Cevap.zSonuc = 1;
                _Cevap.zAciklama = "";


                if (v_Gelen.zKullaniciAdi.Equals("Aa1234--") == false || v_Gelen.zSifre.Equals("Aa1234.") == false)
                {
                    _Cevap = new tblapp04verilerSilresponse();
                    _Cevap.zSonuc = -1;
                    _Cevap.zAciklama = "";

                    return _Cevap;
                }

                else
                {
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        tblapp04 _Temp = session.Query<tblapp04>().FirstOrDefault(w => w.aktif == 1 && w.id.Equals(v_Gelen.zTablodId));

                        if (_Temp != null)
                        {
                            _Temp.aktif = 0;
                            _Temp.lastupdateuser = "entegrasyon";
                            _Temp.guncellemezamani = DateTime.Now;
                            _Temp.Save();
                        }

                        _Cevap = new  tblapp04verilerSilresponse();
                        _Cevap.zSonuc = 1;
                        _Cevap.zAciklama = "";

                        return _Cevap;
                    }
                }


            }
            catch (Exception ex)
            {
                _Cevap = new tblapp04verilerSilresponse();
                _Cevap.zSonuc = -1;
                _Cevap.zAciklama = ex.ToString();

                return _Cevap;
            }

            return _Cevap;
        }

        internal tblapp04verilerresponse fn_tblapp04veriler(tblapp04verilerrequest v_Gelen)
        {
            #region Değişkenler
            tblapp04verilerresponse _Cevap;
            #endregion

            try
            {
                _Cevap = new tblapp04verilerresponse();

                _Cevap.zSonuc = 1;
                _Cevap.zAciklama = "";


                if (v_Gelen.zKullaniciAdi.Equals("Aa1234--") == false || v_Gelen.zSifre.Equals("Aa1234.") == false)
                {
                    _Cevap = new tblapp04verilerresponse();
                    _Cevap.zSonuc = -1;
                    _Cevap.zAciklama = "";
                    _Cevap._Dizi = new List<_Veri>();

                    return _Cevap;
                }

                else {
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        List<tblapp04> _Dizim = session.Query<tblapp04>().Where(w => w.aktif == 1).Take(50).ToList();

                        _Cevap = new tblapp04verilerresponse();
                        _Cevap.zSonuc = 1;
                        _Cevap.zAciklama = "";
                        _Cevap._Dizi = new List<_Veri>();

                        foreach (var item in _Dizim)
                        {
                            _Cevap._Dizi.Add(new _Veri()
                            {
                                databasekayitzamani = item.databasekayitzamani,
                                epc = item.epc,
                                id = item.id,
                                sayimoda = item.sayimoda,
                                sayimserino = item.sayimserino
                            });
                        }



                        return _Cevap;


                    }
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