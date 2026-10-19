using tms.Models;

namespace tms.Services;

/// <summary>
/// Classroom payment processor using EXPLICIT interface implementation.
/// The ProcessPayment methods are explicitly bound to IPaymentProcessor and
/// CANNOT be called directly on an instance of ClassroomPaymentProcessor.
/// They must be invoked via an IPaymentProcessor interface reference.
/// </summary>
public class ClassroomPaymentProcessor : IPaymentProcessor
{
    // Explicit interface implementation: no access modifier, prefixed with IPaymentProcessor.
    bool IPaymentProcessor.ProcessPayment(int enrollmentId)
    {
        return ((IPaymentProcessor)this).ProcessPayment(enrollmentId, 0m, null);
    }

    bool IPaymentProcessor.ProcessPayment(int enrollmentId, decimal amount)
    {
        return ((IPaymentProcessor)this).ProcessPayment(enrollmentId, amount, null);
    }

    bool IPaymentProcessor.ProcessPayment(int enrollmentId, decimal amount, bool? simulateSuccess)
    {
        List<string> lines = new List<string>();
        string path ="/Users/hrithik/hcl training/trainingmannagement/tms/files/invoice.txt";
        Console.WriteLine("\n-------------------------------------------------------");
        Console.WriteLine("[ClassroomPaymentProcessor] Processing classroom payment...");

        // Look up enrollment
        Enrollment? enrollment = enrolementservices.enrollments.FirstOrDefault(e => e.EnrollmentId == enrollmentId);

        if (enrollment == null)
        {
            Console.WriteLine($"[Classroom Payment Failed] Enrollment ID {enrollmentId} not found.");
            Payment.RecordPayment(enrollmentId, amount, PaymentStatus.Failed);
            Console.WriteLine("-------------------------------------------------------");
            return false;
        }

        // Rule: Reject payment for cancelled enrollments
        if (string.Equals(enrollment.Status, "Cancelled", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"[Classroom Payment Rejected] Enrollment #{enrollmentId} is CANCELLED.");
            Console.WriteLine("Cannot process payment for cancelled enrollments.");

            decimal recordedFee = amount > 0 ? amount : (enrollment.FinalFee > 0 ? enrollment.FinalFee : enrollment.BaseFee) + 800m;
            // Rule: Record both successful and failed payment attempts
            Payment.RecordPayment(enrollmentId, recordedFee, PaymentStatus.Failed);
            Console.WriteLine("-------------------------------------------------------");
            return false;
        }

        // Calculate amount if not explicitly provided (base fee + ₹800 classroom session surcharge)
        if (amount <= 0)
        {
            decimal baseAmount = enrollment.FinalFee > 0 ? enrollment.FinalFee : enrollment.BaseFee;
            if (baseAmount <= 0)
            {
                var course = courseservices.GetCourseByCode(enrollment.CourseCode);
                if (course != null) baseAmount = course.Fees;
            }
            amount = baseAmount + 800m; // ₹800 classroom surcharge
        }

        
        Console.WriteLine($"Enrollment ID      : {enrollment.EnrollmentId}");
        Console.WriteLine($"Learner ID         : {enrollment.LearnerId}");
        Console.WriteLine($"Course Code        : {enrollment.CourseCode}");
        Console.WriteLine($"Total Amount (₹)   : {amount:F2} (includes ₹800 classroom surcharge)");
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
            Console.Write("Simulate successful classroom payment? (Y/N): ");
            string? input = Console.ReadLine();
            isSuccess = input?.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase) == true;
        }

        if (isSuccess)
        {
            // Rule: Update enrollment payment status ONLY after a successful payment
            enrollment.PaymentStatus = PaymentStatus.Successful;

            // Rule: Record both successful and failed payment attempts
            Payment.RecordPayment(enrollmentId, amount, PaymentStatus.Successful);

            Console.WriteLine($"[Classroom Payment Successful] Payment of ₹{amount:F2} processed.");
            Console.WriteLine($"Enrollment #{enrollmentId} payment status updated to '{enrollment.PaymentStatus}'.");
            Console.WriteLine("-------------------------------------------------------");
            lines.Add("--------------invoice----------------\n"+
                      $"Enrollment ID      : {enrollment.EnrollmentId}\n" +
                      $"Learner ID         : {enrollment.LearnerId}\n" +
                      $"Course Code        : {enrollment.CourseCode}\n" +
                      $"Total Amount (₹)   : {amount:F2} (includes ₹800 classroom surcharge)\n" +
                      $"Current Pay Status : {enrollment.PaymentStatus}");
            File.WriteAllLines(path,lines);
            return true;
        }
        else
        {
            // Rule: Record failed attempt, do NOT update enrollment payment status to successful
            Payment.RecordPayment(enrollmentId, amount, PaymentStatus.Failed);

            Console.WriteLine($"[Classroom Payment Failed] Payment of ₹{amount:F2} failed.");
            Console.WriteLine($"Enrollment #{enrollmentId} payment status remains '{enrollment.PaymentStatus}'.");
            Console.WriteLine("-------------------------------------------------------");
            lines.Clear();
            lines.Add("--------------invoice----------------\n"+
                      "payment failed for enrollment id" + enrollmentId+$" payment status remains {enrollment.PaymentStatus}");
            File.WriteAllLines(path,lines);
            return false;
        }
    }
}