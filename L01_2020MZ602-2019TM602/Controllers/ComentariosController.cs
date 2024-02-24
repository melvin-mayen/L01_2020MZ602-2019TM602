using L01_2020MZ602_2019TM602.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2020MZ602_2019TM602.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2020MZ602_2019TM602.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {

        private readonly blogContext _blogContext;

        public ComentariosController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }

    }
}
