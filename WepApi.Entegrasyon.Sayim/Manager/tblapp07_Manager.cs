using Aniventi.Entegtasyon.Entity.EntityFramework;
using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;
using System;
using System.Linq;
using System.Collections.Generic;
using WepApi.Entegrasyon.Sayim.Request;
using WepApi.Entegrasyon.Sayim.Response;
using System.Configuration;
using DevExpress.Office.Utils;
using System.Data;

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
                            _Temp.lastupdateuser = "newentegrasyon";
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
                    var sayi = Convert.ToInt32(ConfigurationManager.AppSettings["Sayi"].ToString().Trim());
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        List<viewVeri> _Dizim = (from _tbl07veriyedek in session.Query<tbl07veri>()
                                                 join _tbl06urunkodu in session.Query<tbl06urunkodu>() on _tbl07veriyedek.urunid equals _tbl06urunkodu.id
                                                 join _tblexcel in session.Query<tblexcel>() on _tbl07veriyedek.urunid.Replace(" ", "") equals _tblexcel.id.DefaultIfEmpty()
                                                 where _tbl07veriyedek.aktifetiket.ToString().Length >= 2 && _tbl07veriyedek.createuser != "TAMAM"
                                                 select new viewVeri()
                                                 {
                                                     zTabloId = _tbl07veriyedek.id,
                                                     _date = _tbl07veriyedek.databasekayitzamani,
                                                     zAktifNo = _tbl07veriyedek.aktifetiket,
                                                     databasekayitzamani = _tbl07veriyedek.databasekayitzamani,
                                                     zOdaBarkod = _tbl07veriyedek.odakarekod,
                                                     zPasifEtiket = _tbl07veriyedek.pasifetiket,
                                                     zSeriNo = _tbl07veriyedek.serino,
                                                     zUrunAdi = _tbl06urunkodu.zurunadi,
                                                     zName = _tblexcel.zsectorcode,
                                                     zSurname = _tblexcel.zroomcode
                                                 }).Distinct().Take(sayi).ToList();

                        //string _Sql = "Select * from tbl07veri" +
                        //    "join tbl06urunkodu on tbl07veri.urunid = tbl06urunkodu.id" +
                        //    "left join tblexcel on replace(tbl07veri.odakarekod,' ',' ') = tblexcel.zkarekod+" +
                        //    "where len(tbl07veri.aktifetiket)<=2 and tbl07veri.createuser != 'TAMAM'";



                        //List<viewVeri> _Dizimtwo = (from _tbl07veriyedek in session.Query<tbl07veri>()
                        //                            where  _tbl07veriyedek.lastupdateuser.Equals("newentegrasyon") == false
                        //                            select new viewVeri()
                        //                         {
                        //                             zTabloId = _tbl07veriyedek.id,
                        //                             _date = _tbl07veriyedek.databasekayitzamani,
                        //                             zAktifNo = _tbl07veriyedek.aktifetiket,
                        //                             databasekayitzamani = "",
                        //                             zOdaBarkod = _tbl07veriyedek.odakarekod,
                        //                             zPasifEtiket = _tbl07veriyedek.pasifetiket,
                        //                             zSeriNo = _tbl07veriyedek.serino,
                        //                         }).Distinct().Take(sayi).ToList();
                        //_Cevap._zDizi = new List<viewVeri>();
                        //foreach (var _tbl07veriyedek in _Dizim)
                        //{
                        //    _Cevap._zDizi.Add(new viewVeri()
                        //    {
                        //        zTabloId = _tbl07veriyedek?.zTabloId,
                        //        _date = _tbl07veriyedek._date,
                        //        zAktifNo = _tbl07veriyedek?.zAktifNo,
                        //        databasekayitzamani = _tbl07veriyedek.databasekayitzamani,
                        //        zOdaBarkod = _tbl07veriyedek?.zOdaBarkod,
                        //        zPasifEtiket = _tbl07veriyedek?.zPasifEtiket,
                        //        zSeriNo = _tbl07veriyedek?.zSeriNo,
                        //        zUrunAdi = _tbl07veriyedek?.zUrunAdi,
                        //        zName = _tbl07veriyedek?.zName,
                        //        zSurname = _tbl07veriyedek?.zSurname
                        //    });
                        //}

                        //List<viewVeri> _Dizim = (from _tbl07veriyedek in session.Query<tbl07veri>()
                        //                         join _tbl06urunkodu in session.Query<tbl06urunkodu>() on _tbl07veriyedek.urunid equals _tbl06urunkodu.id
                        //                         where _tbl07veriyedek.aktifetiket.ToString().Length >= 2 && _tbl07veriyedek.createuser != "TAMAM"
                        //                         select new viewVeri()
                        //                         {
                        //                             zTabloId = _tbl07veriyedek.id,
                        //                             _date = _tbl07veriyedek.databasekayitzamani,
                        //                             zAktifNo = _tbl07veriyedek.aktifetiket,
                        //                             databasekayitzamani = _tbl07veriyedek.databasekayitzamani,
                        //                             zOdaBarkod = _tbl07veriyedek.odakarekod,
                        //                             zPasifEtiket = _tbl07veriyedek.pasifetiket,
                        //                             zSeriNo = _tbl07veriyedek.serino,
                        //                             zUrunAdi = _tbl06urunkodu.zurunadi
                        //                         }).Distinct().Take(5).ToList();
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
                                databasekayitzamani =item.databasekayitzamani,
                                zOdaBarkod = item.zOdaBarkod,
                                zPasifEtiket = item.zPasifEtiket,
                                zSeriNo = item.zSeriNo,
                                zUrunAdi = item.zUrunAdi,
                                zSurname =item.zSurname,
                                zName= item.zName
                                
                            });
                        }


                        List<tbl07veri> _Dizimtwo = session.Query<tbl07veri>().Where(w => w.lastupdateuser != "newentegrasyon" || w.lastupdateuser == null).Take(sayi).ToList();

                        
                        _Cevap._zDiziNew = new List<viewVeri>();

                        foreach (var _tbl07veriyedek in _Dizimtwo)
                        {
                            _Cevap._zDiziNew.Add(new viewVeri()
                            {
                                zTabloId = _tbl07veriyedek?.id,
                                _date = _tbl07veriyedek.databasekayitzamani,
                                zAktifNo = _tbl07veriyedek?.aktifetiket,
                                databasekayitzamani = _tbl07veriyedek.databasekayitzamani,
                                zOdaBarkod = _tbl07veriyedek?.odakarekod,
                                zPasifEtiket = _tbl07veriyedek?.pasifetiket,
                                zSeriNo = _tbl07veriyedek?.serino,
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

     

        }


    }
}