using Aniventi.Entegtasyon.Entity.EntityFramework;
using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;
using System;
using System.Linq;
using System.Collections.Generic;
using WepApi.Entegrasyon.Sayim.Request;
using WepApi.Entegrasyon.Sayim.Response;
using System.Configuration;

namespace WepApi.Entegrasyon.Sayim.Manager
{
    public class tblapp01_Manager
    {

        internal tblapp01verilerSilresponse fn_tblapp01verilerSil(tblapp01verilerSilrequest v_Gelen)
        {
            #region Değişkenler
            tblapp01verilerSilresponse _Cevap;
            #endregion
            try
            {
                _Cevap = new tblapp01verilerSilresponse();

                _Cevap.zSonuc = 1;
                _Cevap.zAciklama = "";


                if (v_Gelen.zKullaniciAdi.Equals("Aa1234--") == false || v_Gelen.zSifre.Equals("Aa1234.") == false)
                {
                    _Cevap = new tblapp01verilerSilresponse();
                    _Cevap.zSonuc = -1;
                    _Cevap.zAciklama = "";

                    return _Cevap;
                }

                else
                {
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        tblapp01 _Temp = session.Query<tblapp01>().FirstOrDefault(w => w.id == v_Gelen.zTablodId.ToString());

                        if (_Temp != null)
                        {
                            try
                            {

                                _Temp.createuser = "TAMAM";
                                _Temp.lastupdateuser = "entegrasyon";
                                _Temp.guncellemezamani = DateTime.Now;
                                _Temp.Save();

                                _Cevap = new tblapp01verilerSilresponse();
                                _Cevap.zSonuc = 1;
                                _Cevap.zAciklama = "TAMAM";

                                return _Cevap;
                            }
                            catch (Exception ex)
                            {
                                _Cevap = new tblapp01verilerSilresponse();
                                _Cevap.zSonuc = 1;
                                _Cevap.zAciklama = ex.ToString();

                                return _Cevap;
                            }
                        }
                        else {
                            _Cevap = new tblapp01verilerSilresponse();
                            _Cevap.zSonuc = 1;
                            _Cevap.zAciklama ="null geldi::"  +v_Gelen.zTablodId.ToString();

                            return _Cevap;
                        }

                        _Cevap = new tblapp01verilerSilresponse();
                        _Cevap.zSonuc = 1;
                        _Cevap.zAciklama = "";

                        return _Cevap;
                    }
                }


            }
            catch (Exception ex)
            {
                _Cevap = new tblapp01verilerSilresponse();
                _Cevap.zSonuc = -1;
                _Cevap.zAciklama = ex.ToString();

                return _Cevap;
            }

        }

        internal tblapp01verilerresponse fn_tblapp01veriler(tblapp01verilerrequest v_Gelen)
        {
            #region Değişkenler
            tblapp01verilerresponse _Cevap;
            #endregion

            try
            {
                _Cevap = new tblapp01verilerresponse();

                _Cevap.zSonuc = 1;
                _Cevap.zAciklama = "";


                if (v_Gelen.zKullaniciAdi.Equals("Aa1234--") == false || v_Gelen.zSifre.Equals("Aa1234.") == false)
                {
                    _Cevap = new tblapp01verilerresponse();
                    _Cevap.zSonuc = -1;
                    _Cevap.zAciklama = "";
                    _Cevap._Dizi = new List<_Veri01>();

                    return _Cevap;
                }

                else
                {
                    var sayi = Convert.ToInt32(ConfigurationManager.AppSettings["Sayi"].ToString().Trim());
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        List<tblapp01> _Dizim = session.Query<tblapp01>().Where(w => w.createuser != "TAMAM").Take(sayi).ToList();

                        _Cevap = new tblapp01verilerresponse();
                        _Cevap.zSonuc = 1;
                        _Cevap.zAciklama = "";
                        _Cevap._Dizi = new List<_Veri01>();

                        foreach (var item in _Dizim)
                        {
                            _Cevap._Dizi.Add(new _Veri01()
                            {
                                databasekayitzamani = item.databasekayitzamani,
                                id = item.id,
                                zfloorcode = item.zfloorcode,
                                zmahaladi = item.zmahaladi,
                                zsectorcode = item.zsectorcode,
                                zroomcode = item.zroomcode,
                                karekod = item.karekod,
                                zblok = item.zblok,
                                zuruntip = item.zuruntip,
                                zmiktar = item.zmiktar,
                                zparcaliurun = item.zparcaliurun,
                                zparcasayisi = item.zparcasayisi,
                                zetikettipi = item.zetikettipi,
                                zetiketturu = item.zetiketturu,
                                zrfidno = item.zrfidno
                            });
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                _Cevap = new tblapp01verilerresponse();
                _Cevap.zSonuc = -1;
                _Cevap.zAciklama = ex.ToString();

                
            }

            return _Cevap;

        }


    }
}