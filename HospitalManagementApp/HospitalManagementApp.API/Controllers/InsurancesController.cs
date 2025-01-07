using HospitalManagementApp.BL.DTOs.InsuranceDTOs;
using HospitalManagementApp.BL.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancesController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsurancesController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet("GetAllInsurances")]
        public async Task<IActionResult> GetAllInsurances()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _insuranceService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("GetInsuranceById/{id}")]
        public async Task<IActionResult> GetInsuranceById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _insuranceService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            } 
        }

        [HttpPost("AddInsurance")]
        public async Task<IActionResult> AddInsurance(InsurancePostDto insurancePostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool result = await _insuranceService.AddAsync(insurancePostDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }
        }

        [HttpPut("UpdateInsurance")]
        public async Task<IActionResult> UpdateInsurance(int id, InsurancePutDto insurancePutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            
            try
            {
                bool result = await _insuranceService.UpdateAsync(id, insurancePutDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            } 
        }

        [HttpPut("SoftDeleteInsurance/{id}")]
        public async Task<IActionResult> SoftDeleteInsurance(int id)
        {
            try
            {
                bool result = await _insuranceService.SoftDeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
        
        [HttpPut("RestoreInsurance/{id}")]
        public async Task<IActionResult> RestoreInsurance(int id)
        {
            try
            {
                bool result = await _insuranceService.RestoreAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }

        [HttpDelete("DeleteInsurance/{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            try
            {
                bool result = await _insuranceService.DeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
    }
}
