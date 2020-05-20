using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Persistence;

namespace Portal.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly PortalDbContext _db;
        public MenuController(PortalDbContext db)
        {
            _db = db;
        }
        [Route("api/menu")]
        public IActionResult Get()
        {
            var model = _db.Menus.ToList();
            return Ok(model);
        }
    }
}
