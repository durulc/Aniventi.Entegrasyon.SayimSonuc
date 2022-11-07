using Aniventi.Entegrasyon.SayimSonuc.dbIslem;
using Aniventi.Entegrasyon.SayimSonuc.Response;
using log4net;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Aniventi.Entegrasyon.SayimSonuc
{
    class cIslemtblapp04
    {
        static ILog _LogDosyasi = LogManager.GetLogger(typeof(cIslemtblapp04));

        internal void fn_VeriCekYaz(object state)
        {
            #region Değişkenler
            string _ParametreJson = "";
            string _Sql = "";
            string _ServisAdres = "http://sistem1.raporuygulama.com/api/tblapp04veriler";

            NpgsqlCommand _Komut = new NpgsqlCommand();

            cVeriTabani _myIslem = new cVeriTabani();
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

                        tblapp04verilerresponse _Details = JsonConvert.DeserializeObject<tblapp04verilerresponse>(_strCevap);

                        for (int _iSayac = 0; _iSayac < _Details._Dizi.Count; _iSayac++)
                        {
                            _Sql = "insert into tblapp04(id, createuser, lastupdateuser, aktif, databasekayitzamani, guncellemezamani, \"sayimserino_C4EE00F3\", epc, sayimoda, sayimserino) "+
                                " values (@id, @createuser, @lastupdateuser, @aktif, @databasekayitzamani, @guncellemezamani, @sayimserino1, @epc, @sayimoda, @sayimserino2) ";

                            _Komut = new NpgsqlCommand(_Sql);
                            _Komut.Parameters.AddWithValue("@id", _Details._Dizi[_iSayac].id);
                            _Komut.Parameters.AddWithValue("@createuser", "entegrasyon");
                            _Komut.Parameters.AddWithValue("@lastupdateuser", "entegrasyon");
                            _Komut.Parameters.AddWithValue("@aktif", 1);
                            _Komut.Parameters.AddWithValue("@databasekayitzamani", _Details._Dizi[_iSayac].databasekayitzamani);
                            _Komut.Parameters.AddWithValue("@guncellemezamani", _Details._Dizi[_iSayac].databasekayitzamani);
                            _Komut.Parameters.AddWithValue("@sayimserino1", _Details._Dizi[_iSayac].sayimserino);
                            _Komut.Parameters.AddWithValue("@epc", _Details._Dizi[_iSayac].epc);
                            _Komut.Parameters.AddWithValue("@sayimoda", _Details._Dizi[_iSayac].sayimoda);
                            _Komut.Parameters.AddWithValue("@sayimserino2", _Details._Dizi[_iSayac].sayimserino);

                            _myIslem = new cVeriTabani();
                            _myIslem._fnSqlCalistir(_Komut);

                            fn_Sil(_Details._Dizi[_iSayac].id);

                            _LogDosyasi.Error(_Details._Dizi[_iSayac].id);
                        }
                    }
                        Thread.Sleep(TimeSpan.FromMinutes(1));
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
            string _ServisAdres = "http://sistem1.raporuygulama.com/api/tblapp04verilerSil";
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
