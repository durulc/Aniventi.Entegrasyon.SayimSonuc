using System;
using System.Collections.Generic;

namespace Aniventi.Entegrasyon.SayimSonuc.Response
{
    public class tblapp06verilerresponse
    {
        public List<viewVeri06> _Dizi { get; set; }

    }
    public class viewVeri06
    {
        public string zTabloId { get; set; }
        public string zetiketturu { get; set; }
        public string zurunadi { get; set; }
        public string databasekayitzamani { get; set; }
    }
}
