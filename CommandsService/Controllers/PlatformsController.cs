using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace  CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase {

     public PlatformsController()
     {
         
     }

    [HttpPost]
     public ActionResult TestInboundConnectio(){
         System.Console.WriteLine("--> inbouncd post @ command service");
         return Ok("Test OK!");
     }
    }
}