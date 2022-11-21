using System;
using System.Collections.Generic;

namespace Aniventi.Entegrasyon.SayimSonuc.Response
{
    public class tblapp06verilerresponse
    {
        public List<viewVeri06> _zDizi { get; set; }

    }
    public class viewVeri06
    {
        public string zTabloId { get; set; }
        public string zetiketturu { get; set; }
        public string zurunadi { get; set; }
        public DateTime databasekayitzamani { get; set; }
    }
}
