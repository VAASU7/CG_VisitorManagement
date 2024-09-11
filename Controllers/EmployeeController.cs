using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VisitorManagemment;


[Route("api/[controller]")]
[ApiController]

public class EmployeeController: ControllerBase
{

private readonly IEmployeeRepo _employeeService;

public EmployeeController(IEmployeeRepo employeeService)
{
    _employeeService = employeeService;
}

[HttpGet]
public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
{
    var employeeDTOs = await _employeeService.GetAllEmployee();
    // var EmployeeDTOs = new List<EmployeeDTO>();

    return Ok(employeeDTOs);
}

[HttpPost]

public async Task<ActionResult<EmployeeDTO>>CreateEmployee([FromBody]   EmployeeDTO employeedto)
    
 {
            if (employeedto == null)
            {
                return BadRequest("Employee data is null");
            }

            await _employeeService.CreateEmployee(employeedto);
            return CreatedAtAction(nameof(GetAllEmployees), new { id = employeedto.OrganizationID }, employeedto);
        }



  [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EditEmpDTO editemployeedto)
        {
            try
            {
                // Call the repository method to update the employee details
                await _employeeService.UpdateEmployee(editemployeedto);
 
                // Return NoContent status indicating the request was successful and no content is being returned
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                // Return NotFound status if the employee was not found
                return NotFound("Employee not found.");
            }
            catch (Exception ex)
            {
                // Return InternalServerError status for any other exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
     



}

