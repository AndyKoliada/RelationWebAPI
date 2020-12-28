using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Countries Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        /// <summary>
        /// DI constructor
        /// </summary>
        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // todo: use middleware to  handle exceptions
            try
            {
                var countries = await _countriesService.GetCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
