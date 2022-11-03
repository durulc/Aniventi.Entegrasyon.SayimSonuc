using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;

namespace Aniventi.Entegtasyon.Entity.EntityFramework
{
    [Persistent("tblapp04")]
    public class tblapp04 : TabloObject
    {
        public tblapp04(Session session) : base(session) { }

        string _sayimserino = "";
        [Persistent("sayimserino ")]
        [Size(100)]
        public string sayimserino
        {
            get { return _sayimserino; }
            set { SetPropertyValue<string>("sayimserino ", ref _sayimserino, value); }
        }

        string _epc = "";
        [Persistent("epc")]
        [Size(100)]
        public string epc
        {
            get { return _epc; }
            set { SetPropertyValue<string>("epc", ref _epc, value); }
        }

        string _sayimoda = "";
        [Persistent("sayimoda")]
        [Size(100)]
        public string sayimoda
        {
            get { return _sayimoda; }
            set { SetPropertyValue<string>("sayimoda", ref _sayimoda, value); }
        }

    }
}
