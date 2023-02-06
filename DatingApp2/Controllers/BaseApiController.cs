using DatingApp2.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp2.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
