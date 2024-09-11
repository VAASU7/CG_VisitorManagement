using Microsoft.AspNetCore.Mvc;
using VisitorManagemment;
[Route("api/[controller]")]
[ApiController]
public class AdminController:ControllerBase{
    private readonly IAdminRepo _adminRepo;
    public AdminController(IAdminRepo adminRepo){
        _adminRepo = adminRepo;

    }
    
[HttpGet]
public async Task<ActionResult<IEnumerable<Technical>>> GetAllData( ){
 var technicals = await _adminRepo.GetAllData();
 return Ok(technicals);
}


[HttpPost]
public async Task<IActionResult> CreateData([FromBody] Technical technical)
{
    technical.VisitorId = 0;
    technical.OutTime = null; // Assuming it's optional and can be set later
    try
    {
        await _adminRepo.CreateData(technical);
        return CreatedAtAction(nameof(GetVisitorById), new { id = technical.VisitorId }, technical);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}


[HttpPut("{VisitorId}")]

public async Task<IActionResult> UpdateData(int VisitorId, [FromBody] Technical technical)
{
    if (VisitorId != technical.VisitorId)
    {
        return BadRequest("VisitorId in the path and in the request body do not match.");
    }
   
    try
    {
        await _adminRepo.UpdateData(technical);
        return Ok(technical); // Return 204 No Content to indicate the update was successful
    }
    catch (KeyNotFoundException)
    {
        return NotFound("Technical entry not found.");
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}


// [HttpGet("{id}")]
// public async Task<ActionResult<IEnumerable<Technical>>> GetData(int VisitorId){
//     var technicals = await _adminRepo.GetAllDataByID(VisitorId);
//     return Ok(technicals);
// }

[HttpGet("visitorId/{id}")]
public async Task<IActionResult> GetVisitorById(int id)
{
    // Fetch the visitor data based on the provided ID
    var technical = await _adminRepo.GetAllDataByID(id);

    // Check if the visitor data exists
    if (technical == null)
    {
        // Return 404 Not Found if no visitor data is found
        return NotFound();
    }

    // Return the visitor data with a 200 OK status
    return Ok(technical);
}


[HttpDelete("{VisitorId}")]
public async Task<ActionResult<Technical>> Delete(int VisitorId){
    var technicals = await _adminRepo.DeleteDataById(VisitorId);
        return Ok(technicals);

}


}

