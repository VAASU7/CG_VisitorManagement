using System.Net;
using Microsoft.EntityFrameworkCore;

namespace VisitorManagemment;

public class EmployeeRepo:IEmployeeRepo
{
    //--------------------------------------------Constructor to implement DBContext into Repo


//  private readonly DBContext _context;

//     public EmployeeRepo(DBContext context)
//     {
//         _context = context;
//     }

//     //-------------------------------------------------Till Here

//     public async Task<IEnumerable<EmployeeDTO>> GetAllEmployee()
//     {
//         // Fetch all Technical employees from the database asynchronously
        
//     }

private readonly DBContext _context ;

public EmployeeRepo(DBContext context){
    _context = context;
}

public async Task<IEnumerable<EmpView>> GetAllEmployee()
{
    var Technical = await _context.Technical
     .Where(t => t.Role=="Employee").ToListAsync();
        var empViews = Technical.Select(t => new EmpView
        {
            VisitorId = t.VisitorId,
            Date = t.Date,
            InTime = t.InTime,
            Name = t.Name,
            Email = t.Email,
            Phone = t.Phone,
            DateOfBirth = t.DateOfBirth,
            Place = t.Place,
            OrganizationID = t.OrganizationID,
            Role = t.Role,
            Purpose = t.Purpose,
            OutTime = t.OutTime,
            Signature = t.Signature
        });

    return empViews;
}

public async Task CreateEmployee(EmployeeDTO employeeDTO){
    
    var technical = new Technical
    {
        Date = employeeDTO.Date,
            InTime = employeeDTO.InTime,
            Name = employeeDTO.Name,
            Email = employeeDTO.Email,
            Phone = employeeDTO.Phone,
            DateOfBirth = employeeDTO.DateOfBirth,
            Place = employeeDTO.Place,
            OrganizationID = employeeDTO.OrganizationID,
            Role = employeeDTO.Role,
            Purpose = employeeDTO.Purpose,

    };
    
    await _context.Technical.AddAsync(technical);
    await _context.SaveChangesAsync();
}

public async Task UpdateEmployee(EditEmpDTO editEmpDTO){

   var technical = await _context.Technical.FindAsync(editEmpDTO.VisitorId);
 
    if (technical == null)
    {
        throw new KeyNotFoundException("Employee not found.");
    }
 
    // Update only the specified fields
    if (editEmpDTO.OutTime.HasValue)
    {
        technical.OutTime = editEmpDTO.OutTime.Value;
    }
 
    if (!string.IsNullOrEmpty(editEmpDTO.Signature))
    {
        technical.Signature = editEmpDTO.Signature;
    }
 
    // Mark the entity as modified and save changes
    _context.Technical.Update(technical);
    await _context.SaveChangesAsync();

}


}
