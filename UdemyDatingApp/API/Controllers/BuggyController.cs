using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDatingApp.API.Data;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var resp = _context.Users.Find(-1);
            return resp.ToString();
        }

        [HttpGet("auth")]
        [Authorize]
        public ActionResult<string> GetAuth()
        {
            return "not authorized";
        }

        [HttpGet("not-found")]
        public ActionResult<User> GetNotFound()
        {
            var resp = _context.Users.Find(-1);
            if (resp == null) return NotFound();

            return Ok(resp);
        }

        [HttpGet("bad-request")]
        public ActionResult<User> GetBadRequest() 
        {
            return BadRequest("Bad Request");
        }
    }
}
