using System;
using System.Threading.Tasks;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace Web.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Members

        private readonly ICustomerService _customerService;

        #endregion Members

        #region Constructor

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #endregion Constructor

        #region CRUD

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CustomerViewModel customer)
        {
            try
            {
                _customerService.Save(customer);

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
        public async Task<IActionResult> Update([FromBody] CustomerViewModel customer)
        {
            try
            {
                _customerService.Update(customer);

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
                _customerService.Delete(id);

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
                var customer = _customerService.GetAll();

                return Ok(customer);
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
                var customer = _customerService.Get(id);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("genders")]
        public async Task<IActionResult> Genders()
        {
            try
            {
                var genderList = _customerService.GetGenders();

                return Ok(genderList);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("civilstatus")]
        public async Task<IActionResult> CivilStatus()
        {
            try
            {
                var civilStatusList = _customerService.GetCivilStatus();

                return Ok(civilStatusList);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("accounttypes")]
        public async Task<IActionResult> AccountTypes()
        {
            try
            {
                var accountTypeList = _customerService.GetAccountTypes();

                return Ok(accountTypeList);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #endregion CRUD
    }
}