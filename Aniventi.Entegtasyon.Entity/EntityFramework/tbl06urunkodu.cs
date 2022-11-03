using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;

namespace Aniventi.Entegtasyon.Entity.EntityFramework
{
    [Persistent("tbl06urunkodu")]
    public class tbl06urunkodu : TabloObject
    {
        public tbl06urunkodu(Session session) : base(session) { }

        string _12urunadi = "";
        [Persistent("zurunadi")]
        [Size(1000)]
        public string zurunadi
        {
            get { return _12urunadi; }
            set { SetPropertyValue<string>("zurunadi", ref _12urunadi, value); }
        }

        string _zetiketturu = "";
        [Persistent("zetiketturu")]
        [Size(1000)]
        public string zetiketturu
        {
            get { return _zetiketturu; }
            set { SetPropertyValue<string>("zetiketturu", ref _zetiketturu, value); }
        }


        //zetiketturu
    }
}
