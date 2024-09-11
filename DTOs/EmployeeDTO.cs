using System.ComponentModel.DataAnnotations;

namespace VisitorManagemment;


// public class EmpDTO{
//     public DateOnly Date{ get; set; }
//     public TimeOnly InTime{ get; set; }
//     public string Name { get; set; }
//     public string Email { get; set; }
//     public long Phone { get; set; }
//     public DateOnly DateOfBirth{ get; set; }
//     public string Place { get; set; }
//     public string Role { get; set; }
//     public int OrganizationID { get; set; }
//     public string purpose { get; set; }

//     public TimeOnly OutTime{ get; set; }
//     public string Signature { get; set; }


// }
public class EmployeeDTO
{
    public int VisitorId { get; set; }
    public DateOnly Date{ get; set; }
    public TimeOnly? InTime{ get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public DateOnly? DateOfBirth{ get; set; }
    public string Place { get; set; }
    public string Role { get; set; }
    public int OrganizationID { get; set; }
    public string Purpose { get; set; }

}

public class EditEmpDTO{
    [Key]
    public int VisitorId { get; set; }
    [Required]
    public TimeOnly? OutTime { get; set; }
    [Required]
    public string? Signature { get; set; }
}
