using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System.Configuration;
using System.Reflection;

namespace Aniventi.Entegtasyon.Entity.Important
{
    public class XpoManager : Singleton<XpoManager>
    {

        public static string _connectionString = "";

        private XpoManager() { }

        public void InitXpo()
        {
            string Server = ConfigurationManager.AppSettings["BaglantiSunucuIp"].ToString().Trim();
            string UserID = ConfigurationManager.AppSettings["BaglantiKullaniciAdi"].ToString().Trim();
            string Database = ConfigurationManager.AppSettings["BaglantiDatabase"].ToString().Trim();
            string Sifre = ConfigurationManager.AppSettings["BaglantiSifre"].ToString().Trim();

            _connectionString = "Data Source=" + Server + ";Initial Catalog = " + Database + "; User ID = " + UserID + "; Password = " + Sifre;

            UpdateDatabase();
        }


        public Session GetNewSession()
        {
            string Server = ConfigurationManager.AppSettings["BaglantiSunucuIp"].ToString().Trim();
            string UserID = ConfigurationManager.AppSettings["BaglantiKullaniciAdi"].ToString().Trim();
            string Database = ConfigurationManager.AppSettings["BaglantiDatabase"].ToString().Trim();
            string Sifre = ConfigurationManager.AppSettings["BaglantiSifre"].ToString().Trim();

            _connectionString = "Data Source=" + Server + ";Initial Catalog = " + Database + "; User ID = " + UserID + "; Password = " + Sifre;



            return new Session(DataLayer);
        }

        private readonly object _lockObject = new object();

        volatile IDataLayer _fDataLayer;

        public UnitOfWork GetNewUnitOfWork()
        {
            return new UnitOfWork(DataLayer);
        }


        IDataLayer DataLayer
        {
            get
            {
                if (_fDataLayer == null)
                {
                    lock (_lockObject)
                    {
                        if (_fDataLayer == null)
                        {
                            _fDataLayer = GetDataLayer();
                        }
                    }
                }
                return _fDataLayer;
            }
        }

        private IDataLayer GetDataLayer()
        {


            XpoDefault.Session = null;
            XPDictionary dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(Assembly.GetExecutingAssembly());
            IDataStore store = XpoDefault.GetConnectionProvider(_connectionString, AutoCreateOption.DatabaseAndSchema);
            return new ThreadSafeDataLayer(dict, store);
        }

        private static void UpdateDatabase()
        {
            using (IDataLayer dal = XpoDefault.GetDataLayer(_connectionString, AutoCreateOption.DatabaseAndSchema))
            {
                using (Session session = new Session(dal))
                {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    session.UpdateSchema(asm);
                    session.CreateObjectTypeRecords(asm);
                }
            }
        }
    }
}
