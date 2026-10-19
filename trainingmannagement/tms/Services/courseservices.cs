using System.Reflection.PortableExecutable;
using tms.Models;

namespace tms.Services;

public class courseservices:courses
{
    public static List<courses> CoursesList = new List<courses>()
    {
        new courses("cs123","python",123m,1,50,10),
        new courses("cs154","java",123m,1,50,20),
        new courses("cs187","dsa",200m,2,50,5),
    };
    
        
    public static void displayCourses()

    {
        CoursesList.ForEach(course => Console.WriteLine(            
            $"Course Code: {course.Course_code}\n" +
            $"Course Name: {course.Course_name}\n" + 
            $"Fees: {course.Fees}\n" + 
            $"Duration: {course.Duration}\n" + 
            $"Total Seats: {course.Total_seats}\n" + 
            $"Enrolled Count: {course.Enrolled_count}\n" + 
            $"available seats:{course.Total_seats - course.Enrolled_count}\n" + 
            $"-----------------------------------------------------------"));      
        
        string[] lines = ["hygfd"];
        List<string> d=new List<string>();
        CoursesList.ForEach(course => d.Add(
        
            $"Course Code: {course.Course_code}\n" +
            $"Course Name: {course.Course_name}\n" +
            $"Fees: {course.Fees}\n" +
            $"Duration: {course.Duration}\n" +
            $"Total Seats: {course.Total_seats}\n" +
            $"Enrolled Count: {course.Enrolled_count}\n" +
            $"available seats:{course.Total_seats - course.Enrolled_count}\n" +
            $"-----------------------------------------------------------"
        ));
        

        string path ="/Users/hrithik/hcl training/trainingmannagement/tms/files/courses.txt";
        
        File.WriteAllLines(path,d);
    }
    
    
    public static courses? GetCourseByCode(string courseCode)
    {
        return CoursesList.FirstOrDefault(c => c.Course_code == courseCode);
    }
    
    
    public  static void Searchcourse()
    {
        
        Console.Write("Search by course code:"); 
        string courseCode = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(courseCode))
        {
            Console.Write("invalid! Enter course code:");
            courseCode = Console.ReadLine();
        }

            

        bool courseavailablityFlag=CoursesList.Where(cc => cc.Course_code == courseCode).Any();
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