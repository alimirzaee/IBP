using IOT_API2.Database;
using IOT_API2.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDBContext db;

        public UserController(AppDBContext context)
        {
            db = context;
        }

        [HttpGet]
        public IList<AppUser> Get()
        {
            return (this.db.Users.ToList());
        }
    }
}