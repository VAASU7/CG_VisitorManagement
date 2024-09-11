namespace VisitorManagemment;

public interface IStudentRepo
{
     Task<IEnumerable<Student>>GetAllStudent();

    Task<Technical> CreateStudent(StudentDTO studentDTO);

    Task UpdateStudent(editStudnetDTO editstudnetDTO);
     Task<Student> GetStudentByStudentID(string studentID);



}


