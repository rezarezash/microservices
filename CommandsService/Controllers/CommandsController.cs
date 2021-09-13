using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace  CommandsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase {

        public CommandsController()
        {            
        }

        [HttpPost]
        public ActionResult PostCommnad(){
            return Ok();

        }     
    }
}