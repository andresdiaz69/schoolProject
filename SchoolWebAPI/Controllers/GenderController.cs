using Microsoft.AspNetCore.Mvc;
using SchoolWebAPI.Domain.IServices;
using SchoolWebAPI.Services;

namespace SchoolWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenderController"/> class.
        /// </summary>
        /// <param name="genderService">The gender service.</param>
        public GenderController(IGenderService genderService)
        {
            this._genderService = genderService;
        }

        [Route("GetAllGenders")]
        [HttpGet]
        public async Task<ActionResult> GetAllGenders()
        {
            try
            {
                var listGenders = await _genderService.GetAllGenders();

                if (!listGenders.IsSuccess)
                    return BadRequest(listGenders.ErrorMessage);


                return Ok(listGenders.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
