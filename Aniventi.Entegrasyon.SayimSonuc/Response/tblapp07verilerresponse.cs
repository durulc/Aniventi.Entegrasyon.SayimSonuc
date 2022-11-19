using System;
using System.Collections.Generic;

namespace Aniventi.Entegrasyon.SayimSonuc.Response
{
    public class tblapp07verilerresponse
    {
        public List<viewVeri> _zDizi { get; set; }
        public List<viewVeri> _zDiziNew { get; set; }
    }
    public class viewVeri
    {
        public string zTabloId { get; set; }
        public string zOdaBarkod { get; set; }
        public string zUrunAdi { get; set; }
        public string zName { get; set; }
        public string zSurname { get; set; }
        public string zPasifEtiket { get; set; }
        public string zAktifNo { get; set; }
        public string zSeriNo { get; set; }
        public string databasekayitzamani { get; set; }
        public DateTime _date { get; set; }
    }
}
