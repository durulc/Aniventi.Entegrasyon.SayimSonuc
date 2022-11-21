using Aniventi.Entegrasyon.SayimSonuc.dbIslem;
using Aniventi.Entegrasyon.SayimSonuc.Response;
using log4net;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace Aniventi.Entegrasyon.SayimSonuc
{
    class cIslemtblapp06
    {
        static ILog _LogDosyasi = LogManager.GetLogger(typeof(cIslemtblapp06));

        internal void fn_VeriCekYaz(object state)
        {
            #region Değişkenler
            string _ParametreJson = "";
            string _Sql = "";
            string _ServisAdres = "http://sistem1.raporuygulama.com/api/tblapp06veriler";

            NpgsqlCommand _Komut = new NpgsqlCommand();

            cVeriTabani _myIslem = new cVeriTabani();
            DataTable _dTable;
            int _iIdentityNumber =0;
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

                        tblapp06verilerresponse _Details = JsonConvert.DeserializeObject<tblapp06verilerresponse>(_strCevap);
                        if(_Details != null) { 
                        for (int _iSayac = 0; _iSayac < _Details._zDizi.Count; _iSayac++)
                        {
                            _Sql = "insert into tbl06urunkodu(id, createuser, lastupdateuser, aktif, databasekayitzamani, guncellemezamani, zurunadi, zetiketturu) " +
                                " values (@id, @createuser, @lastupdateuser, @aktif, @databasekayitzamani, @guncellemezamani, @zurunadi, @zetiketturu) ";

                            _Komut = new NpgsqlCommand(_Sql);
                            _Komut.Parameters.AddWithValue("@id", _Details._zDizi[_iSayac].zTabloId);
                            _Komut.Parameters.AddWithValue("@createuser", "entegrasyon");
                            _Komut.Parameters.AddWithValue("@lastupdateuser", "entegrasyon");
                            _Komut.Parameters.AddWithValue("@aktif", 1);
                            _Komut.Parameters.AddWithValue("@databasekayitzamani", DateTime.Now);
                            _Komut.Parameters.AddWithValue("@guncellemezamani", DateTime.Now);
                            _Komut.Parameters.AddWithValue("@zurunadi", _Details._zDizi[_iSayac].zurunadi);
                            _Komut.Parameters.AddWithValue("@zetiketturu", _Details._zDizi[_iSayac].zetiketturu);
                        
                            _myIslem = new cVeriTabani();
                            _myIslem._fnSqlCalistir(_Komut);

                            fn_Sil(_Details._zDizi[_iSayac].zTabloId);

                            _LogDosyasi.Error(_Details._zDizi[_iSayac].zTabloId);
                        }
                        }
                        else
                        {
                            _LogDosyasi.Error("Veri yok");

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
            string _ServisAdres = "http://sistem1.raporuygulama.com/api/tblapp06verilerSil";
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

        private string fn_MacToDeger(string aktifdeger)
        {
            char[] characters = aktifdeger.ToCharArray();
            string newchar = "";
            bool ilk = false;
            for (int i = 0; i < characters.Length; i++)
            {
                newchar += characters[i];
                if (i % 2 != 0 && i + 1 != characters.Length && ilk)
                {
                    newchar = newchar + ":";
                }
                if (i == 0) { ilk = true; }

            }
            return newchar;
        }
    }
}
