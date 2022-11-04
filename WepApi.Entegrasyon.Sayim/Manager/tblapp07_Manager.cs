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
    public class tblapp07_Manager
    {

        internal tblapp07verilerSilresponse fn_tblapp07verilerSil(tblapp07verilerSilrequest v_Gelen)
        {
            #region Değişkenler
            tblapp07verilerSilresponse _Cevap;
            #endregion
            try
            {
                _Cevap = new tblapp07verilerSilresponse();

                _Cevap.zSonuc = 1;
                _Cevap.zAciklama = "";


                if (v_Gelen.zKullaniciAdi.Equals("Aa1234--") == false || v_Gelen.zSifre.Equals("Aa1234.") == false)
                {
                    _Cevap = new tblapp07verilerSilresponse();
                    _Cevap.zSonuc = -1;
                    _Cevap.zAciklama = "";

                    return _Cevap;
                }

                else
                {
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        tbl07veri _Temp = session.Query<tbl07veri>().FirstOrDefault(w => w.aktif == 1 && w.id.Equals(v_Gelen.zTablodId));

                        if (_Temp != null)
                        {
                            _Temp.createuser = "TAMAM";
                            _Temp.lastupdateuser = "entegrasyon";
                            _Temp.guncellemezamani = DateTime.Now;
                            _Temp.Save();
                        }

                        _Cevap = new tblapp07verilerSilresponse();
                        _Cevap.zSonuc = 1;
                        _Cevap.zAciklama = "";

                        return _Cevap;
                    }
                }


            }
            catch (Exception ex)
            {
                _Cevap = new tblapp07verilerSilresponse();
                _Cevap.zSonuc = -1;
                _Cevap.zAciklama = ex.ToString();

                return _Cevap;
            }

            return _Cevap;
        }

        internal tblapp07verilerresponse fn_tblapp07veriler(tblapp07verilerrequest v_Gelen)
        {
            #region Değişkenler
            tblapp07verilerresponse _Cevap;
            #endregion

            try
            {
                _Cevap = new tblapp07verilerresponse();

                _Cevap.zSonuc = 1;
                _Cevap.zAciklama = "";


                if (v_Gelen.zKullaniciAdi.Equals("Aa1234--") == false || v_Gelen.zSifre.Equals("Aa1234.") == false)
                {
                    _Cevap = new tblapp07verilerresponse();
                    _Cevap.zSonuc = -1;
                    _Cevap.zAciklama = "";
                    _Cevap._zDizi = new List<viewVeri>();

                    return _Cevap;
                }

                else
                {
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        List<viewVeri> _Dizim = (from _tbl07veriyedek in session.Query<tbl07veri>().Where(w => w.createuser.Equals("TAMAM") == false).Take(5).ToList()
                                                    join _tbl06urunkodu in session.Query<tbl06urunkodu>() on _tbl07veriyedek.urunid equals _tbl06urunkodu.id
                                                    where _tbl07veriyedek.aktifetiket.ToString().Length >= 2
                                                    select new viewVeri()
                                                    {
                                                        zTabloId = _tbl07veriyedek.id,
                                                        _date = _tbl07veriyedek.databasekayitzamani,
                                                        zAktifNo = _tbl07veriyedek.aktifetiket,
                                                        databasekayitzamani = "",
                                                        zOdaBarkod = _tbl07veriyedek.odakarekod,
                                                        zPasifEtiket = _tbl07veriyedek.pasifetiket,
                                                        zSeriNo = _tbl07veriyedek.serino,
                                                        zUrunAdi = _tbl06urunkodu.zurunadi
                                                    }).Take(5).Distinct().ToList();
                        _Cevap._zDizi = new List<viewVeri>();
                        _Cevap._zDizi = _Dizim;
                        _Cevap = new tblapp07verilerresponse();
                        _Cevap.zSonuc = 1;
                        _Cevap.zAciklama = "";
                        _Cevap._zDizi = new List<viewVeri>();

                        foreach (var item in _Dizim)
                        {
                            _Cevap._zDizi.Add(new viewVeri()
                            {
                                zTabloId = item.zTabloId,
                                _date = item._date,
                                zAktifNo = item.zAktifNo,
                                databasekayitzamani = "",
                                zOdaBarkod = item.zOdaBarkod,
                                zPasifEtiket = item.zPasifEtiket,
                                zSeriNo = item.zSeriNo,
                                zUrunAdi = item.zUrunAdi
                            });
                        }



                        return _Cevap;


                    }
                }


            }
            catch (Exception ex)
            {
                _Cevap = new tblapp07verilerresponse();
                _Cevap.zSonuc = -1;
                _Cevap.zAciklama = ex.ToString();

                return _Cevap;
            }

            return _Cevap;

        }


    }
}