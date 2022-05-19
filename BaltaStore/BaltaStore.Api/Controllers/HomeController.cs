using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public object Get() =>  new {version = "Version 0.0.1" };
        

        


    }
}
