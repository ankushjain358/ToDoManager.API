using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public int GetCurrentUserId()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value);
            }
            return 0;
        }
    }
}