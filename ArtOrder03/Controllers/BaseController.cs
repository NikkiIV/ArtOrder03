using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtOrder03.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
