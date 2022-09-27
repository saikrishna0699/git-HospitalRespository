using HospitalManagementSystem.Core.Interface;
using HospitalManagementSystem.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IHospital _context;
        public HospitalController(IHospital context)
        {
            _context = context;

        }
        [HttpGet("Get")]
        public async Task<IActionResult> DisplayAllHospitals()
        {
            try
            {
                var result = _context.DisplayAllHospitals();
                log.Info("Data is Displayed");
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPost("Post")]
        public async Task<ActionResult> AddHospital([FromBody] HospitalModel hospitalModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.AddHospital(hospitalModel);
                    log.Info("Created Successfully");
                    return StatusCode(200, "Created Successfully");
                }
                else
                {
                    log.Error("No Data");
                    return BadRequest("No Data");
                }
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the Database");
            }
        }
    }
}
