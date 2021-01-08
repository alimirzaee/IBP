

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
    public class UserGroupController : ControllerBase
    {
        private AppDBContext db;

        public UserGroupController(AppDBContext context)
        {
            db = context;
        }

        [HttpGet]
        public IList<UserGroup> Get()
        {
            return (this.db.UserGroups.ToList());
        }
    }
}