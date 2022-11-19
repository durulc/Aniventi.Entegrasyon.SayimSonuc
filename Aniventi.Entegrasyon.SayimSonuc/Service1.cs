
using log4net;
using System.ServiceProcess;
using System.Threading;

namespace Aniventi.Entegrasyon.SayimSonuc
{
    public partial class Service1 : ServiceBase
    {
        static ILog _LogDosyasi = LogManager.GetLogger(typeof(Service1));

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _LogDosyasi.Info("Servis Başladı");

            ThreadPool.QueueUserWorkItem(new cIslemtblapp04().fn_VeriCekYaz);
            ThreadPool.QueueUserWorkItem(new cIslemtblapp01().fn_VeriCekYaz);
            ThreadPool.QueueUserWorkItem(new cIslemtblapp07().fn_VeriCekYaz);
            ThreadPool.QueueUserWorkItem(new cIslemtblapp06().fn_VeriCekYaz);

        }

        protected override void OnStop()
        {
        }
    }
}
