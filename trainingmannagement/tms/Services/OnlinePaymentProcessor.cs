using tms.Models;

namespace tms.Services;

/// <summary>
/// Online payment processor using IMPLICIT interface implementation.
/// Methods are public and accessible directly or via an IPaymentProcessor reference.
/// </summary>
public class OnlinePaymentProcessor : IPaymentProcessor
{
    
    // why implicit and explicit implementation is given in c#  becoz if an project contains more than 1 or more interfaces and the methods required for the interface has same name in order to avoid name colliding explicit implentation was invented as explicit implentation uses its interface reference and interface name to define the method its used
    // Implicit implementation: public methods matching interface signature
    public bool ProcessPayment(int enrollmentId)
    {
        return ProcessPayment(enrollmentId, 0m, null);
    }

    public bool ProcessPayment(int enrollmentId, decimal amount)
    {
        return ProcessPayment(enrollmentId, amount, null);
    }

    public bool ProcessPayment(int enrollmentId, decimal amount, bool? simulateSuccess)
    {
        List<string> lines = new List<string>();
        string path ="/Users/hrithik/hcl training/trainingmannagement/tms/files/invoice.txt";
        Console.WriteLine("\n-------------------------------------------------------");
        Console.WriteLine("[OnlinePaymentProcessor] Processing online payment...");

        // Look up enrollment
        Enrollment? enrollment = enrolementservices.enrollments.FirstOrDefault(e => e.EnrollmentId == enrollmentId);

        if (enrollment == null)
        {
            Console.WriteLine($"[Online Payment Failed] Enrollment ID {enrollmentId} not found.");
            Payment.RecordPayment(enrollmentId, amount, PaymentStatus.Failed);
            Console.WriteLine("-------------------------------------------------------");
            return false;
        }

        // Rule: Reject payment for cancelled enrollments
        if (string.Equals(enrollment.Status, "Cancelled", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"[Online Payment Rejected] Enrollment #{enrollmentId} is CANCELLED.");
            Console.WriteLine("Cannot process payment for cancelled enrollments.");

            decimal recordedFee = amount > 0 ? amount : (enrollment.FinalFee > 0 ? enrollment.FinalFee : enrollment.BaseFee) + 200m;
            // Rule: Record both successful and failed payment attempts
            Payment.RecordPayment(enrollmentId, recordedFee, PaymentStatus.Failed);
            Console.WriteLine("-------------------------------------------------------");
            return false;
        }

        // Calculate amount if not explicitly provided (base fee + ₹200 online session surcharge)
        if (amount <= 0)
        {
            decimal baseAmount = enrollment.FinalFee > 0 ? enrollment.FinalFee : enrollment.BaseFee;
            if (baseAmount <= 0)
            {
                var course = courseservices.GetCourseByCode(enrollment.CourseCode);
                if (course != null) baseAmount = course.Fees;
            }
            amount = baseAmount + 200m; // ₹200 online surcharge
        }

        Console.WriteLine($"Enrollment ID      : {enrollment.EnrollmentId}");
        Console.WriteLine($"Learner ID         : {enrollment.LearnerId}");
        Console.WriteLine($"Course Code        : {enrollment.CourseCode}");
        Console.WriteLine($"Total Amount (₹)   : {amount:F2} (includes ₹200 online surcharge)");
        Console.WriteLine($"Current Pay Status : {enrollment.PaymentStatus}");

        // Rule: Simulate payment success and failure; do not process real money
        bool isSuccess;
        if (simulateSuccess.HasValue)
        {
            isSuccess = simulateSuccess.Value;
            Console.WriteLine($"Simulating payment outcome: {(isSuccess ? "SUCCESS" : "FAILURE")}");
        }
        else
        {
            Console.Write("Simulate successful online payment? (Y/N): ");
            string? input = Console.ReadLine();
            isSuccess = input?.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase) == true;
        }

        if (isSuccess)
        {
            // Rule: Update enrollment payment status ONLY after a successful payment
            enrollment.PaymentStatus = PaymentStatus.Successful;

            // Rule: Record both successful and failed payment attempts
            Payment.RecordPayment(enrollmentId, amount, PaymentStatus.Successful);

            Console.WriteLine($"[Online Payment Successful] Payment of ₹{amount:F2} processed.");
            Console.WriteLine($"Enrollment #{enrollmentId} payment status updated to '{enrollment.PaymentStatus}'.");
            Console.WriteLine("-------------------------------------------------------");
            lines.Add($"------------invoice------------------------------ \n" + 
                      $"Enrollment ID      : {enrollment.EnrollmentId}\n" + 
                      $"Learner ID         : {enrollment.LearnerId}\n" + 
                      $"Course Code        : {enrollment.CourseCode}\n" + 
                      $"Total Amount (₹)   : {amount:F2} (includes ₹200 online surcharge)\n" + 
                      $"Current Pay Status : {enrollment.PaymentStatus}");
            File.WriteAllLines(path,lines);
            return true;
        }
        else
        {
            // Rule: Record failed attempt, do NOT update enrollment payment status to successful
            Payment.RecordPayment(enrollmentId, amount, PaymentStatus.Failed);

            Console.WriteLine($"[Online Payment Failed] Payment of ₹{amount:F2} failed.");
            Console.WriteLine($"Enrollment #{enrollmentId} payment status remains '{enrollment.PaymentStatus}'.");
            Console.WriteLine("-------------------------------------------------------");
            lines.Clear();
            lines.Add("-----------incvoice--------------\n"+
                      $"payment failed !!  for Enrollment ID      : {enrollment.EnrollmentId}"+
                      $"payment status remains '{enrollment.PaymentStatus}");
            File.WriteAllLines(path,lines);

            return false;
        }
    }
}