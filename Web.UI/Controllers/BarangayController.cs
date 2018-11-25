using System;
using System.Threading.Tasks;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ViewModel;

namespace Web.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangayController : BaseController
    {
        #region Members

        private readonly IBarangayService _barangayService;

        #endregion Members

        #region Constructor

        public BarangayController(IBarangayService barangayService)
        {
            _barangayService = barangayService;
        }

        #endregion Constructor

        #region CRUD

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BarangayViewModel barangay)
        {
            try
            {
                _barangayService.Save(barangay);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] BarangayViewModel barangay)
        {
            try
            {
                _barangayService.Update(barangay);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _barangayService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var barangay = _barangayService.GetAll();

                return Ok(barangay);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var barangay = _barangayService.Get(id);

                return Ok(barangay);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #endregion CRUD
    }
}