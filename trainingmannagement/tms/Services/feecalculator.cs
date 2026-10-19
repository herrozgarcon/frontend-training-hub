namespace tms.Services;
using tms.Models;



public class feecalculator
{
    public static decimal totalfees;
    public static decimal? calculatefees(decimal totalFees=0)
    {
        
        Console.WriteLine("enter the coursecode to calculate the fees");
        string courseCode = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(courseCode))
        {
            Console.WriteLine("enter the correct  coursecode to calculate the fees");
            courseCode = Console.ReadLine();
        }
        Console.WriteLine("enter the learnerid to calculate the fees");
        string learnerid = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(learnerid))
        {
            Console.WriteLine("enter the correct  coursecode to calculate the fees");
            learnerid = Console.ReadLine();
        }
        
        courses selectedCourse = courseservices.GetCourseByCode(courseCode);

        if (selectedCourse == null)

        {

            Console.WriteLine("Course not found");

            return null;

        }
        
        decimal basefees = selectedCourse.Fees;
        totalFees = basefees;
       
        Enrollment? enrollment = enrolementservices.enrollments.FirstOrDefault(e => e.LearnerId == learnerid);

        if (enrollment == null)

        {

            throw new ArgumentException("Enrollment not found.");

        }

        DateTime enrollmentDate = enrollment.EnrollmentDate;

        // Replace this with the actual course start date.

        DateTime courseStartDate = new DateTime(2026, 11, 21);

        return (courseStartDate.Date - enrollmentDate.Date).TotalDays >= 14
            ? enrollment.BaseFee * 0.10m
            : 0m;

        
    }
    
}