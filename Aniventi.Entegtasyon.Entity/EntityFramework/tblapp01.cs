using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;

namespace Aniventi.Entegtasyon.Entity.EntityFramework
{
    [Persistent("tblapp01")]
    public class tblapp01 : TabloObject
    {
        public tblapp01(Session session) : base(session) { }

        string _zsectorcode = "";
        [Persistent("zsectorcode")]
        [Size(100)]
        public string zsectorcode
        {
            get { return _zsectorcode; }
            set { SetPropertyValue<string>("zsectorcode", ref _zsectorcode, value); }
        }

        string _zfloorcode = "";
        [Persistent("zfloorcode")]
        [Size(100)]
        public string zfloorcode
        {
            get { return _zfloorcode; }
            set { SetPropertyValue<string>("zfloorcode", ref _zfloorcode, value); }
        }

        string _zroomcode = "";
        [Persistent("zroomcode")]
        [Size(100)]
        public string zroomcode
        {
            get { return _zroomcode; }
            set { SetPropertyValue<string>("zroomcode", ref _zroomcode, value); }
        }

        string _karekod = "";
        [Persistent("karekod")]
        [Size(100)]
        public string karekod
        {
            get { return _karekod; }
            set { SetPropertyValue<string>("karekod", ref _karekod, value); }
        }

        string _zblok = "";
        [Persistent("zblok")]
        [Size(100)]
        public string zblok
        {
            get { return _zblok; }
            set { SetPropertyValue<string>("zblok", ref _zblok, value); }
        }

        string _zuruntip = "";
        [Persistent("zuruntip")]
        [Size(100)]
        public string zuruntip
        {
            get { return _zuruntip; }
            set { SetPropertyValue<string>("zuruntip", ref _zuruntip, value); }
        }

        string _zmiktar = "";
        [Persistent("zmiktar")]
        [Size(100)]
        public string zmiktar
        {
            get { return _zmiktar; }
            set { SetPropertyValue<string>("zmiktar", ref _zmiktar, value); }
        }

        string _zparcaliurun = "";
        [Persistent("zparcaliurun")]
        [Size(100)]
        public string zparcaliurun
        {
            get { return _zparcaliurun; }
            set { SetPropertyValue<string>("zparcaliurun", ref _zparcaliurun, value); }
        }

        string _zparcasayisi = "";
        [Persistent("zparcasayisi")]
        [Size(100)]
        public string zparcasayisi
        {
            get { return _zparcasayisi; }
            set { SetPropertyValue<string>("zparcasayisi", ref _zparcasayisi, value); }
        }

        string _zetiketturu = "";
        [Persistent("zetiketturu")]
        [Size(100)]
        public string zetiketturu
        {
            get { return _zetiketturu; }
            set { SetPropertyValue<string>("zetiketturu", ref _zetiketturu, value); }
        }

        string _zetikettipi = "";
        [Persistent("zetikettipi")]
        [Size(100)]
        public string zetikettipi
        {
            get { return _zetikettipi; }
            set { SetPropertyValue<string>("zetikettipi", ref _zetikettipi, value); }
        }

        string _zrfidno = "";
        [Persistent("zrfidno")]
        [Size(100)]
        public string zrfidno
        {
            get { return _zrfidno; }
            set { SetPropertyValue<string>("zrfidno", ref _zrfidno, value); }
        }

        string _zmahaladi = "";
        [Persistent("zmahaladi")]
        [Size(100)]
        public string zmahaladi
        {
            get { return _zmahaladi; }
            set { SetPropertyValue<string>("zmahaladi", ref _zmahaladi, value); }
        }

    }
}
