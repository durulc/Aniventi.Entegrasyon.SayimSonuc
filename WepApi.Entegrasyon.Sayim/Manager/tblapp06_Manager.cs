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
    public class tblapp06_Manager
    {

        internal tblapp06verilerSilresponse fn_tblapp06verilerSil(tblapp06verilerSilrequest v_Gelen)
        {
            #region Değişkenler
            tblapp06verilerSilresponse _Cevap;
            #endregion
            try
            {
                _Cevap = new tblapp06verilerSilresponse();

                _Cevap.zSonuc = 1;
                _Cevap.zAciklama = "";


                if (v_Gelen.zKullaniciAdi.Equals("Aa1234--") == false || v_Gelen.zSifre.Equals("Aa1234.") == false)
                {
                    _Cevap = new tblapp06verilerSilresponse();
                    _Cevap.zSonuc = -1;
                    _Cevap.zAciklama = "";

                    return _Cevap;
                }

                else
                {
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        tbl06urunkodu _Temp = session.Query<tbl06urunkodu>().FirstOrDefault(w => w.aktif == 1 && w.id.Equals(v_Gelen.zTablodId));

                        if (_Temp != null)
                        {
                            _Temp.createuser = "TAMAM";
                            _Temp.lastupdateuser = "entegrasyon";
                            _Temp.guncellemezamani = DateTime.Now;
                            _Temp.Save();
                        }

                        _Cevap = new tblapp06verilerSilresponse();
                        _Cevap.zSonuc = 1;
                        _Cevap.zAciklama = "";

                        return _Cevap;
                    }
                }


            }
            catch (Exception ex)
            {
                _Cevap = new tblapp06verilerSilresponse();
                _Cevap.zSonuc = -1;
                _Cevap.zAciklama = ex.ToString();

                return _Cevap;
            }

            return _Cevap;
        }

        internal tblapp06verilerresponse fn_tblapp06veriler(tblapp06verilerrequest v_Gelen)
        {
            #region Değişkenler
            tblapp06verilerresponse _Cevap;
            #endregion

            try
            {
                _Cevap = new tblapp06verilerresponse();

                _Cevap.zSonuc = 1;
                _Cevap.zAciklama = "";


                if (v_Gelen.zKullaniciAdi.Equals("Aa1234--") == false || v_Gelen.zSifre.Equals("Aa1234.") == false)
                {
                    _Cevap = new tblapp06verilerresponse();
                    _Cevap.zSonuc = -1;
                    _Cevap.zAciklama = "";
                    _Cevap._zDizi = new List<viewVeri6>();

                    return _Cevap;
                }

                else
                {
                    var sayi = Convert.ToInt32(ConfigurationManager.AppSettings["Sayi"].ToString().Trim());
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        //List<tbl06urunkodu> _Dizim = (from _tbl06 in session.Query<tbl06urunkodu>()
                        //                          where _tbl06.createuser != "TAMAM" || _tbl06.createuser == null
                        //                          select new viewVeri6()
                        //                          {
                        //                              zTabloId = _tbl06.id,
                        //                              databasekayitzamani = _tbl06.databasekayitzamani.ToString(),
                        //                              zurunadi = _tbl06.zurunadi,
                        //                              zetiketturu = _tbl06.zetiketturu
                        //                          }).Take(sayi).ToList();

                        List<tbl06urunkodu> _Dizim = session.Query<tbl06urunkodu>().Where(w => w.createuser != "TAMAM" || w.createuser == null).Take(sayi).ToList();
                        _Cevap = new tblapp06verilerresponse();
                        _Cevap.zSonuc = 1;
                        _Cevap.zAciklama = "";
                        _Cevap._zDizi = new List<viewVeri6>();

                        foreach (var _tbl06 in _Dizim)
                        {
                            _Cevap._zDizi.Add(new viewVeri6()
                            {
                                zTabloId = _tbl06.id,
                                databasekayitzamani = _tbl06.databasekayitzamani,
                                zurunadi = _tbl06.zurunadi,
                                zetiketturu = _tbl06.zetiketturu
                            });
                        }

                        return _Cevap;


                    }
                }


            }
            catch (Exception ex)
            {
                _Cevap = new tblapp06verilerresponse();
                _Cevap.zSonuc = -1;
                _Cevap.zAciklama = ex.ToString();

                return _Cevap;
            }


        }





    }
}