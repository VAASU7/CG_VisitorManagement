using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VisitorManagemment;

public class StudentRepo:IStudentRepo
{
private readonly DBContext _context;

public StudentRepo(DBContext Context){
    _context = Context;
}

public async Task<IEnumerable<Student>>GetAllStudent(){
    var Technical = await _context.Technical
     .Where(x => x.Role=="Student").ToListAsync();
    var students = Technical.Select(x => new Student
    {
        VisitorId = x.VisitorId,
        Date = x.Date,
           InTime = x.InTime,
             Name = x.Name,
             Email = x.Email,
            Phone = x.Phone,
            DateOfBirth = x.DateOfBirth,
            Place = x.Place,
            StudentID = x.StudentID,
            Role = x.Role,
             Purpose = x.Purpose,
             OutTime = x.OutTime,
             Signature = x.Signature

    });

    return students;
}

public async Task<Technical> CreateStudent(StudentDTO studentDTO){

    var technical = new Technical
    {
        Date = studentDTO.Date,
            InTime = studentDTO.InTime,
            Name = studentDTO.Name,
            Email = studentDTO.Email,
            Phone = studentDTO.Phone,
            DateOfBirth = studentDTO.DateOfBirth,
            Place = studentDTO.Place,
            StudentID = studentDTO.StudentID,
            Role = studentDTO.Role,
            Purpose = studentDTO.Purpose,

    };

    await _context.Technical.AddAsync(technical);
    await _context.SaveChangesAsync();
    return technical;
}

public async Task UpdateStudent(editStudnetDTO editstudnetDTO){

    var technical = await _context.Technical.FindAsync(editstudnetDTO.VisitorId);
    //var technicals = await _context.Technical.FindAsync(editstudnetDTO.Role);
    if (technical == null  )
    {
        throw new KeyNotFoundException("Student Not Found");
    }
    if(editstudnetDTO.OutTime.HasValue)
    {
        technical.OutTime = editstudnetDTO.OutTime.Value;
    }

    if(!string.IsNullOrEmpty(editstudnetDTO.Signature))
    {
        technical.Signature = editstudnetDTO.Signature;
    }
    // Update Role only if it matches "student" and is not null or empty
    if (!string.IsNullOrEmpty(editstudnetDTO.Role) && editstudnetDTO.Role.Equals("student", StringComparison.OrdinalIgnoreCase))
    {
        technical.Role = editstudnetDTO.Role;
    }
   
   
    _context.Technical.Update(technical);
    await _context.SaveChangesAsync();
}

public async Task<Student> GetStudentByStudentID(string studentID)
    {
        var technical = await _context.Technical
            .Where(x => x.StudentID == studentID && x.Role == "Student")
            .Select(x => new Student
            {
                VisitorId = x.VisitorId,
                Date = x.Date,
                InTime = x.InTime,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                DateOfBirth = x.DateOfBirth,
                Place = x.Place,
                StudentID = x.StudentID,
                Role = x.Role,
                Purpose = x.Purpose,
                OutTime = x.OutTime,
                Signature = x.Signature
            })
            .FirstOrDefaultAsync();

        if (technical == null)
        {
            throw new KeyNotFoundException("Student not found");
        }

        return technical;
    }}








