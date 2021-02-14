using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDatingApp.API.Data;

namespace UdemyDatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        /*private readonly DataContext _context;
        public BaseApiController(DataContext context)
        {
            _context = context;
        }*/
    }
}
