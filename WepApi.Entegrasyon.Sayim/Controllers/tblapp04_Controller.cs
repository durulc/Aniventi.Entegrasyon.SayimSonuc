using System.Web.Http;
using WepApi.Entegrasyon.Sayim.Manager;
using WepApi.Entegrasyon.Sayim.Request;
using WepApi.Entegrasyon.Sayim.Response;

namespace WepApi.Entegrasyon.Sayim.Controllers
{
    public class tblapp04_Controller : ApiController
    {
        [HttpPost]
        [Route("api/tblapp04veriler")]
        public tblapp04verilerresponse tblapp04veriler(tblapp04verilerrequest v_Gelen)
        {
            return new tblapp04_Manager().fn_tblapp04veriler(v_Gelen);
        }
    }
}
