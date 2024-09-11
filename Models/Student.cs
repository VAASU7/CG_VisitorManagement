public class Student{

    public int VisitorId { get; set; }  
    public DateOnly Date{ get; set; }
    public TimeOnly? InTime{ get; set;}
    public string Name { get; set;}
    public string Email { get; set;}

    public long Phone{ get; set;}
    public DateOnly? DateOfBirth{ get; set;}
    public string Place{ get; set;}
    public string Role{ get; set;}
    public string StudentID{ get; set;}
    public string Purpose{ get; set;}
    public string? Signature{ get; set;}
    
    public TimeOnly? OutTime{ get; set;}

}