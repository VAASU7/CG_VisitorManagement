
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace VisitorManagemment;


[Route("api/[controller]")]
[ApiController]

public class StudentController: ControllerBase
{
    private readonly IStudentRepo _studentService;

    public StudentController(IStudentRepo studentService)
    {
        _studentService = studentService;
    }


    [HttpGet]

    public async Task<ActionResult<IEnumerable<StudentDTO>>>GetAllStudents()
    {
        var studentDTO = await _studentService.GetAllStudent();

        if (studentDTO == null || !studentDTO.Any())
        {
            return NotFound("No students found with the role of 'student'.");
        }


        return Ok(studentDTO);
    }


// [HttpPost]
// public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO studentDTO)
// {
//     if (studentDTO == null)
//     {
//         return BadRequest("Student Data is null");
//     }

//     await _studentService.CreateStudent(studentDTO);
    
//     var createdStudent = await _studentService.GetStudentByStudentID(studentDTO.StudentID);

//     return CreatedAtAction(nameof(GetAllStudents), new { id = createdStudent.VisitorId }, createdStudent);
// }



    [HttpPost]
public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO studentDTO)
{
    if (studentDTO == null)
    {
        return BadRequest("Student Data is null");
    }

    var createdStudent = await _studentService.CreateStudent(studentDTO);
    // Return the newly created student, including the VisitorId
    var visitorId = createdStudent.VisitorId;
    return Ok(new {message = $"Your visitor ID is {visitorId}", visitorId});
}

 
    [HttpPut("Put")]

    public async Task<ActionResult<StudentDTO>> UpdateStudent([FromBody] editStudnetDTO editstudentDTO)
    {
        try{
            if (editstudentDTO == null)
        {
            return BadRequest("Student data is null.");
        }

            await _studentService.UpdateStudent(editstudentDTO);
            return NoContent();
        }
        catch(KeyNotFoundException){
            return NotFound("Student Not Found");
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        
    }


}
