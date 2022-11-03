using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;

namespace Aniventi.Entegtasyon.Entity.EntityFramework
{
    [Persistent("tbl07veri")]
    public class tbl07veri : TabloObject
    {
        public tbl07veri(Session session) : base(session) { }

        string _odakarekod = "";
        [Persistent("odakarekod")]
        [Size(1000)]
        public string odakarekod
        {
            get { return _odakarekod; }
            set { SetPropertyValue<string>("odakarekod", ref _odakarekod, value); }
        }

        string _urunid = "";
        [Persistent("urunid")]
        [Size(1000)]
        public string urunid
        {
            get { return _urunid; }
            set { SetPropertyValue<string>("urunid", ref _urunid, value); }
        }

        string _pasifetiket = "";
        [Persistent("pasifetiket")]
        [Size(1000)]
        public string pasifetiket
        {
            get { return _pasifetiket; }
            set { SetPropertyValue<string>("pasifetiket", ref _pasifetiket, value); }
        }

        string _aktifetiket = "";
        [Persistent("aktifetiket")]
        [Size(1000)]
        public string aktifetiket
        {
            get { return _aktifetiket; }
            set { SetPropertyValue<string>("aktifetiket", ref _aktifetiket, value); }
        }

        string _serino = "";
        [Persistent("serino")]
        [Size(1000)]
        public string serino
        {
            get { return _serino; }
            set { SetPropertyValue<string>("serino", ref _serino, value); }
        }
    }
}
