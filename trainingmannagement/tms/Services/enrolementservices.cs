using tms.exception;
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

        bool valid = learnerservices.learners.ContainsKey(learnerid);

        if (!valid)
        {
            Console.WriteLine("Invalid learner ID. or learner ID not found.");
            return;
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
        
        
        decimal discount=10;
        decimal finalfee=basefees - (basefees*0.10m);
        Enrollment enrollment = new Enrollment(learnerid,courseid,basefees,discount,finalfee);
        enrollments.Add(enrollment);
        
        string path ="/Users/hrithik/hcl training/trainingmannagement/tms/files/enrolements.txt";
        List<string> lines = new List<string>();
        foreach (Enrollment enfile in enrollments)
        {
            lines.Add("--------------------------------------\n" +
                      $"Enrollment ID  : {enfile.EnrollmentId}\n" +
                      $"Learner ID     : {enfile.LearnerId}\n" +
                      $"Course Code    : {enfile.CourseCode}\n" +
                      $"Base Fee       : ₹{enfile.BaseFee:F2}\n" +
                      $"Final Fee      : ₹{enfile.FinalFee:F2}\n" +
                      $"Enrollment Date: {enfile.EnrollmentDate:yyyy-MM-dd}\n" +
                      $"Status         : {enfile.Status}\n" +
                      $"Payment Status : {enfile.PaymentStatus}\n" +
                      $"-----------------------------------------");
        }
        File.WriteAllLines(path, lines);
        
    }

    public static void displayEnrollments()
    {
        
        string path ="/Users/hrithik/hcl training/trainingmannagement/tms/files/enrolements.txt";
        List<string> lines = new List<string>();
        if (enrollments.Count == 0)
        {
            Console.WriteLine("No enrollments found.");
            return;
        }

        foreach (Enrollment enfile in enrollments)
        {
            lines.Add("--------------------------------------\n" +
                      $"Enrollment ID  : {enfile.EnrollmentId}\n" +
                      $"Learner ID     : {enfile.LearnerId}\n" +
                      $"Course Code    : {enfile.CourseCode}\n" +
                      $"Base Fee       : ₹{enfile.BaseFee:F2}\n" +
                      $"Final Fee      : ₹{enfile.FinalFee:F2}\n" +
                      $"Enrollment Date: {enfile.EnrollmentDate:yyyy-MM-dd}\n" +
                      $"Status         : {enfile.Status}\n" +
                      $"Payment Status : {enfile.PaymentStatus}\n" +
                      $"-----------------------------------------");
        }

        foreach (Enrollment en in enrollments)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Enrollment ID  : {en.EnrollmentId}\n" +
                              $"Learner ID     : {en.LearnerId}\n" +
                              $"Course Code    : {en.CourseCode}\n" +
                              $"Base Fee       : ₹{en.BaseFee:F2}\n" +
                              $"Final Fee      : ₹{en.FinalFee:F2}\n" +
                              $"Enrollment Date: {en.EnrollmentDate:yyyy-MM-dd}\n" +
                              $"Status         : {en.Status}\n" +
                              $"Payment Status : {en.PaymentStatus}");
            Console.WriteLine("-------------------------------------");
        }
        
        File.WriteAllLines(path, lines);
    }

    public static void cancelEnrollment()
    {
        string path ="/Users/hrithik/hcl training/trainingmannagement/tms/files/enrolements.txt";
        List<string> lines = new List<string>();
        Console.WriteLine("enter enrolement id  to cancel enrollment");
        
        if (!int.TryParse(Console.ReadLine(), out int enrollmentId))
        {
            Console.WriteLine("Invalid Enrollment ID.");
            return;
        }
        var en = enrollments.FirstOrDefault(en =>
            en.EnrollmentId == enrollmentId &&
            string.Equals(en.Status, "Active", StringComparison.OrdinalIgnoreCase));

        if (en != null)
        {
            en.cancel();
            Console.WriteLine("Enrollment cancelled successfully!");
            Console.WriteLine($"Enrollment ID: {en.EnrollmentId}");
            Console.WriteLine($"Status: {en.Status}");
            foreach (Enrollment enfile in enrollments)
            {
                lines.Add("--------------------------------------\n" +
                          $"Enrollment ID  : {enfile.EnrollmentId}\n" +
                          $"Learner ID     : {enfile.LearnerId}\n" +
                          $"Course Code    : {enfile.CourseCode}\n" +
                          $"Base Fee       : ₹{enfile.BaseFee:F2}\n" +
                          $"Final Fee      : ₹{enfile.FinalFee:F2}\n" +
                          $"Enrollment Date: {enfile.EnrollmentDate:yyyy-MM-dd}\n" +
                          $"Status         : {enfile.Status}\n" +
                          $"Payment Status : {enfile.PaymentStatus}\n" +
                          $"-----------------------------------------");
            }
            File.WriteAllLines(path, lines);
            return;
        }


        Console.WriteLine("Active enrollment not found.");
        throw new doesnotcontain("enrolement not in enrolement list or erolement id may be invalid");
    }
}