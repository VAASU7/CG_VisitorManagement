namespace VisitorManagemment;

public interface IEmployeeRepo
{
    Task<IEnumerable<EmpView>>GetAllEmployee();
    // Task<Technical>GetAllEmployeeById(int id);
    // Task CreateEmployee(EmployeeDTO employeedto);---->EmployeeDTO->EmpView
    Task CreateEmployee(EmployeeDTO employeeDTO);
    Task UpdateEmployee(EditEmpDTO editEmpDTO);
    

}
