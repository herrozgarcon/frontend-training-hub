namespace trainingmannagement.models;

public class courses
{
    public string Coursecode { get; set; }
    public string Title { get; set; }
    public decimal Fees { get; set; }
    public int Durrationdays { get; set; }
    public int Totalseats { get; set; }
    public int EnrolledCount { get; set; }

    public courses(string coursecode, string title, decimal fees, int durrationdays, int totalseats, int enrolledcount)
    {
        Coursecode = coursecode;
        Title = title;
        Fees = fees;
        Durrationdays = durrationdays;
        Totalseats = totalseats;
        EnrolledCount = enrolledcount;
    }

    public courses()
    {
        
    }
    
}