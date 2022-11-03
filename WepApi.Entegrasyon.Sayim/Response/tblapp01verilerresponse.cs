using System;
using System.Collections.Generic;

namespace WepApi.Entegrasyon.Sayim.Response
{
    public class tblapp01verilerresponse : ortak_Response
    {
        public List<_Veri01> _Dizi { get; set; }
    }

    public class _Veri01
    {
        public string zsectorcode { get; set; }
        public string zfloorcode { get; set; }
        public string zroomcode { get; set; }
        public string karekod { get; set; }
        public string zblok { get; set; }
        public string zuruntip { get; set; }
        public string zmiktar { get; set; }
        public string zparcaliurun { get; set; }
        public string zparcasayisi { get; set; }

        public string zetiketturu { get; set; }
        public string zetikettipi { get; set; }
        public string zrfidno { get; set; }
        public string zmahaladi { get; set; }
        public string id { get; set; }

        public DateTime databasekayitzamani { get; set; }
    }
}