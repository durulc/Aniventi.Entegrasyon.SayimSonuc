using System.Web.Http;
using WepApi.Entegrasyon.Sayim.Manager;
using WepApi.Entegrasyon.Sayim.Request;
using WepApi.Entegrasyon.Sayim.Response;

namespace WepApi.Entegrasyon.Sayim.Controllers
{
    public class tblapp07_Controller : ApiController
    {
        [HttpPost]
        [Route("api/tblapp07veriler")]
        public tblapp07verilerresponse tblapp04veriler(tblapp07verilerrequest v_Gelen)
        {
            return new tblapp07_Manager().fn_tblapp07veriler(v_Gelen);
        }

        [HttpPost]
        [Route("api/tblapp07verilerSil")]
        public tblapp07verilerSilresponse tblapp07verilerSil(tblapp07verilerSilrequest v_Gelen)
        {
            return new tblapp07_Manager().fn_tblapp07verilerSil(v_Gelen);
        }
    }
}
