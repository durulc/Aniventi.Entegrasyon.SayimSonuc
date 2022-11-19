using Aniventi.Entegtasyon.Entity.Important;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.Entegtasyon.Entity.EntityFramework
{
    [Persistent("tblexcel")]
    public class tblexcel : TabloObject
    {
        public tblexcel(Session session) : base(session) { }

        int _01sira = 0;
        [Persistent("zsira")]
        public int zsira
        {
            get { return _01sira; }
            set { SetPropertyValue<int>("zsira", ref _01sira, value); }
        }

        string _02ekipmanid = "";
        [Persistent("zekipmanid")]
        [Size(1000)]
        public string zekipmanid
        {
            get { return _02ekipmanid; }
            set { SetPropertyValue<string>("zekipmanid", ref _02ekipmanid, value); }
        }

        string _03mahalid = "";
        [Persistent("zmahalid")]
        [Size(1000)]
        public string zmahalid
        {
            get { return _03mahalid; }
            set { SetPropertyValue<string>("zmahalid", ref _03mahalid, value); }
        }

        string _04ekipman = "";
        [Persistent("zekipman")]
        [Size(1000)]
        public string zekipman
        {
            get { return _04ekipman; }
            set { SetPropertyValue<string>("zekipman", ref _04ekipman, value); }
        }

        string _05mob_liste = "";
        [Persistent("zmob_liste")]
        [Size(1000)]
        public string zmob_liste
        {
            get { return _05mob_liste; }
            set { SetPropertyValue<string>("zmob_liste", ref _05mob_liste, value); }
        }

        string _06sectorcode = "";
        [Persistent("zsectorcode")]
        [Size(1000)]
        public string zsectorcode
        {
            get { return _06sectorcode; }
            set { SetPropertyValue<string>("zsectorcode", ref _06sectorcode, value); }
        }

        string _07floorcode = "";
        [Persistent("zfloorcode")]
        [Size(1000)]
        public string zfloorcode
        {
            get { return _07floorcode; }
            set { SetPropertyValue<string>("zfloorcode", ref _07floorcode, value); }
        }

        string _08departmancode = "";
        [Persistent("zdepartmancode")]
        [Size(1000)]
        public string zdepartmancode
        {
            get { return _08departmancode; }
            set { SetPropertyValue<string>("zdepartmancode", ref _08departmancode, value); }
        }

        string _09roomcode = "";
        [Persistent("zroomcode")]
        [Size(1000)]
        public string zroomcode
        {
            get { return _09roomcode; }
            set { SetPropertyValue<string>("zroomcode", ref _09roomcode, value); }
        }

        string _10karekod = "";
        [Persistent("zkarekod")]
        [Size(100)]
        public string zkarekod
        {
            get { return _10karekod; }
            set { SetPropertyValue<string>("zkarekod", ref _10karekod, value); }
        }

        string _11blok = "";
        [Persistent("zblok")]
        [Size(1000)]
        public string zblok
        {
            get { return _11blok; }
            set { SetPropertyValue<string>("zblok", ref _11blok, value); }
        }

        string _12urunadi = "";
        [Persistent("zurunadi")]
        [Size(1000)]
        public string zurunadi
        {
            get { return _12urunadi; }
            set { SetPropertyValue<string>("zurunadi", ref _12urunadi, value); }
        }

        string _13uruntip = "";
        [Persistent("zuruntip")]
        [Size(1000)]
        public string zuruntip
        {
            get { return _13uruntip; }
            set { SetPropertyValue<string>("zuruntip", ref _13uruntip, value); }
        }

        string _14miktar = "";
        [Persistent("zmiktar")]
        [Size(1000)]
        public string zmiktar
        {
            get { return _14miktar; }
            set { SetPropertyValue<string>("zmiktar", ref _14miktar, value); }
        }

        string _15ek13no = "";
        [Persistent("zek13no")]
        [Size(1000)]
        public string zek13no
        {
            get { return _15ek13no; }
            set { SetPropertyValue<string>("zek13no", ref _15ek13no, value); }
        }

        string _16tefriskodu = "";
        [Persistent("ztefriskodu")]
        [Size(1000)]
        public string ztefriskodu
        {
            get { return _16tefriskodu; }
            set { SetPropertyValue<string>("ztefriskodu", ref _16tefriskodu, value); }
        }

        string _17parcaliurun = "";
        [Persistent("zparcaliurun")]
        [Size(1000)]
        public string zparcaliurun
        {
            get { return _17parcaliurun; }
            set { SetPropertyValue<string>("zparcaliurun", ref _17parcaliurun, value); }
        }

        string _18parcasayisi = "";
        [Persistent("zparcasayisi")]
        [Size(1000)]
        public string zparcasayisi
        {
            get { return _18parcasayisi; }
            set { SetPropertyValue<string>("zparcasayisi", ref _18parcasayisi, value); }
        }

        string _19etiketturu = "";
        [Persistent("zetiketturu")]
        [Size(1000)]
        public string zetiketturu
        {
            get { return _19etiketturu; }
            set { SetPropertyValue<string>("zetiketturu", ref _19etiketturu, value); }
        }

        string _20etikettipi = "";
        [Persistent("zetikettipi")]
        [Size(1000)]
        public string zetikettipi
        {
            get { return _20etikettipi; }
            set { SetPropertyValue<string>("zetikettipi", ref _20etikettipi, value); }
        }

        string _21rfidno = "";
        [Persistent("zrfidno")]
        [Size(24)]
        public string zrfidno
        {
            get { return _21rfidno; }
            set { SetPropertyValue<string>("zrfidno", ref _21rfidno, value); }
        }

        int _22basilmsayisi = 0;
        [Persistent("zbasilmasayisi")]
        public int zbasilmasayisi
        {
            get { return _22basilmsayisi; }
            set { SetPropertyValue<int>("zbasilmasayisi", ref _22basilmsayisi, value); }
        }

        int _23yapistirmadurumu = 0;
        [Persistent("yapistirmadurumu")]
        public int yapistirmadurumu
        {
            get { return _23yapistirmadurumu; }
            set { SetPropertyValue<int>("yapistirmadurumu", ref _23yapistirmadurumu, value); }
        }

        string _24yapistirmaaciklama = "";
        [Persistent("yapistirmaaciklama")]
        [Size(100)]
        public string yapistirmaaciklama
        {
            get { return _24yapistirmaaciklama; }
            set { SetPropertyValue<string>("yapistirmaaciklama", ref _24yapistirmaaciklama, value); }
        }


        int _25yapistirmaaciklamadurumu = 0;
        [Persistent("yapistirmaaciklamadurumu")]
        public int yapistirmaaciklamadurumu
        {
            get { return _25yapistirmaaciklamadurumu; }
            set { SetPropertyValue<int>("yapistirmaaciklamadurumu", ref _25yapistirmaaciklamadurumu, value); }
        }


        int _etiketsira = 0;
        [Persistent("etiketsira")]
        public int etiketsira
        {
            get { return _etiketsira; }
            set { SetPropertyValue<int>("etiketsira", ref _etiketsira, value); }
        }
    }
}