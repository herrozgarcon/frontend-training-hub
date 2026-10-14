namespace tms.Models;

public class courses
{
    public string Course_code{get;set;}
    public string Course_name{get;set;}
    public decimal Fees{get;set;}
    public int Duration{get;set;}
    public int Total_seats{get;set;}
    public int Enrolled_count{get;set;}

    public courses(string course_code, string course_name, decimal fees, int duration, int total_seats, int enrolled_count)
    {
        Course_code = course_code;
        Course_name = course_name;
        Fees = fees;
        Duration = duration;
        Total_seats = total_seats;
        Enrolled_count = enrolled_count;
    }
    public courses()
    {
        
    }
    
}