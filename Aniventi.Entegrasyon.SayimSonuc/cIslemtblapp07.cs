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
    class cIslemtblapp07
    {
        static ILog _LogDosyasi = LogManager.GetLogger(typeof(cIslemtblapp07));

        internal void fn_VeriCekYaz(object state)
        {
            #region Değişkenler
            string _ParametreJson = "";
            string _Sql = "";
            string _ServisAdres = "http://sistem1.raporuygulama.com/api/tblapp07veriler";

            NpgsqlCommand _Komut = new NpgsqlCommand();

            cVeriTabani _myIslem = new cVeriTabani();
            DataTable _dTable;
            int _iIdentityNumber = 0;
            #endregion

            try
            {
                while (true)
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

                        tblapp07verilerresponse _Details = JsonConvert.DeserializeObject<tblapp07verilerresponse>(_strCevap);

                        foreach (var item in _Details._zDizi)
                        {
                            #region Tag Id Al
                            _Sql = "SELECT \"IdentityNumber\" FROM \"Person\" WHERE \"Oid\" != 1 and  CAST(\"IdentityNumber\" AS INTEGER) = (SELECT MAX( CAST(\"IdentityNumber\" AS INTEGER)) FROM \"Person\" where \"Oid\" != 1)";

                            _Komut = new NpgsqlCommand(_Sql);

                            _myIslem = new cVeriTabani();

                            _dTable = new DataTable();
                            _dTable = _myIslem._fnDataTable(_Komut);

                            if (_dTable.Rows.Count > 0)
                            {
                                _iIdentityNumber = int.Parse(_dTable.Rows[0][0].ToString()) + 1;
                            }
                            #endregion

                            #region Eski kaydı sil
                            string _KullaniciTip = fn_MacToDeger(item.zAktifNo);
                            _Sql = "delete from \"Person\" where kullanicitip ='" + _KullaniciTip + "' ";

                            _Komut = new NpgsqlCommand(_Sql);

                            _myIslem = new cVeriTabani();
                            _myIslem._fnSqlCalistir(_Komut);

                            #endregion

                            #region Yeni Kayıt
                            _Sql = "INSERT INTO \"Person\"(\"CreateDate\", \"IdentityNumber\", \"Name\", \"SurName\", email, ldapusername, \"TagId\",kullanicitip) VALUES (NOW(), @IdentityNumber, @Name, @SurName, @email, @ldapusername, @TagId,@kullanicitip)";

                            _Komut = new NpgsqlCommand(_Sql);
                            _Komut.Parameters.Clear();
                            _Komut.Parameters.AddWithValue("@IdentityNumber", _iIdentityNumber);
                            _Komut.Parameters.AddWithValue("@Name", item.zName);
                            _Komut.Parameters.AddWithValue("@SurName", item.zSurname);
                            _Komut.Parameters.AddWithValue("@email", item.zUrunAdi);
                            _Komut.Parameters.AddWithValue("@ldapusername", "1");
                            _Komut.Parameters.AddWithValue("@kullanicitip", _KullaniciTip);
                            _Komut.Parameters.AddWithValue("@TagId", _iIdentityNumber);

                            _myIslem = new cVeriTabani();
                            _myIslem._fnSqlCalistir(_Komut);

                            #endregion


                            fn_Sil(item.zTabloId);

                            _LogDosyasi.Error(item.zTabloId);


                        }



                        #region _tbl07 yeni kayıt
                        foreach (var item in _Details._zDiziNew)
                        {
                            _Sql = "select id from tbl07veri where id = @id";
                            _Komut = new NpgsqlCommand(_Sql);
                            _Komut.Parameters.Clear();
                            _Komut.Parameters.AddWithValue("@id", item.zTabloId);

                            _myIslem = new cVeriTabani();
                            _dTable = new DataTable();
                            _dTable = _myIslem._fnDataTable(_Komut);

                            if (_dTable.Rows.Count > 0)
                            {
                                fn_Sil(item.zTabloId);

                                _LogDosyasi.Error("Tekrar eden kayıt bulundu :" + item.zTabloId);
                            }
                            else
                            {
                                _Sql = "insert into tbl07veri(id, createuser, lastupdateuser, aktif, databasekayitzamani, guncellemezamani, odakarekod, urunid, pasifetiket, aktifetiket, serino) " +
                           " values (@id, @createuser, @lastupdateuser, @aktif, @databasekayitzamani, @guncellemezamani, @odakarekod, @urunid, @pasifetiket, @aktifetiket,@serino) ";
                                _Komut = new NpgsqlCommand(_Sql);
                                _Komut.Parameters.Clear();
                                _Komut.Parameters.AddWithValue("@id", item.zTabloId);
                                _Komut.Parameters.AddWithValue("@createuser", "entegrasyon");
                                _Komut.Parameters.AddWithValue("@lastupdateuser", "entegrasyon");
                                _Komut.Parameters.AddWithValue("@aktif", 1);
                                _Komut.Parameters.AddWithValue("@databasekayitzamani", item.databasekayitzamani);
                                _Komut.Parameters.AddWithValue("@guncellemezamani", item.databasekayitzamani);
                                _Komut.Parameters.AddWithValue("@odakarekod", item.zOdaBarkod);
                                _Komut.Parameters.AddWithValue("@urunid", item.zUrunAdi);
                                _Komut.Parameters.AddWithValue("@pasifetiket", item.zPasifEtiket);
                                _Komut.Parameters.AddWithValue("@aktifetiket", item.zAktifNo);
                                _Komut.Parameters.AddWithValue("@serino", item.zSeriNo);
                                _myIslem = new cVeriTabani();
                                _myIslem._fnSqlCalistir(_Komut);
                                _LogDosyasi.Error("Tbl07 yeni tablo eklmesi çalıştı" + item.zTabloId);
                            }
                        }
                        #endregion}
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
            string _ServisAdres = "http://sistem1.raporuygulama.com/api/tblapp07verilerSil";
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
