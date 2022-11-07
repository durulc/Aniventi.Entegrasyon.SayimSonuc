using Aniventi.Entegrasyon.SayimSonuc.dbIslem;
using Aniventi.Entegrasyon.SayimSonuc.Response;
using log4net;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Threading;

namespace Aniventi.Entegrasyon.SayimSonuc
{
    class cIslemtblapp01
    {
        static ILog _LogDosyasi = LogManager.GetLogger(typeof(cIslemtblapp01));

        internal void fn_VeriCekYaz(object state)
        {
            #region Değişkenler
            string _ParametreJson = "";
            string _Sql = "";
            string _ServisAdres = "http://sistem1.raporuygulama.com/api/tblapp01veriler";

            NpgsqlCommand _Komut = new NpgsqlCommand();

            cVeriTabani _myIslem = new cVeriTabani();

            DataTable _dTable = new DataTable();
            #endregion

            try
            {
                while(true)
                {
                    _ParametreJson = "";
                    _ParametreJson += "{\"zKullaniciAdi\":\"Aa1234--\",\"zSifre\":\"Aa1234.\"}";

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(_ServisAdres);

                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(_ParametreJson);

                        streamWriter.Flush();

                        streamWriter.Close();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string _strCevap = streamReader.ReadToEnd();

                        tblapp01verilerresponse _Details = JsonConvert.DeserializeObject<tblapp01verilerresponse>(_strCevap);

                        for (int _iSayac = 0; _iSayac < _Details._Dizi.Count; _iSayac++)
                        {

                            _Sql = "select id from tblapp01 where id = @id";
                            _Komut = new NpgsqlCommand(_Sql);
                            _Komut.Parameters.Clear();
                            _Komut.Parameters.AddWithValue("@id", _Details._Dizi[_iSayac].id);

                            _myIslem = new cVeriTabani();
                            _dTable = new DataTable();
                            _dTable = _myIslem._fnDataTable(_Komut);

                            if (_dTable.Rows.Count > 0)
                            {
                                fn_Sil(_Details._Dizi[_iSayac].id);

                                _LogDosyasi.Error("Tekrar eden kayıt bulundu :" + _Details._Dizi[_iSayac].id);
                            }
                            else
                            {


                                _Sql = "insert into tblapp01(id, createuser, lastupdateuser, aktif, databasekayitzamani, guncellemezamani, zsectorcode, zfloorcode, zroomcode, karekod, zblok, zuruntip, zmiktar, zparcaliurun, zparcasayisi, zetiketturu, zetikettipi, zrfidno, zmahaladi) " +
                                    " values (@id, @createuser, @lastupdateuser, @aktif, @databasekayitzamani, @guncellemezamani, @zsectorcode, @zfloorcode, @zroomcode, @karekod, @zblok, @zuruntip, @zmiktar, @zparcaliurun, @zparcasayisi, @zetiketturu, @zetikettipi, @zrfidno, @zmahaladi) ";

                                _Komut = new NpgsqlCommand(_Sql);
                                _Komut.Parameters.AddWithValue("@id", _Details._Dizi[_iSayac].id);
                                _Komut.Parameters.AddWithValue("@createuser", "entegrasyon");
                                _Komut.Parameters.AddWithValue("@lastupdateuser", "entegrasyon");
                                _Komut.Parameters.AddWithValue("@aktif", 1);
                                _Komut.Parameters.AddWithValue("@databasekayitzamani", _Details._Dizi[_iSayac].databasekayitzamani);
                                _Komut.Parameters.AddWithValue("@guncellemezamani", _Details._Dizi[_iSayac].databasekayitzamani);
                                _Komut.Parameters.AddWithValue("@zsectorcode", _Details._Dizi[_iSayac].zsectorcode);
                                _Komut.Parameters.AddWithValue("@zfloorcode", _Details._Dizi[_iSayac].zfloorcode);
                                _Komut.Parameters.AddWithValue("@zroomcode", _Details._Dizi[_iSayac].zroomcode);
                                _Komut.Parameters.AddWithValue("@karekod", _Details._Dizi[_iSayac].karekod);
                                _Komut.Parameters.AddWithValue("@zblok", _Details._Dizi[_iSayac].zblok);
                                _Komut.Parameters.AddWithValue("@zuruntip", _Details._Dizi[_iSayac].zuruntip);
                                _Komut.Parameters.AddWithValue("@zmiktar", _Details._Dizi[_iSayac].zmiktar);
                                _Komut.Parameters.AddWithValue("@zparcaliurun", _Details._Dizi[_iSayac].zparcaliurun);
                                _Komut.Parameters.AddWithValue("@zparcasayisi", _Details._Dizi[_iSayac].zparcasayisi);
                                _Komut.Parameters.AddWithValue("@zetiketturu", _Details._Dizi[_iSayac].zetiketturu);
                                _Komut.Parameters.AddWithValue("@zetikettipi", _Details._Dizi[_iSayac].zetikettipi);
                                _Komut.Parameters.AddWithValue("@zrfidno", _Details._Dizi[_iSayac].zrfidno);
                                _Komut.Parameters.AddWithValue("@zmahaladi", _Details._Dizi[_iSayac].zmahaladi);

                                _myIslem = new cVeriTabani();
                                _myIslem._fnSqlCalistir(_Komut);

                                fn_Sil(_Details._Dizi[_iSayac].id);

                                _LogDosyasi.Error("Aktarılan Tablo Id :" + _Details._Dizi[_iSayac].id);
                            }
                        }
                    }
                        Thread.Sleep(TimeSpan.FromMinutes(5));
                }
            }
            catch (Exception ex)
            {
                _LogDosyasi.Error(ex.ToString());
            }
        }
        private void fn_Sil(string v_id)
        {

            #region Değişkenler
            string _ParametreJson = "";
            string _Sql = "";
            string _ServisAdres = "http://sistem1.raporuygulama.com/api/tblapp01verilerSil";
            #endregion


            _ParametreJson = "";
            _ParametreJson += "{\"zKullaniciAdi\":\"Aa1234--\",\"zSifre\":\"Aa1234.\",\"zTablodId\":\"" + v_id + "\"}";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_ServisAdres);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(_ParametreJson);

                streamWriter.Flush();

                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string _strCevap = streamReader.ReadToEnd();
            }
        }
    }
}
