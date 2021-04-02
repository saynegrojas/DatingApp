using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string>GetSecret() {
            
            return "secret text";
        }
        [HttpGet("not-found")]

        public ActionResult<Value>GetNotFound() {
            // go to db check for a -1 primary key, return a NotFound
            var thingToFind = _context.Values.Find(-1);
            if(thingToFind == null) return NotFound();
            return thingToFind;
        }
        [HttpGet("server-error")]

        public ActionResult<string>GetServerError() {
            
            var thingToFind = _context.Values.Find(-1);
            var thingToReturn = thingToFind.ToString();
            return thingToReturn;
        }
        [HttpGet("bad-request")]

        public ActionResult<string>GetBadRequest() {
            
            return BadRequest("Bad Request");
        }
    }
}