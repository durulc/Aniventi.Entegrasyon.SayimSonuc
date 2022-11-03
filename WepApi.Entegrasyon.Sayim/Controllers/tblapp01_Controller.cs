using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WepApi.Entegrasyon.Sayim.Manager;
using WepApi.Entegrasyon.Sayim.Request;
using WepApi.Entegrasyon.Sayim.Response;

namespace WepApi.Entegrasyon.Sayim.Controllers
{
    public class tblapp01_Controller : ApiController
    {
        [HttpPost]
        [Route("api/tblapp01veriler")]
        public tblapp01verilerresponse tblapp01veriler(tblapp01verilerrequest v_Gelen)
        {
            return new tblapp01_Manager().fn_tblapp01veriler(v_Gelen);
        }

        [HttpPost]
        [Route("api/tblapp01verilerSil")]
        public tblapp01verilerSilresponse tblapp01verilerSil(tblapp01verilerSilrequest v_Gelen)
        {
            return new tblapp01_Manager().fn_tblapp01verilerSil(v_Gelen);
        }
    }
}
