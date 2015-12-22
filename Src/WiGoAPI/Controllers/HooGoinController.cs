using System.Threading.Tasks;
using System.Web.Http;
using Service;
using Service.HooGoin;
using Service.Repositories;

namespace WiGoAPI.Controllers
{
    [RoutePrefix("api/HooGoin")]
    public class HooGoinController : ApiController
    {
        private WiGoService _service;

        public HooGoinController()
        {
            _service = new WiGoService();
        }

        [HttpPost]
        [Route("userinfo")]
        public async Task<IHttpActionResult> GetUserInfo(UserInfo info)
        {

            return Ok(await _service.GetUserInfo(info));
        }


    }
}
