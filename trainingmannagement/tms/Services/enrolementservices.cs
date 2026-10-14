using tms.Models;

namespace tms.Services;

public class enrolementservices
{
    public static List<Enrollment>  enrollments=new List<Enrollment>();

    public static void AddEnrollment()
    {
        Console.WriteLine("enter learnerID to be enroled ");
        string learnerid=Console.ReadLine();
        while (string.IsNullOrEmpty(learnerid))
        {
            Console.WriteLine("enter learnerID to be enroled ");
            learnerid=Console.ReadLine();
        }
        
        // Automatically retrieve the course fee
        Console.WriteLine("Enter course ID:");

        string courseid = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(courseid))

        {

            Console.WriteLine("Course ID cannot be empty. Enter course ID:");

            courseid = Console.ReadLine();

        }

        // Retrieve the selected course

        courses selectedCourse = courseservices.GetCourseByCode(courseid);

        if (selectedCourse == null)

        {

            Console.WriteLine("Course not found. Enrollment cancelled.");

            return;

        }

        

        decimal basefees = selectedCourse.Fees;
        
        
        decimal discount=0;
        decimal finalfee=basefees-discount;
        Enrollment enrollment = new Enrollment(learnerid,courseid,basefees,discount,finalfee);
        enrollments.Add(enrollment);
        
    }

    public static void displayEnrollments()
    {
        foreach (Enrollment en in enrollments)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"enrolmentId:{en.EnrollmentId}\n" +
                              $"learner Id:{en.LearnerId}\n" +
                              $"course: {en.CourseCode}");
            Console.WriteLine("-------------------------------------");
        }
    }

    public static void cancelEnrollment()
    {
        Console.WriteLine("enter enrolement to id cancel enrollment");
        
        if (!int.TryParse(Console.ReadLine(), out int enrollmentId))
        {
            Console.WriteLine("Invalid Enrollment ID.");
            return;
        }

        foreach (Enrollment en in enrollments)
        {
            if (en.EnrollmentId == enrollmentId && en.Status == "active")
            {
                en.cancel();
                Console.WriteLine("Enrollment cancelled successfully!");
                Console.WriteLine($"Enrollment ID: {en.EnrollmentId}");
                Console.WriteLine($"Status: {en.Status}");
                return;
            }
        }
        Console.WriteLine("Active enrollment not found.");


        


    }
    
    
}