using System.Threading.Tasks;
using System.Web.Http;
using Service;
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

        [Route("userinfo")]
        public async Task<IHttpActionResult> GetUserInfo(string username)
        {
            return Ok(await _service.GetUserInfo(username));
        }

    }
}
