using tms.Models;

namespace tms.Services;

public class courseservices:courses
{
    static List<courses> CoursesList = new List<courses>();

    public static void AddCourses()
    {
        Console.WriteLine("Enter course code:");
        string courseCode = Console.ReadLine();
        Console.WriteLine("Enter course name:");
        string courseName = Console.ReadLine();
        Console.WriteLine("Enter fees:");
        decimal fees = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter duration:");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter total seats:");
        int total_seats = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter enroled seats:");
        int enrolled_seats = int.Parse(Console.ReadLine());
        
        
        courses course1 = new courses(courseCode, courseName, fees, duration,total_seats, enrolled_seats);
        CoursesList.Add(course1);
    }
    public static void displayCourses()
    {
        foreach (courses course in CoursesList)

        {

            Console.WriteLine("-------------------------");

            Console.WriteLine($"Course Code: {course.Course_code}");

            Console.WriteLine($"Course Name: {course.Course_name}");

            Console.WriteLine($"Fees: {course.Fees}");

            Console.WriteLine($"Duration: {course.Duration}");

            Console.WriteLine($"Total Seats: {course.Total_seats}");

            Console.WriteLine($"Enrolled Count: {course.Enrolled_count}");

            Console.WriteLine($"available seats:{course.Total_seats-course.Enrolled_count}");
            
            Console.WriteLine("-------------------------");
        }
    }
    public static courses GetCourseByCode(string courseCode)

    {

        return CoursesList.FirstOrDefault(

            c => c.Course_code == courseCode

        );

    }
    public  static void Searchcourse()
    {
        bool courseavailablityFlag=false;
        Console.Write("Search by course code:"); 
        string courseCode = Console.ReadLine();
        for (int i = 0; i < CoursesList.Count; i++)
        {
            if ((CoursesList[i].Course_code == courseCode) &&  (CoursesList[i].Total_seats > CoursesList[i].Enrolled_count))
            {
                courseavailablityFlag = true;
                break;
            }
        }

        if (courseavailablityFlag)
        {
            Console.WriteLine("course available");
        }
        else
        {
            Console.WriteLine("course not available");
        }
        
    }
    
    
}