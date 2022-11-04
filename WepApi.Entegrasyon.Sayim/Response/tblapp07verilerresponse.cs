using System;
using System.Collections.Generic;

namespace WepApi.Entegrasyon.Sayim.Response
{
    public class tblapp07verilerresponse : ortak_Response
    {
        public List<viewVeri> _zDizi { get; set; }

    }
    public class viewVeri
    {
        public string zTabloId { get; set; }
        public string zOdaBarkod { get; set; }
        public string zUrunAdi { get; set; }

        public string zPasifEtiket { get; set; }
        public string zAktifNo { get; set; }
        public string zSeriNo { get; set; }
        public string databasekayitzamani { get; set; }
        public DateTime _date { get; set; }
    }
}