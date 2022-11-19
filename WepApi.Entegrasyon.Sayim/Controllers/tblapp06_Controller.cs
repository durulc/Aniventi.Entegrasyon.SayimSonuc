using System.Web.Http;
using WepApi.Entegrasyon.Sayim.Manager;
using WepApi.Entegrasyon.Sayim.Request;
using WepApi.Entegrasyon.Sayim.Response;

namespace WepApi.Entegrasyon.Sayim.Controllers
{
    public class tblapp06_Controller : ApiController
    {
        [HttpPost]
        [Route("api/tblapp06veriler")]
        public tblapp06verilerresponse tblapp06veriler(tblapp06verilerrequest v_Gelen)
        {
            return new tblapp06_Manager().fn_tblapp06veriler(v_Gelen);
        }

        [HttpPost]
        [Route("api/tblapp06verilerSil")]
        public tblapp06verilerSilresponse tblapp06verilerSil(tblapp06verilerSilrequest v_Gelen)
        {
            return new tblapp06_Manager().fn_tblapp06verilerSil(v_Gelen);
        }
      
    }
}
