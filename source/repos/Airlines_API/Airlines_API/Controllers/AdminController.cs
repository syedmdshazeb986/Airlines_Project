using Airlines_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {

         public AppDbContext _context { get; }
         public AdminController(AppDbContext context)
         {
                _context = context;
          }

        [Route("Userlogin")]
        public ActionResult AdminLogin(UserLogin u)
        {

            var admin = _context.Admins.FirstOrDefault(a => a.Admin_Username == u.Email && a.Admin_password == u.Password);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (admin == null)
            {
                return BadRequest("Invalid Credentials");
            }
            return Ok("Login Successfull");

        }

    }
}
