using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Linq;
using System.Reflection.Metadata;
using webapi.Data;
using webapi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]

    [Produces("application/json")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class GetTransportController : ControllerBase
    {
        private TravelAppDbContext _db;

        private readonly ILogger<WeatherForecastController> _logger;

        public GetTransportController(ILogger<WeatherForecastController> logger, TravelAppDbContext context)
        {
            _logger = logger;
            _db= context;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TransportationOption>))]
        [HttpGet("GetTransportationOptions")]
        public async Task<IActionResult> GetTransportationOptions()
        {
            List<TransportationOption> options = _db.TransportationOptions.Where(c=>c.Id >0).ToList();
            return Ok(options);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Booking>))]
        [HttpGet("GetBookings")]
        public async Task<IActionResult> GetBookings()
        {
            List<Booking> options = _db.Bookings.Where(c => c.Id > 0).ToList();
            return Ok(options);
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPost("SaveBookings")]
        public async Task<IActionResult> SaveBooking(int transportation_option_id, int user_login_id )
        {
            if (transportation_option_id <= 0 )
                return BadRequest("Invalid transportation type");
            if (user_login_id <= 0)
                return BadRequest("Invalid user id");
//            _db.Bookings.Add(new Booking())
            List<Booking> options = _db.Bookings.Where(c => c.Id > 0).ToList();
            return Ok(options);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Payment>))]
        [HttpGet("GetPayments")]
        public async Task<IActionResult> GetPayments()
        {
            List<Payment> options = _db.Payments.Where(c => c.Id > 0).ToList();
            return Ok(options);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PaymentType>))]
        [HttpGet("GetPaymentTypes")]
        public async Task<IActionResult> GetPaymentTypes()
        {
            List<PaymentType> options = _db.PaymentTypes.Where(c => c.PaymentTypeId > 0).ToList();
            return Ok(options);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserLogin>))]
        [HttpGet("GetUserLogins")]
        public async Task<IActionResult> GetUserLogins()
        {
            List<UserLogin> options = _db.UserLogins.Where(c => c.UserLoginId > 0).ToList();
            return Ok(options);
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLogin))]
        [HttpGet("GetUserLogin")]
        public async Task<IActionResult> GetUserLogin(string username, string password)
        {
            var user = _db.UserLogins.Where(c => c.UserEmail == username && c.UserPassword == password).SingleOrDefault();
            return Ok(user);
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUserLogin(string user_name, string user_password)
        {
            if (user_name.Length == 0)
                return BadRequest("Invalid user name");
            if (user_password.Length == 0)
                return BadRequest("Invalid password");

            var userLogin = new UserLogin { UserEmail = user_name, UserPassword = user_password};
            _db.UserLogins.Add(userLogin);
            _db.SaveChanges();

            return Ok(userLogin.UserLoginId);
        }
    }
}
