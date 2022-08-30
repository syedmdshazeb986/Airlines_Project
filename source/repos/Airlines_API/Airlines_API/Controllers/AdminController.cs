using Airlines_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        [Route("Userlogin")]
        public ActionResult AdminLogin(UserLogin u)
        {

            var admin = _context.Admins.FirstOrDefault(a => a.Admin_Username == u.Email && a.Admin_password == u.Password);


            if (admin == null)
            {
                return BadRequest("Invalid Credentials");
            }
            return Ok("Login Successful");

        }
        
        [HttpGet]
        [Route("flights")]
        public ActionResult GetFlights()
        {
            try
            {
                List<FlightModel> flights = _context.GetFlights.ToList();

                return Ok(flights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
        [HttpPost]
        [Route("addflight")]
        public ActionResult AddFlight(Flight f)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (f.departure_time > f.arrival_time)
                {
                    return BadRequest("Departure time is later than Arrival Time");
                }

                var res = _context.Database.ExecuteSqlInterpolated($"exec dbo.SP_Add_Flight {f.flightName},{f.depart_airport_id},{f.arrival_airport_id}, {f.departure_time}, {f.arrival_time}, {f.economy_fare}, {f.business_fare}");
                if (res != 0)
                {
                    return Ok(true);

                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private ActionResult StatusCode(object status50)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("flight/{name}")]
        public ActionResult DeleteFlight(string name)
        {

            try
            {
                var result = _context.Database.ExecuteSqlInterpolated($"exec dbo.SP_Delete_Flight {name}");
                if (result != 0)
                {
                    return Ok("Flight Deleted Successfully");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
