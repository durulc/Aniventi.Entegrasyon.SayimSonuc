using DevExpress.Xpo;
using System;
using System.Collections.Generic;

namespace WepApi.Entegrasyon.Sayim.Response
{
    public class tblapp06verilerresponse : ortak_Response
    {
        public List<viewVeri6> _zDizi { get; set; }

    }


    public class viewVeri6
    {
        public string zTabloId { get; set; }
        public string zetiketturu { get; set; }
        public string zurunadi { get; set; }
        public DateTime databasekayitzamani { get; set; }
    }
}