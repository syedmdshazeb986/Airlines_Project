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
    public class UserController : Controller
    {
        public AppDbContext _context { get; }
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        //get user details by id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var user = _context.UserDetails.FirstOrDefault(u => u.UserId == id);
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest("User does not exist");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("wallet/{id}")]
        public ActionResult GetWallet(int id)
        {
            try
            {
                var wallet = _context.Wallets.FirstOrDefault(w => w.UserId == id);
                if (wallet != null)
                {
                    return Ok(wallet);
                }
                return BadRequest("User does not exist");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("registration")]
        public ActionResult Post(UserDetails newuser)
        {
            var user_exist = _context.UserDetails.FirstOrDefault(u => u.Email == newuser.Email);
            if (user_exist == null)
            {
                _context.UserDetails.Add(newuser);
                _context.SaveChanges();

                return Ok("Registration Successful");
            }
            return BadRequest("Already exist");
                //return Ok();
      }
        [HttpPost]
        [Route("Userlogin")]
        public ActionResult UserLogin(UserLogin login)
        {

                var user = _context.UserDetails.SingleOrDefault(u => u.Email == login.Email && u.Password == login.Password);
                
                if (user == null)
                {
                return NotFound("Not found ");

                }
                else
                 {
                return Ok(user);

                 }


        }
        
        [HttpPost("flight/search")]
        public ActionResult<IEnumerable<SearchData>> SearchFlight([FromBody] SearchQuery query)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = _context.FilteredFlights.FromSqlInterpolated($"exec dbo.SP_Search_Flight {query.Booking_Type}, {query.Depart_airport_Id}, {query.Arrival_airport_Id}, {query.Departure_Time}, {query.Arrival_Time}, {query.adults},{query.childs} , {query.infants}, {query.Class_Type}");
                if (result != null)
                {
                    return Ok(result);
                }
                
                 return StatusCode(StatusCodes.Status500InternalServerError, "Failed"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        

        [HttpGet("flight/{id}")]
        public ActionResult<IEnumerable<Seat>> GetSeatsByFlightId(int id)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _context.GetSeatsByFId.FromSqlInterpolated($"exec dbo.SP_Get_Seats_By_FlightId {id}");
                if (result != null)
                {
                    return Ok(result);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        [HttpGet]
        [Route("airports")]
        public ActionResult GetAirports()
        {

            try
            {
                if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState);

                }
                var result = _context.Airports.ToList();

                if (result != null)
                {
                    return Ok(result);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }



        //getFlightPrice
        [HttpPost("flight/getprice")]
        public IActionResult GetFlightPrice(GetFlightPrice Flightquery)
        {
            if (Flightquery.SeatType == "business")
            {
                var price = _context.Flights.FirstOrDefault(p => p.FlightId == Flightquery.FlightId);
                return Ok(price.Business_fare);
            }
            else 
            {
                var Price = _context.Flights.FirstOrDefault(p => p.FlightId == Flightquery.FlightId);
                return Ok(Price.Economy_fare);
            }
            return Ok("Invalid Input");
        }


        //book flight
        [HttpPost]
        [Route("booking")]
        public ActionResult BookFlight([FromBody] BookingQuery query)
        {

            try
            {
                if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState);

                }

                GetFlights flight = _context.Flights.FirstOrDefault(f => f.FlightId == query.FlightId);
                decimal amount;


                if (flight == null)
                {
                    return BadRequest("Flight does not exist");
                }



                if (query.Class_Type == "business")
                {
                    amount = flight.Business_fare;
                }
                else if (query.Class_Type == "economy")
                {
                    amount = flight.Economy_fare;
                }
                else
                {
                    return BadRequest("Invalid Flight Class Type");
                }



                if (query.Booking_Type == "one_way" || query.Booking_Type == "return") { }
                else
                {
                    return BadRequest("Invalid booking type");
                }
                UserDetails u = _context.UserDetails.FirstOrDefault(user => user.UserId == query.UserId);
                if (u == null)
                {
                    return BadRequest("Invalid User");

                }

                if (query.Payment_mode == "credit_card" || query.Payment_mode == "debit_card") { }
                else
                {
                    return BadRequest("Invalid Payment mode");
                }
                List<BookingData> result = _context.GettingBookingData.FromSqlInterpolated($"exec dbo.SP_BooKFlight {query.UserId},{query.FlightId}, {query.Booking_Type}, {query.Return_Date}, {query.Passengers.FindAll(p => p.Age > 2).Count * amount},{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}, {query.Class_Type}, {flight.Departure_Time}, {query.Payment_mode}, {query.Passengers.Count}").ToList();

                if (result != null && result.Count > 0)
                {
                    List<Seat> seats = _context.GetSeatsByFId.FromSqlInterpolated($"exec dbo.SP_Get_Seats_By_FlightId {flight.FlightId}").ToList();

                    for (int i = 0; i < query.Passengers.Count; i++)
                    {
                        //check seat availibility
                        Seat s = seats.FirstOrDefault(seat => seat.SeatId == query.Passengers[i].SeatId);
                        if (s == null)
                        {
                            return BadRequest("Invalid Seat No.");
                        }
                        if (s.is_booked == true)
                        {
                            return BadRequest($"Seat {s.SeatName} ({s.SeatId}) is already booked");

                        }
                        var passenger = _context.Database.ExecuteSqlInterpolated($"exec dbo.SP_Add_Passengers {query.Passengers[i].Firstname},{query.Passengers[i].Lastname},{query.Passengers[i].Email}, {result[0].BookingId}, {query.Passengers[i].Phone_Number}, {query.Passengers[i].Age}, {query.Passengers[i].Gender},{query.Passengers[i].SeatId}");
                        if (passenger == 0)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add passengers");

                        }
                    }

                    return Ok("Flight Booked Successfully");

                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to book");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        //getting bookings by ID
        [HttpGet("getbookings/{id}")]
        public ActionResult<IEnumerable<GetBookings>> getbookings(int id)
        {

                var  result = _context.GetBookings.FromSqlInterpolated<GetBookings>($"dbo.SP_Show_Booking {id}");
                if (result != null)
                {
                    return Ok(result);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid id");
        }

        //cancellingtickets by ID
        [HttpGet("cancelbooking/{id}")]
        public ActionResult<BookingData> DeleteBooking(int id)
        {

            var result = _context.GettingBookingData.FromSqlInterpolated($"dbo.SP_CancelBooking {id}");
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Invalid id");
        }

       /* //cancellingtickets

        [HttpDelete]
    [Route("cancelbooking/{id}")]
        public ActionResult DeleteBooking(int id)
        {

            try
            {
                var result = _context.Database.ExecuteSqlInterpolated($"exec dbo.SP_Cancel_Booking {id}");
                if (result != 0)
                {
                    return Ok("Cancellation Done Successfully");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
       */


    //getting cancelled bookings by ID
    [HttpGet("getcancelledbookings/{id}")]
    public ActionResult<IEnumerable<GetBookings>> getcancelledbookings(int id)
    {

        var result = _context.GetBookings.FromSqlInterpolated<GetBookings>($"dbo.SP_Show_CancelledBooking {id}");
        if (result != null)
        {
            return Ok(result);
        }
        return StatusCode(StatusCodes.Status500InternalServerError, "Invalid id");
    }

    }
}
