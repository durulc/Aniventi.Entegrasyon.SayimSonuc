using System;
using System.Collections.Generic;

namespace Aniventi.Entegrasyon.SayimSonuc.Response
{
    public class tblapp04verilerresponse 
    {
        public List<_Veri> _Dizi { get; set; }
    }

    public class _Veri
    {
        public string sayimserino { get; set; }
        public string epc { get; set; }
        public string sayimoda { get; set; }
        public string id { get; set; }
        public DateTime databasekayitzamani { get; set; }
    }
}
